using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnifiApi.Helpers;

namespace UnifiApi.Models
{
    public class ControllerAdmins
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty("email_alert_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EmailAlertEnabled { get; set; }

        [JsonProperty("email_alert_grouping_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EmailAlertGroupingEnabled { get; set; }

        [JsonProperty("html_email_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HtmlEmailEnabled { get; set; }

        [JsonProperty("is_professional_installer", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsProfessionalInstaller { get; set; }

        [JsonProperty("is_super")]
        public bool IsSuper { get; set; }

        [JsonProperty("is_verified")]
        public bool IsVerified { get; set; }

        [JsonProperty("last_site_name")]
        public string LastSiteName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("requires_new_password")]
        public bool RequiresNewPassword { get; set; }

        [JsonProperty("roles")]
        public List<Role> Roles { get; set; }

        [JsonProperty("super_roles")]
        public List<Role> SuperRoles { get; set; }

        [JsonProperty("time_created")]
        public long TimeCreated { get; set; }

        //TODO: Check what this is and the best way to handle it.
        //[JsonProperty("ui_settings", NullValueHandling = NullValueHandling.Ignore)]
        //public UiSettings UiSettings { get; set; }

        [JsonProperty("x_shadow")]
        public string XShadow { get; set; }

    }
    public class Role
    {
        [JsonProperty("permissions")]
        public List<string> Permissions { get; set; }

        [JsonProperty("role")]
        public string RoleRole { get; set; }

        [JsonProperty("site_desc", NullValueHandling = NullValueHandling.Ignore)]
        public string SiteDesc { get; set; }

        [JsonProperty("site_id")]
        public string SiteId { get; set; }

        [JsonProperty("site_name")]
        public string SiteName { get; set; }
    }
}
