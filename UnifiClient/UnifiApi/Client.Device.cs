using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnifiApi.Helpers;
using UnifiApi.Models;
using UnifiApi.Responses;

namespace UnifiApi
{
    public partial class Client
    {
        /// <summary>
        /// List access points and other devices under management of the controller (USW and/or USG devices)
        /// </summary>
        /// <param name="deviceMac">MAC address of a single device. (Optional)</param>
        /// <returns>Task&lt;BaseResponse&lt;Site&gt;&gt;.</returns>
        public async Task<BaseResponse<Device>> ListDevicesAsync(string deviceMac = null)
        {
            var path = $"api/s/{Site}/stat/device/{deviceMac}";
            
            var response = await ExecuteGetCommandAsync(path);
            //TODO: Fix the deserialization to handle bad MAC addresses
            return JsonConvert.DeserializeObject<BaseResponse<Device>>(response.Result);
        }

        /// <summary>
        /// Adopt a device to the selected site.
        /// </summary>
        /// <param name="deviceMac">The device MAC address.</param>
        /// <param name="siteName">Name of the site.</param>
        /// <returns>return <c>true</c> on success</returns>
        public async Task<BoolResponse> AdoptDeviceAsync(string deviceMac, string siteName = null)
        {
            var path = $"api/s/{(siteName ?? Site)}/cmd/devmgr";

            var oJsonObject = new JObject();
            oJsonObject.Add("mac", deviceMac.ToLower());
            oJsonObject.Add("cmd", "adopt");

            return await ExecuteBoolCommandAsync(path, oJsonObject);
        }

        /// <summary>
        /// restart a device.
        /// </summary>
        /// <param name="deviceMac">The device MAC Address.</param>
        /// <returns>return <c>true</c> on success</returns>
        public async Task<BoolResponse> RestartDeviceAsync(string deviceMac)
        {
            var path = $"api/s/{Site}/cmd/devmgr";

            var oJsonObject = new JObject();
            oJsonObject.Add("mac", deviceMac.ToLower());
            oJsonObject.Add("cmd", "restart");

            return await ExecuteBoolCommandAsync(path, oJsonObject);
        }

        /// <summary>
        /// rename device.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="name">The name to set for the device.</param>
        /// <returns>return <c>true</c> on success.</returns>
        public async Task<BoolResponse> RenameDeviceAsync(string deviceId, string name)
        {
            var path = $"api/s/{Site}/upd/device/{deviceId}";

            var oJsonObject = new JObject();
            oJsonObject.Add("name", name);

            return await ExecuteBoolCommandAsync(path, oJsonObject);
        }

        /// <summary>
        /// Disable/enable an access point.
        /// </summary>
        /// <remarks>a disabled device will be excluded from the dashboard status and device count and its LED and WLAN will be turned off</remarks>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="disable">if set to <c>true</c> [disable].</param>
        /// <returns>return <c>true</c> on success.</returns>
        /// <exception cref="NotSupportedException">The controller version does not accept this request.</exception>
        [MinimumVersionRequired(5, 2)]
        public async Task<BoolResponse> DisableApAsync(string deviceId, bool disable = true)
        {
            if (!Version.IsValid())
                throw new NotSupportedException("The controller version does not accept this request.");

            var path = $"api/s/{Site}/rest/device/{deviceId}";

            var oJsonObject = new JObject();
            oJsonObject.Add("disabled", disable);

            return await ExecuteBoolCommandAsync(path, oJsonObject, "PUT");
        }

        /// <summary>
        /// Override LED mode for a device
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="mode">The override mode. off/on/default; "off" will disable the LED of the device, "on" will enable the LED of the device,  "default" will apply the site-wide setting for device LEDs</param>
        /// <returns>return <c>true</c> on success.</returns>
        /// <exception cref="NotSupportedException">The controller version does not accept this request.</exception>
        [MinimumVersionRequired(5, 2)]
        public async Task<BoolResponse> OverrideLedAsync(string deviceId, Enumerations.OverrideMode mode)
        {
            if (!Version.IsValid())
                throw new NotSupportedException("The controller version does not accept this request.");

            var path = $"api/s/{Site}/rest/device/{deviceId}";

            var oJsonObject = new JObject();
            oJsonObject.Add("led_override", mode.GetStringValue());

            return await ExecuteBoolCommandAsync(path, oJsonObject, "PUT");
        }

        /// <summary>
        /// locate device as an asynchronous operation.
        /// </summary>
        /// <param name="deviceMac">The device mac.</param>
        /// <param name="enable">if set to <c>true</c> [enable].</param>
        /// <returns>Task&lt;BoolResponse&gt;.</returns>
        public async Task<BoolResponse> LocateDeviceAsync(string deviceMac, bool enable)
        {
            var path = $"api/s/{Site}/cmd/devmgr";

            var oJsonObject = new JObject();
            oJsonObject.Add("cmd", enable ? "set-locate" : "unset-locate");
            oJsonObject.Add("mac", deviceMac.ToLower());

            return await ExecuteBoolCommandAsync(path, oJsonObject);
        }

        /// <summary>
        /// list device tags.
        /// </summary>
        /// <returns>returns a list of known device tags and members.</returns>
        /// <exception cref="NotSupportedException">The controller version does not accept this request.</exception>
        [MinimumVersionRequired(5, 5)]
        public async Task<BaseResponse<DeviceTags>> ListDeviceTagsAsync()
        {
            if (!Version.IsValid())
                throw new NotSupportedException("The controller version does not accept this request.");

            var path = $"api/s/{Site}/rest/tag";

            var response = await ExecuteGetCommandAsync(path);
            return JsonConvert.DeserializeObject<BaseResponse<DeviceTags>>(response.Result);
        }

        /// <summary>
        /// List rogue/neighboring access points
        /// </summary>
        /// <param name="within">The within x hours to go back to list discovered "rogue" access points (default = 24 hours)</param>
        /// <returns>List of rogue/neighboring access points</returns>
        public async Task<BaseResponse<RougeAp>> ListRougeApAsync(int within = 24)
        {
            var path = $"api/s/{Site}/stat/rogueap";

            var oJsonObject = new JObject();
            oJsonObject.Add("within", within);

            var response = await ExecuteJsonCommandAsync(path, oJsonObject);

            return JsonConvert.DeserializeObject<BaseResponse<RougeAp>>(response.Result);
        }

        /// <summary>
        /// list known rogue/neighboring access points
        /// </summary>
        /// <returns>List of rogue/neighboring access points</returns>
        public async Task<BaseResponse<RougeAp>> ListKnownRougeApAsync()
        {
            var path = $"api/s/{Site}/rest/rogueknown";

            var response = await ExecuteGetCommandAsync(path);
            //TODO: Need to check Model is the same
            return JsonConvert.DeserializeObject<BaseResponse<RougeAp>>(response.Result);
        }
    }
}