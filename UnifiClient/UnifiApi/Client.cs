using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnifiApi.Helpers;
using UnifiApi.Models;
using UnifiApi.Responses;

namespace UnifiApi
{
    public partial class Client : IDisposable
    {
        private const string _contentType = "application/json";
        private HttpClient httpClient;
        public string BaseUrl { get; set; }
        public string Site { get; set; }
        public Version Version { get; set; }
        public bool IsUp { get; set; }
        public bool IsLoggedIn { get; set; }
        public bool IgnoreSslCertificate { get; set; }

        public Client()
        {
            BaseUrl = "https://127.0.0.1:8443";
            Site = "default";
            this.Version = Version.Parse("0.0.0");
            IsLoggedIn = false;
            IgnoreSslCertificate = true;
            CreateClient();
        }

        public Client(string baseUrl, string site = null, bool ignoreSslCertificate = false)
        {
            BaseUrl = baseUrl;
            Site = string.IsNullOrEmpty(site) ? "default" : site;
            this.Version = Version.Parse("0.0.0");
            IsLoggedIn = false;
            IgnoreSslCertificate = ignoreSslCertificate;
            CreateClient();
        }

        private void CreateClient()
        {

            var httpClientHandler = new HttpClientHandler();

            if (IgnoreSslCertificate)
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
                {
                    return true;
                };
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }

