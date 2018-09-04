using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace UnifiApi.Models
{
    public class RadiusSetting : BaseSetting
    {
        public RadiusSetting()
        {
            Key = "radius";
        }
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("acct_port")]
        public long AcctPort { get; set; }

        [JsonProperty("auth_port")]
        public long AuthPort { get; set; }

        [JsonProperty("configure_whole_network")]
        public bool ConfigureWholeNetwork { get; set; }

        [JsonProperty("interim_update_interval")]
        public long InterimUpdateInterval { get; set; }


        [JsonProperty("tunneled_reply")]
        public bool TunneledReply { get; set; }

        [JsonProperty("x_secret")]
        public string XSecret { get; set; }
    }
}
