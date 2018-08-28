using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnifiApi.Models;
using UnifiApi.Responses;

namespace UnifiApi
{
    public partial class Client
    {
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
        public async Task<BoolResponse> AuthorizeGuestAsync(string clientMac, int minutes, int? uploadKbps = null,
            int? downloadKbps = null, int? transferMb = null, string accessPointMac = null)
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
    }
}