            httpClient = new HttpClient(httpClientHandler);
            httpClient.BaseAddress = new Uri(BaseUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_contentType));

        }

        public async void Dispose()
        {
            if (IsLoggedIn)
                await LogoutAsync();

            httpClient.Dispose();
            
        }


        /// <summary>
        /// Login to UniFi Controller.
        /// </summary>
        /// <param name="username">The username for the Unifi Controller</param>
        /// <param name="password">The password.</param>
        /// <returns>BoolResponse. true upon success</returns>
        public async Task<BoolResponse> LoginAsync(string username, string password)
        {
            var path = "api/login";

            JObject oJsonObject = new JObject();
            oJsonObject.Add("username", username);
            oJsonObject.Add("password", password);

            var returnResult = await ExecuteBoolCommandAsync(path, oJsonObject);
            IsLoggedIn = returnResult.Result;

            if (IsLoggedIn)
            {
                var getControllerStatus = await GetControllerStatusAsync();
                Version = Version.Parse(getControllerStatus.Meta.ServerVersion);
                if (getControllerStatus.Meta.Up != null) IsUp = getControllerStatus.Meta.Up.Value;
            }

            return returnResult;
        }

        /// <summary>
        /// Logout of the UniFi Controller.
        /// </summary>
        /// <returns>BoolResponse. true upon success</returns>
        public async Task<bool> LogoutAsync()
        {
            var authPath = "logout";
            var response = await ExecuteCommandAsync(authPath, new JObject());
            IsLoggedIn = !response;
            return response;
        }

        /// <summary>
        /// Gets the controller status.
        /// </summary>
        /// <returns>UnifiApi.Models.BaseResponse&lt;UnifiApi.Models.UnifiClient&gt;.</returns>
        public async Task<BaseResponse> GetControllerStatusAsync()
        {
            var path = $"status";

            var oJsonObject = new JObject();

            var response = await ExecuteJsonCommandAsync(path, oJsonObject);

            var records = JsonConvert.DeserializeObject<BaseResponse>(response.Result);
            return records;
        }

        /// <summary>
        /// Gets the system information.
        /// </summary>
        /// <returns>BaseResponse&lt;SystemInfo&gt;</returns>
        public async Task<BaseResponse<SystemInfo>> GetSystemInfoAsync()
        {
            var path = $"api/s/{Site}/stat/sysinfo";

            var oJsonObject = new JObject();

            var response = await ExecuteJsonCommandAsync(path, oJsonObject);
            return JsonConvert.DeserializeObject<BaseResponse<SystemInfo>>(response.Result);
        }

        /// <summary>
        /// Lists the country codes.
        /// </summary>
        /// <returns>List of <c>CountryCode</c></returns>
        public async Task<BaseResponse<CountryCode>> ListCountryCodesAsync()
        {
            var path = $"api/s/{Site}/stat/ccode";

            var response = await ExecuteGetCommandAsync(path);

            return JsonConvert.DeserializeObject<BaseResponse<CountryCode>>(response.Result);
        }

        public async Task<BaseResponse<Backup>> ListBackupsAsync()
        {
            var path = $"api/s/{Site}/cmd/backup";

            var oJsonObject = new JObject();
            oJsonObject.Add("cmd", "list-backups");

            var response = await ExecuteJsonCommandAsync(path, oJsonObject);
            return JsonConvert.DeserializeObject<BaseResponse<Backup>>(response.Result);
        }


        #region Commands

        private async Task<BoolResponse> ExecuteBoolCommandAsync(string path, JObject jsonData, string requestType = "POST")
        {
            var returnResponse = new BoolResponse();

            HttpResponseMessage response;
            switch (requestType.ToUpper())
            {
                case "PUT":
                    response = await httpClient.PutAsync(path, new StringContent(jsonData.ToString(), Encoding.UTF8, _contentType));
                    break;

                default:
                    response = await httpClient.PostAsync(path, new StringContent(jsonData.ToString(), Encoding.UTF8, _contentType));
                    break;
            }
            returnResponse.StatusCode = response.StatusCode;

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var baseResponse = JsonConvert.DeserializeObject<BaseResponse>(responseString);
                if (baseResponse.Meta.Rc == "ok")
                {
                    returnResponse.Result = true;
                }
                else
                {
                    returnResponse.Result = false;
                    returnResponse.Response = baseResponse.Meta.Message;
                }
            }
            else
            {
                returnResponse.Response = response.ReasonPhrase;
            }

            return returnResponse;
        }

        private async Task<bool> ExecuteCommandAsync(string path, JObject jsonData)
        {
            var response = await httpClient.PostAsync(path, new StringContent(jsonData.ToString(), Encoding.UTF8, _contentType));

            return response.IsSuccessStatusCode;
        }

        private async Task<JsonResponse> ExecuteJsonCommandAsync(string path, JObject jsonData, string requestType = "POST")
        {
            var returnResponse = new JsonResponse();
            HttpResponseMessage response;
            switch (requestType.ToUpper())
            {
                case "PUT":
                    response = await httpClient.PutAsync(path, new StringContent(jsonData.ToString(), Encoding.UTF8, _contentType));
                    break;

                default:
                    response = await httpClient.PostAsync(path, new StringContent(jsonData.ToString(), Encoding.UTF8, _contentType));
                    break;
            }
                
            returnResponse.StatusCode = response.StatusCode;

            if (response.IsSuccessStatusCode)
            {
                returnResponse.Result = await response.Content.ReadAsStringAsync();
            }
            else
            {
                returnResponse.Response = response.ReasonPhrase;
            }

            return returnResponse;
        }

        private async Task<JsonResponse> ExecuteGetCommandAsync(string path)
        {
            var returnResponse = new JsonResponse();
            var response = await httpClient.GetAsync(path);
            returnResponse.StatusCode = response.StatusCode;

            if (response.IsSuccessStatusCode)
            {
                returnResponse.Result = await response.Content.ReadAsStringAsync();
            }
            else
            {
                returnResponse.Response = response.ReasonPhrase;
            }

            return returnResponse;
        }

        private async Task<BoolResponse> ExecuteDeleteCommandAsync(string path)
        {
            var returnResponse = new BoolResponse();

            var response = await httpClient.DeleteAsync(path);

            returnResponse.StatusCode = response.StatusCode;

            returnResponse.Result = response.IsSuccessStatusCode;
            if (!response.IsSuccessStatusCode)
            {
                returnResponse.Response = response.ReasonPhrase;
            }

            return returnResponse;
        }

        #endregion
    }
}
