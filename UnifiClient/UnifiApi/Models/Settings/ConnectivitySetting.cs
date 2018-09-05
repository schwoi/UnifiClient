using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace UnifiApi.Models
{
    public class ConnectivitySetting : BaseSetting
    {
        public ConnectivitySetting()
        {
            Key = "connectivity";
        }
        [JsonProperty("uplink_host")]
        public string UplinkHost { get; set; }

        [JsonProperty("uplink_type")]
        public string UplinkType { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }
}
