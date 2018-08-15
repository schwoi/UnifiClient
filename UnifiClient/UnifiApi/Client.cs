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
        /// List sites
        /// </summary>
        /// <returns>returns a list sites hosted on this controller with some details</returns>
        public async Task<BaseResponse<Site>> ListSitesAsync()
        {
            var path = $"api/self/sites";

            var oJsonObject = new JObject();
            
            var response = await ExecuteGetCommandAsync(path);
            return JsonConvert.DeserializeObject<BaseResponse<Site>>(response.Result);
            
        }

        #region Guest Methods

        /// <summary>
        /// Authorize a guest client device.
        /// </summary>
        /// <param name="clientMac">The client MAC address.</param>
        /// <param name="minutes">The minutes (from now) until authorization expires.</param>
        /// <param name="uploadKbps">The upload limit KBPS.</param>
        /// <param name="downloadKbps">The download limit KBPS.</param>
        /// <param name="transferMb">The data transfer limit MB.</param>
        /// <param name="accessPointMac">The access point mac.</param>
        /// <returns>BoolResponse. true on success</returns>
        public async Task<BoolResponse> AuthorizeGuestAsync(string clientMac, int minutes, int? uploadKbps = null, int? downloadKbps = null, int? transferMb = null, string accessPointMac = null)
        {
            var path = $"api/s/{Site}/cmd/stamgr";

            var oJsonObject = new JObject();
            oJsonObject.Add("cmd", "authorize-guest");
            oJsonObject.Add("mac", clientMac);
            oJsonObject.Add("minutes", minutes);
            if (uploadKbps != null)
                oJsonObject.Add("up", uploadKbps);
            if (downloadKbps != null)
                oJsonObject.Add("down", downloadKbps);
            if (transferMb != null)
                oJsonObject.Add("bytes", transferMb);
            if (accessPointMac != null)
                oJsonObject.Add("ap_mac", accessPointMac);

            return await ExecuteBoolCommandAsync(path, oJsonObject);
        }

        /// <summary>
        /// Unauthorize a guest client device.
        /// </summary>
        /// <param name="clientMac">The client MAC address.</param>
        /// <returns>BoolResponse. true on success</returns>
        public async Task<BoolResponse> UnauthorizeGuestAsync(string clientMac)
        {
            var path = $"api/s/{Site}/cmd/stamgr";

            var oJsonObject = new JObject();
            oJsonObject.Add("cmd", "unauthorize-guest");
            oJsonObject.Add("mac", clientMac);

            return await ExecuteBoolCommandAsync(path, oJsonObject);
        }

        /// <summary>
        /// Extend guest validity
        /// Unauthorize a guest client device.
        /// </summary>
        /// <param name="clientMac">The client MAC address.</param>
        /// <returns>BoolResponse. true on success</returns>
        public async Task<BoolResponse> ExtendGuestAsync(string clientMac)
        {
            var path = $"api/s/{Site}/cmd/hotspot";

            var oJsonObject = new JObject();
            oJsonObject.Add("cmd", "extend");
            oJsonObject.Add("_id", clientMac);

            return await ExecuteBoolCommandAsync(path, oJsonObject);
        }

        /// <summary>
        /// List guest devices
        /// </summary>
        /// <param name="within">time frame in hours to go back to list guests with valid access (default is 8760 hours or 1 year)</param>
        /// <returns>returns an array of guest device objects with valid access</returns>
        public async Task<BaseResponse<Guest>> ListGuestsAsync(int within = 8760)
        {
            var path = $"api/s/{Site}/stat/guest";

            var oJsonObject = new JObject();
            oJsonObject.Add("within", within);

            var response = await ExecuteJsonCommandAsync(path, oJsonObject);
            
            return JsonConvert.DeserializeObject<BaseResponse<Guest>>(response.Result);
        }
        #endregion

        #region Client Methods


        /// <summary>
        /// Blocks a client device.
        /// </summary>
        /// <param name="clientMac">The client MAC address.</param>
        /// <returns>BoolResponse.</returns>
        public async Task<BoolResponse> BlockClientAsync(string clientMac)
        {
            var path = $"api/s/{Site}/cmd/stamgr";

            var oJsonObject = new JObject();
            oJsonObject.Add("cmd", "block-sta");
            oJsonObject.Add("mac", clientMac);

            return await ExecuteBoolCommandAsync(path, oJsonObject);
        }

        /// <summary>
        /// Unblocks a client device.
        /// </summary>
        /// <param name="clientMac">The client MAC address.</param>
        /// <returns>BoolResponse.</returns>
        public async Task<BoolResponse> UnblockClientAsync(string clientMac)
        {
            var path = $"api/s/{Site}/cmd/stamgr";

            var oJsonObject = new JObject();
            oJsonObject.Add("cmd", "unblock-sta");
            oJsonObject.Add("mac", clientMac);

            return await ExecuteBoolCommandAsync(path, oJsonObject);
        }

        /// <summary>
        /// Get details for a single client device
        /// </summary>
        /// <param name="clientMac">The client MAC Address.</param>
        /// <returns>returns an object with the client device information</returns>
        public async Task<BaseResponse<ClientDevice>> ClientDetailsAsync(string clientMac)
        {
            var path = $"api/s/{Site}/stat/user/{clientMac}";

            var oJsonObject = new JObject();

            var response = await ExecuteJsonCommandAsync(path, oJsonObject);
            return JsonConvert.DeserializeObject<BaseResponse<ClientDevice>>(response.Result);

        }

        /// <summary>
        /// Show latest 'n' login sessions for a single client device
        /// </summary>
        /// <param name="clientMac">Client MAC address</param>
        /// <param name="limit">maximum number of sessions to get (default value is 5)</param>
        /// <returns>returns an array of latest login session objects for given client device</returns>
        public async Task<BaseResponse<ClientLogin>> ShowClientLoginsAsync(string clientMac, int? limit = null)
        {
            var path = $"api/s/{Site}/stat/session";

            var oJsonObject = new JObject();
            oJsonObject.Add("mac", clientMac);
            oJsonObject.Add("_limit", limit == null ? 5 : limit);
            oJsonObject.Add("_sort", "-assoc_time");

            var response = await ExecuteJsonCommandAsync(path, oJsonObject);
            var records = JsonConvert.DeserializeObject<BaseResponse<ClientLogin>>(response.Result);
            return records; // response;
        }

        /// <summary>
        /// List online client device(s)
        /// </summary>
        /// <param name="clientMac">Client MAC address</param>
        /// <returns>returns an array of online client device objects, or in case of a single device request, returns a single client device object.</returns>
        public async Task<BaseResponse<UnifiClient>> ListOnlineClientsAsync(string clientMac = "")
        {
            var path = $"api/s/{Site}/stat/sta/{clientMac}";

            var oJsonObject = new JObject();

            var response = await ExecuteJsonCommandAsync(path, oJsonObject);
            var records = JsonConvert.DeserializeObject<BaseResponse<UnifiClient>>(response.Result);
            return records;
        }

        /// <summary>
        /// List all client devices ever connected to the site.
        /// </summary>
        /// <remarks>
        /// within is only used to select clients that were online within that period,
        /// the returned stats per client are all-time totals, irrespective of the value of within
        /// </remarks>
        /// <param name="within">hours to go back (default is 8760 hours or 1 year)</param>
        /// <returns>returns an array of client device objects</returns>
        public async Task<BaseResponse<ClientList>> ListAllClients(int within = 8760)
        {
            var path = $"api/s/{Site}/stat/alluser";

            var oJsonObject = new JObject();
            oJsonObject.Add("type", "all");
            oJsonObject.Add("conn", "all");
            oJsonObject.Add("within", within);

            var response = await ExecuteJsonCommandAsync(path, oJsonObject);
            var records = JsonConvert.DeserializeObject<BaseResponse<ClientList>>(response.Result);
            return records; // response;
        }


        #endregion

        #region Commands


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

        private async Task<JsonResponse> ExecuteGetCommandAsync(string path)
        {
            var returnResponse = new JsonResponse();
            var response = await httpClient.GetAsync(path);
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

        #endregion
    }
}
