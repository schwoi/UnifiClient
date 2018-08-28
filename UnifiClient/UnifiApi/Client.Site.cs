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
        /// List sites
        /// </summary>
        /// <returns>returns a list sites hosted on this controller with some details</returns>
        public async Task<BaseResponse<Site>> ListSitesAsync()
        {
            var path = $"api/self/sites";

            var response = await ExecuteGetCommandAsync(path);
            return JsonConvert.DeserializeObject<BaseResponse<Site>>(response.Result);
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
        /// Lists the site settings.
        /// </summary>
        /// <param name="siteName">Name of the site to list the settings for.</param>
        /// <returns>returns Site Object</returns>
        public async Task<BaseResponse<Site>> ListSiteSettingsAsync(string siteName = null)
        {
            var path = $"api/s/{(siteName ?? Site)}/get/setting";
            var response = await ExecuteGetCommandAsync(path);
            return JsonConvert.DeserializeObject<BaseResponse<Site>>(response.Result);
        }

        /// <summary>
        /// delete a site.
        /// </summary>
        /// <param name="siteId">The site identifier.</param>
        /// <returns>return true on success</returns>
        public async Task<BoolResponse> DeleteSiteAsync(string siteId)
        {
            var path = $"api/s/{Site}/cmd/sitemgr";
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
        /// <returns>returns <c>true</c> on success</returns>
        public async Task<BoolResponse> ToggleSiteLedsAsync(bool enable)
        {
            var path = $"api/s/{Site}/set/setting/mgmt";
            var oJsonObject = new JObject();
            oJsonObject.Add("led_enabled", enable);
            return await ExecuteBoolCommandAsync(path, oJsonObject);
        }
    }
}