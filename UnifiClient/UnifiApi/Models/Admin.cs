using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnifiApi.Helpers;

namespace UnifiApi.Models
{
    public class Admin
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("is_super")]
        public bool IsSuper { get; set; }

        [JsonProperty("is_verified")]
        public bool IsVerified { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("permissions")]
        public List<string> Permissions { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("super_site_permissions")]
        public List<string> SuperSitePermissions { get; set; }

        [JsonProperty("super_site_role")]
        public string SuperSiteRole { get; set; }

        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty("email_alert_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EmailAlertEnabled { get; set; }

        [JsonProperty("email_alert_grouping_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EmailAlertGroupingEnabled { get; set; }

        [JsonProperty("is_professional_installer", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsProfessionalInstaller { get; set; }

    }
}
