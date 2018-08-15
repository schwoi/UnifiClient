using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnifiApi.Models;
using UnifiApi.Responses;

namespace UnifiApi
{
    public class Client : IDisposable
    {
        private const string _contentType = "application/json";
        private HttpClient httpClient;
        public string BaseUrl { get; set; }
        public string Site { get; set; }
        public string Version { get; set; }
        public bool IsUp { get; set; }
        public bool IsLoggedIn { get; set; }
        public bool IgnoreSslCertificate { get; set; }

        public Client()
        {
            BaseUrl = "https://127.0.0.1:8443";
            Site = "default";
            Version = "0.0.0";
            IsLoggedIn = false;
            IgnoreSslCertificate = true;
            CreateClient();
        }

        public Client(string baseUrl, string site = null, bool ignoreSslCertificate = false)
        {
            BaseUrl = baseUrl;
            Site = string.IsNullOrEmpty(site) ? "default" : site;
            Version = "0.0.0";
            IsLoggedIn = false;
            IgnoreSslCertificate = ignoreSslCertificate;
            CreateClient();
        }

        private void CreateClient()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(BaseUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_contentType));

            if (IgnoreSslCertificate)
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            }
        }

        public void Dispose()
        {
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
            //var returnResult = ExecuteBoolCommand(path, oJsonObject);
            IsLoggedIn = returnResult.Result;

            if (IsLoggedIn)
            {
                var getControllerStatus = await GetControllerStatusAsync();
                Version = getControllerStatus.Meta.ServerVersion;
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
        public async Task<BaseResponse<UnifiClient>> GetControllerStatusAsync()
        {
            var path = $"status";

            var oJsonObject = new JObject();

            var response = await ExecuteJsonCommandAsync(path, oJsonObject);

            var records = JsonConvert.DeserializeObject<BaseResponse<UnifiClient>>(response.Result);
            return records;
        }


        private async Task<BoolResponse> ExecuteBoolCommandAsync(string path, JObject jsonData)
        {
            var returnResponse = new BoolResponse();

            var response = await httpClient.PostAsync(path, new StringContent(jsonData.ToString(), Encoding.UTF8, _contentType));

            returnResponse.StatusCode = response.StatusCode;

            if (response.IsSuccessStatusCode)
            {
                var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
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

        private async Task<JsonResponse> ExecuteJsonCommandAsync(string path, JObject jsonData)
        {
            var returnResponse = new JsonResponse();
            var response = await httpClient.PostAsync(path, new StringContent(jsonData.ToString(), Encoding.UTF8, _contentType));
            returnResponse.StatusCode = response.StatusCode;

            if (response.IsSuccessStatusCode)
            {
                returnResponse.Result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
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
    }
}
