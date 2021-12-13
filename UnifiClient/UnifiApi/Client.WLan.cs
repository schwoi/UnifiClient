using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnifiApi.Helpers;
using UnifiApi.Models;
using UnifiApi.Responses;
using static UnifiApi.Models.Enumerations;

namespace UnifiApi
{
    public partial class Client
    {
        /// <summary>
        /// List access points and other devices under management of the controller (USW and/or USG devices)
        /// </summary>
        /// <param name="wlanId">id value of the wlan to fetch the settings. (Optional)</param>
        /// <returns>List WLan</returns>
        public async Task<BaseResponse<WLan>> ListWLanAsync(string wlanId = null)
        {
            var path = $"api/s/{Site}/rest/wlanconf/{wlanId}";
            
            var response = await ExecuteGetCommandAsync(path);
            return JsonConvert.DeserializeObject<BaseResponse<WLan>>(response.Result);
        }

        /// <summary>
        /// Create a WLAN
        /// </summary>
        /// <param name="name">SSID</param>
        /// <param name="passphrase">new pre-shared key, minimal length is 8 characters, maximum length is 63, assign a value of null when security = 'open'</param>
        /// <param name="userGoupId">user group id that can be found using the ListUserGroupsAsync() function</param>
        /// <param name="wlanGroupId">wlan group id that can be found using the ListWlanGroups() function</param>
        /// <param name="enabled">enable/disable wlan (Optional)</param>
        /// <param name="hideSSID">hide/unhide wlan SSID </param>
        /// <param name="isGuest">apply guest policies or not</param>
        /// <param name="security">security type</param>
        /// <param name="wpaMode">wpa mode </param>
        /// <param name="wpaEncryption">encryption </param>
        /// <param name="vlanId">value  of the VLAN to assign to this WLAN, can be found using ListNetworkConf()</param>
        /// <param name="uapsdEnabled">enable/disable Unscheduled Automatic Power Save Delivery</param>
        /// <returns>Boolean</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<BoolResponse> CreateWLanAsync(string name, string passphrase, string userGoupId, string wlanGroupId, bool enabled = true, bool hideSSID = false, bool isGuest = false, SecurityType security = SecurityType.Open, WPAMode wpaMode = WPAMode.WPA2, WPAEncryption wpaEncryption = WPAEncryption.CCMP, string vlanId = null, bool uapsdEnabled = false)
        {

            //TODO: Build Tests
            var path = $"api/s/{Site}/add/wlanconf";

            var oJsonObject = new JObject();
            oJsonObject.Add("name", name);
            oJsonObject.Add("usergroup_id", userGoupId);
            oJsonObject.Add("wlangroup_id", wlanGroupId);
            oJsonObject.Add("enabled", enabled );
            oJsonObject.Add("hide_ssid",hideSSID );
            oJsonObject.Add("is_guest",isGuest );
            oJsonObject.Add("security", security.GetStringValue() );
            oJsonObject.Add("wpa_mode", wpaMode.GetStringValue());
            oJsonObject.Add("wpa_enc", wpaEncryption.GetStringValue());
            oJsonObject.Add("uapsd_enabled", uapsdEnabled );

            if (!string.IsNullOrEmpty(vlanId))
            {
                oJsonObject.Add("networkconf_id", vlanId);
            }

            if (security != SecurityType.Open && string.IsNullOrEmpty(passphrase))
                throw new ArgumentNullException("passphrase", "Passphrase cannot be empty unless the securtiy mode is open"); 

            if (security != SecurityType.Open)
                oJsonObject.Add("x_passphrase", passphrase);

            //TODO: Implement AP Groups
            //if (apGroupIds != null)
            //    oJsonObject.Add("ap_group_ids", apGroupIds);

            return await ExecuteBoolCommandAsync(path, oJsonObject);
        }

        /// <summary>
        /// Delete a WLAN
        /// </summary>
        /// <param name="wlanId">id value of the wlan to delete</param>
        /// <returns>Boolean</returns>
        public async Task<BoolResponse> DeleteWLanAsync(string wlanId)
        {
            //TODO: Build Tests
            var path = $"api/s/{Site}/rest/wlanconf/{wlanId}";
            return await ExecuteDeleteCommandAsync(path);
        }

        /// <summary>
        /// Disable WLAN
        /// </summary>
        /// <param name="wlanId">id value of the wlan to disable</param>
        /// <returns>Boolean</returns>
        public async Task<BoolResponse> DisableWLanAsync(string wlanId)
        {
            //TODO: Build Tests
            if (string.IsNullOrWhiteSpace(wlanId))
                throw new ArgumentNullException(nameof(wlanId));

            var oJsonObject = new JObject();
            oJsonObject.Add("enabled", false);

            return await setWlanBaseSettingAsync(wlanId, oJsonObject);
        }

        /// <summary>
        /// Enable WLAN
        /// </summary>
        /// <param name="wlanId">id value of the wlan to enable</param>
        /// <returns>Boolean</returns>
        public async Task<BoolResponse> EnableWLanAsync(string wlanId)
        {
            //TODO: Build Tests
            if (string.IsNullOrWhiteSpace( wlanId))
                throw new ArgumentNullException(nameof(wlanId));

            var oJsonObject = new JObject();
            oJsonObject.Add("enabled", true);

            return await setWlanBaseSettingAsync(wlanId, oJsonObject);
        }

        public async Task<BoolResponse> ChangeWLanSSIDAsync(string wlanId, string name)
        {
            //TODO: Build Tests
            if (string.IsNullOrWhiteSpace(wlanId))
                throw new ArgumentNullException(nameof(wlanId));

            var oJsonObject = new JObject();
            oJsonObject.Add("name", name);

            return await setWlanBaseSettingAsync(wlanId, oJsonObject);
        }

        public async Task<BoolResponse> ChangeWLanPassphraseAsync(string wlanId, string passphrase)
        {
            //TODO: Build Tests
            if (string.IsNullOrWhiteSpace(wlanId))
                throw new ArgumentNullException(nameof(wlanId));

            var oJsonObject = new JObject();
            oJsonObject.Add("x_passphrase", passphrase);

            return await setWlanBaseSettingAsync(wlanId, oJsonObject);
        }

        private async Task<BoolResponse> setWlanBaseSettingAsync(string wlanId, JObject payload)
        {
            var path = $"api/s/{Site}/rest/wlanconf/{wlanId}";
            return await ExecuteBoolCommandAsync(path, payload, "PUT");
        }

       
    }
}