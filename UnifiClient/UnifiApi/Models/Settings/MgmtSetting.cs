using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace UnifiApi.Models
{
    public class MgmtSetting : BaseSetting
    {
        public MgmtSetting()
        {
            Key = "mgmt";
        }
        [JsonProperty("advanced_feature_enabled")]
        public bool AdvancedFeatureEnabled { get; set; }

        [JsonProperty("alert_enabled")]
        public bool AlertEnabled { get; set; }

        [JsonProperty("auto_upgrade")]
        public bool AutoUpgrade { get; set; }

        [JsonProperty("auto_upgrade_phone")]
        public bool AutoUpgradePhone { get; set; }

        [JsonProperty("led_enabled")]
        public bool LedEnabled { get; set; }

        [JsonProperty("unifi_idp_enabled")]
        public bool UnifiIdpEnabled { get; set; }

        [JsonProperty("x_mgmt_key")]
        public string MgmtKey { get; set; }

        [JsonProperty("x_ssh_auth_password_enabled")]
        public bool SshAuthPasswordEnabled { get; set; }

        [JsonProperty("x_ssh_bind_wildcard")]
        public bool SshBindWildcard { get; set; }

        [JsonProperty("x_ssh_enabled")]
        public bool SshEnabled { get; set; }

        [JsonProperty("x_ssh_md5passwd")]
        public string SshMd5Passwd { get; set; }

        [JsonProperty("x_ssh_password")]
        public string SshPassword { get; set; }

        [JsonProperty("x_ssh_sha512passwd")]
        public string SshSha512Passwd { get; set; }

        [JsonProperty("x_ssh_username")]
        public string SshUsername { get; set; }
    }
}
