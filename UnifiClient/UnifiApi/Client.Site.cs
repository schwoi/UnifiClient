using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
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
        /// List sites
        /// </summary>
        /// <returns>returns a list sites hosted on this controller with some details</returns>
        public async Task<BaseResponse<Site>> ListSitesAsync()
        {
            var path = $"api/self/sites";

            var response = await ExecuteGetCommandAsync(path);
            return JsonConvert.DeserializeObject<BaseResponse<Site>>(response.Result);
        }

        public async Task<Site> GetSiteDetailAsync()
        {
            var path = $"api/self/sites";

            var response = await ExecuteGetCommandAsync(path);
            var baseResponse = JsonConvert.DeserializeObject<BaseResponse<Site>>(response.Result);

            return baseResponse.Data.FirstOrDefault(x => x.Name.Equals(Site));
        }

        /// <summary>
        /// Create a site
        /// </summary>
        /// <param name="siteName">the long name for the new site.</param>
        /// <returns>returns an list containing a single site object.</returns>
        public async Task<BaseResponse<Site>> CreateSiteAsync(string siteName)
        {
            var path = $"api/s/{Site}/cmd/sitemgr";
            var oJsonObject = new JObject();
            oJsonObject.Add("desc", siteName);
            oJsonObject.Add("cmd", "add-site");
            var response = await ExecuteJsonCommandAsync(path, oJsonObject);
            return JsonConvert.DeserializeObject<BaseResponse<Site>>(response.Result);
        }

        /// <summary>
        /// rename a site.
        /// </summary>
        /// <param name="newSiteName">New name of the site.</param>
        /// <param name="siteName">Name of the site to be renamed. If left null the process will rename the site specified is client.Site.</param>
        /// <returns>returns true on success.</returns>
        public async Task<BoolResponse> RenameSiteAsync(string newSiteName, string siteName = null)
        {
            var path = $"api/s/{(siteName ?? Site)}/cmd/sitemgr";
            var oJsonObject = new JObject();
            oJsonObject.Add("desc", newSiteName);
            oJsonObject.Add("cmd", "update-site");
            return await ExecuteBoolCommandAsync(path, oJsonObject);
        }

        /// <summary>
        /// set the site country.
        /// </summary>
        /// <param name="country">The country to set for the site.</param>
        /// <param name="siteName">Name of the site. If left null the process will rename the site specified is client.Site.</param>
        /// <returns>returns true on success</returns>
        public async Task<BoolResponse> SetSiteCountryAsync(CountrySetting country, string siteName = null)
        {
            var path = $"api/s/{(siteName ?? Site)}/rest/setting/country/{country.Code}";
            var oJsonObject = JObject.FromObject(country);
            return await ExecuteBoolCommandAsync(path, oJsonObject);
        }

        /// <summary>
        /// set the site locale.
        /// </summary>
        /// <param name="locale">The locale to set for the site.</param>
        /// <param name="siteName">Name of the site. If left null the process will rename the site specified is client.Site.</param>
        /// <returns>returns true on success</returns>
        public async Task<BoolResponse> SetSiteLocaleAsync(LocaleSetting locale, string siteName = null)
        {
            var path = $"api/s/{(siteName ?? Site)}/rest/setting/locale/{locale.Timezone}";
            var oJsonObject = JObject.FromObject(locale);
            return await ExecuteBoolCommandAsync(path, oJsonObject);
        }


        /// <summary>
        /// list site settings as JSON object.
        /// </summary>
        /// <param name="siteName">Name of the site.</param>
        /// <returns>returns List of JSON Objects</returns>
        public async Task<BaseResponse<JObject>> ListSiteSettingsAsJObjectAsync(string siteName = null)
        {
            var path = $"api/s/{(siteName ?? Site)}/get/setting";
            var response = await ExecuteGetCommandAsync(path);

            return JsonConvert.DeserializeObject<BaseResponse<JObject>>(response.Result);
        }


            /// <summary>
            /// Lists the site settings.
            /// </summary>
            /// <param name="siteName">Name of the site to list the settings for.</param>
            /// <returns>returns Site Settings Object</returns>
            public async Task<BaseResponse<SiteSettings>> ListSiteSettingsAsync(string siteName = null)
        {
            var returnObject = new SiteSettings();

            var response = await ListSiteSettingsAsJObjectAsync(siteName);

            foreach (dynamic obj in response.Data)
            {
                switch (obj["key"].ToString())
                {
                    case "auto_speedtest":
                        returnObject.AutoSpeedTest = obj.ToObject<AutoSpeedtestSetting>();
                        break;
                    case "connectivity":
                        returnObject.Connectivity = obj.ToObject<ConnectivitySetting>();
                        break;
                    case "country":
                        returnObject.Country = obj.ToObject<CountrySetting>();
                        break;
                    case "dpi":
                        returnObject.Dpi = obj.ToObject<DpiSetting>();
                        break;
                    case "guest_access":
                        returnObject.GuestAccess = obj.ToObject<GuestAccessSetting>();
                        break;
                    case "super_identity":
                        returnObject.Identity = obj.ToObject<IdentitySetting>();
                        break;
                    case "locale":
                        returnObject.Locale = obj.ToObject<LocaleSetting>();
                        break;
                    case "mgmt":
                        returnObject.Managememt = obj.ToObject<MgmtSetting>();
                        break;
                    case "ntp":
                        returnObject.Ntp = obj.ToObject<NtpSetting>();
                        break;
                    case "porta":
                        returnObject.Porta = obj.ToObject<PortaSetting>();
                        break;
                    case "radius":
                        returnObject.Radius = obj.ToObject<RadiusSetting>();
                        break;
                    case "rsyslogd":
                        returnObject.RsysLogd = obj.ToObject<RsyslogdSetting>();
                        break;
                    case "super_smtp":
                        returnObject.Smtp = obj.ToObject<SmtpSetting>();
                        break;
                    case "snmp":
                        returnObject.Snmp = obj.ToObject<SnmpSetting>();
                        break;
                    case "super_mgmt":
                        returnObject.SuperManagement = obj.ToObject<SuperMgmtSetting>();
                        break;
                    case "usg":
                        returnObject.Usg = obj.ToObject<UsgSetting>();
                        break;
                    default:
                        returnObject.UnmappedObjects.Add(obj);
                        break;
                }
            }

            return new BaseResponse<SiteSettings>{Meta = response.Meta, Data = new List<SiteSettings>{ returnObject }};
        }

        /// <summary>
        /// delete a site.
        /// </summary>
        /// <param name="siteId">The site identifier.</param>
        /// <returns>return true on success</returns>
        public async Task<BoolResponse> DeleteSiteAsync(string siteId, string siteName = null)
        {
            var path = $"api/s/{(siteName ?? Site)}/cmd/sitemgr";
            var oJsonObject = new JObject();
            oJsonObject.Add("site", siteId);
            oJsonObject.Add("cmd", "delete-site");
            return await ExecuteBoolCommandAsync(path, oJsonObject);
        }

        /// <summary>
        /// Lists the sites stats.
        /// </summary>
        /// <returns>returns statistics for all sites hosted on this controller</returns>
        /// <exception cref="NotSupportedException">The controller version does not accept this request.</exception>
        [MinimumVersionRequired("5.2.9")]
        public async Task<BaseResponse<SiteStats>> ListSitesStatsAsync()
        {
            if (!Version.IsValid())
                throw new NotSupportedException("The controller version does not accept this request.");

            var path = $"api/stat/sites";

            var response = await ExecuteGetCommandAsync(path);
            return JsonConvert.DeserializeObject<BaseResponse<SiteStats>>(response.Result);
        }
        /// <summary>
        /// Toggle LEDs of all the access points ON or OFF
        /// </summary>
        /// <param name="enable">if set to <c>true</c> [enable]. true will switch LEDs of all the access points ON, false will switch them OFF</param>
        /// <param name="siteName">Name of the site.</param>
        /// <returns>returns <c>true</c> on success</returns>
        public async Task<BoolResponse> ToggleSiteLedsAsync(bool enable,string siteName = null)
        {
            var path = $"api/s/{(siteName ?? Site)}/set/setting/mgmt";
            var oJsonObject = new JObject();
            oJsonObject.Add("led_enabled", enable);
            return await ExecuteBoolCommandAsync(path, oJsonObject);
        }

        /// <summary>
        /// Sets the site SNMP.
        /// </summary>
        /// <param name="snmpId">The SNMP identifier.</param>
        /// <param name="setting">The setting.</param>
        /// <param name="siteName">Name of the site.</param>
        /// <returns>returns <c>true</c> on success.</returns>
        public async Task<BoolResponse> SetSiteSnmp(string snmpId, SnmpSetting setting, string siteName = null)
        {
            //TODO: Check if this is really needed. SetSiteSnmp will update the setting without the snmpId
            var path = $"api/s/{(siteName ?? Site)}/rest/setting/snmp/{snmpId}";
            var oJsonObject = JObject.FromObject(setting);
            return await ExecuteBoolCommandAsync(path, oJsonObject, "PUT");
        }

        /// <summary>
        /// Sets the site SNMP.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <param name="siteName">Name of the site.</param>
        /// <returns>returns <c>true</c> on success.</returns>
        public async Task<BoolResponse> SetSiteSnmpAsync(SnmpSetting setting, string siteName = null)
        {
            var path = $"api/s/{(siteName ?? Site)}/rest/setting/snmp/";
            var oJsonObject = JObject.FromObject(setting);
            return await ExecuteBoolCommandAsync(path, oJsonObject, "PUT");
        }

        /// <summary>
        /// Sets the site Management Settings
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <param name="siteName">Name of the site.</param>
        /// <returns>returns <c>true</c> on success</returns>
        public async Task<BoolResponse> SetSiteManagementAsync(MgmtSetting setting, string siteName = null)
        {
            throw new NotImplementedException();
            //TODO: FIX This. Currently returning "\napi.err.InvalidPayload"
            var path = $"api/s/{(siteName ?? Site)}/set/setting/mgmt";
            var oJsonObject = JObject.FromObject(setting);
            return await ExecuteBoolCommandAsync(path, oJsonObject, "PUT");
        }

        /// <summary>
        /// set site guest access.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <param name="siteName">Name of the site.</param>
        /// <returns>returns <c>true</c> on success</returns>
        public async Task<BoolResponse> SetSiteGuestAccessAsync(GuestAccessSetting setting, string siteName = null)
        {
            var path = $"api/s/{(siteName ?? Site)}/set/setting/guest_access";
            var oJsonObject = JObject.FromObject(setting);
            
            return await ExecuteBoolCommandAsync(path, oJsonObject, "PUT");
        }

        /// <summary>
        /// set site NTP.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <param name="siteName">Name of the site.</param>
        /// <returns>returns <c>true</c> on success</returns>
        public async Task<BoolResponse> SetSiteNtpAsync(NtpSetting setting, string siteName = null)
        {
            //TODO: Create Test
            var path = $"api/s/{(siteName ?? Site)}/set/setting/ntp";
            var oJsonObject = JObject.FromObject(setting);
            return await ExecuteBoolCommandAsync(path, oJsonObject, "PUT");
        }

        /// <summary>
        /// set site connectivity as an asynchronous operation.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <param name="siteName">Name of the site.</param>
        /// <returns>returns <c>true</c> on success</returns>
        public async Task<BoolResponse> SetSiteConnectivityAsync(ConnectivitySetting setting, string siteName = null)
        {
            //TODO: Create Test
            var path = $"api/s/{(siteName ?? Site)}/set/setting/connectivity";
            var oJsonObject = JObject.FromObject(setting);
            return await ExecuteBoolCommandAsync(path, oJsonObject, "PUT");
        }

        public async Task<BaseResponse<Admin>> ListSiteAdminsAsync(string siteName = null)
        {
            var path = $"api/s/{(siteName ?? Site)}/cmd/sitemgr";

            var oJsonObject = new JObject();
            oJsonObject.Add("cmd", "get-admins");

            var response = await ExecuteJsonCommandAsync(path, oJsonObject);
            return JsonConvert.DeserializeObject<BaseResponse<Admin>>(response.Result);
        }

        public async Task<BaseResponse<ControllerAdmins>> ListAllAdminsAsync(string siteName = null)
        {
            var path = $"api/stat/admin";

            var response = await ExecuteGetCommandAsync(path);
            return JsonConvert.DeserializeObject<BaseResponse<ControllerAdmins>>(response.Result);
        }

        public async Task<BoolResponse> InviteAdminAsync(string name, string email, bool enableSSO = true, bool readOnly = false, bool deviceAdopt = false, bool deviceRestart = false, string siteName = null)
        {
            var path = $"api/s/{(siteName ?? Site)}/cmd/sitemgr";
            var oJsonObject = new JObject();

            oJsonObject.Add("cmd", "invite-admin");
            oJsonObject.Add("email", email);
            oJsonObject.Add("name", name);
            oJsonObject.Add("for_sso", enableSSO);

            oJsonObject.Add("role", readOnly ? "readonly" : "admin");

            var permissions = new List<string>();
                if (deviceAdopt)
                    permissions.Add("API_DEVICE_ADOPT");

                if(deviceRestart)
                    permissions.Add("API_DEVICE_RESTART");

                
                    oJsonObject.Add("permissions", new JArray(permissions.ToArray()));

            //pending Devices
            //"API_STAT_DEVICE_ACCESS_SUPER_SITE_PENDING"
            var sitePermissions = new List<string>();

            
                oJsonObject.Add("super+site_permissions", new JArray(sitePermissions.ToArray()));

            return await ExecuteBoolCommandAsync(path, oJsonObject);
        }

    }
}