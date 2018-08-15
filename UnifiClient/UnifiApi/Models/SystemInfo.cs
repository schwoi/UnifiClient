using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnifiApi.Models
{
    public class SystemInfo
    {
        [JsonProperty(PropertyName = "autobackup")]
        public bool AutoBackup { get; set; }

        [JsonProperty(PropertyName = "build")]
        public string Build { get; set; }

        [JsonProperty(PropertyName = "data_retention_days")]
        public int DataRetentionDays { get; set; }

        [JsonProperty(PropertyName = "debug_device")]
        public string DebugDevice { get; set; }

        [JsonProperty(PropertyName = "debug_mgmt")]
        public string DebugMgmt { get; set; }

        [JsonProperty(PropertyName = "debug_sdn")]
        public string DebugSdn { get; set; }

        [JsonProperty(PropertyName = "debug_system")]
        public string DebugSystem { get; set; }

        [JsonProperty(PropertyName = "google_maps_api_key")]
        public string GoogleMapsApiKey { get; set; }

        [JsonProperty(PropertyName = "hostname")]
        public string Hostname { get; set; }

        [JsonProperty(PropertyName = "image_maps_use_google_engine")]
        public bool ImageMapsUseGoogleEngine { get; set; }

        [JsonProperty(PropertyName = "inform_port")]
        public int InformPort { get; set; }

        [JsonProperty(PropertyName = "ip_addrs")]
        public List<string> IpAddresses { get; set; }

        [JsonProperty(PropertyName = "live_chat")]
        public string LiveChat { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "override_inform_host")]
        public bool OverrideInformHost { get; set; }

        [JsonProperty(PropertyName = "timezone")]
        public string Timezone { get; set; }

        [JsonProperty(PropertyName = "unifi_go_enabled")]
        public bool UnifiGoEnabled { get; set; }

        [JsonProperty(PropertyName = "update_available")]
        public bool UpdateAvailable { get; set; }

        [JsonProperty(PropertyName = "update_downloaded")]
        public bool UpdateDownloaded { get; set; }

        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }
    }
}
