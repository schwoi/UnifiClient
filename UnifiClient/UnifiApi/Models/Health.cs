using System;
using Newtonsoft.Json;
using UnifiApi.Helpers;

namespace UnifiApi.Models
{
    public class Health
    {
        [JsonProperty(PropertyName = "num_adopted")]
        public int Adopted { get; set; }

        [JsonProperty(PropertyName = "num_ap")]
        public int AccessPoints { get; set; }

        [JsonProperty(PropertyName = "num_disabled")]
        public int Disabled { get; set; }

        [JsonProperty(PropertyName = "num_disconnected")]
        public int Disconnected { get; set; }

        [JsonProperty(PropertyName = "num_pending")]
        public int Pending { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "subsystem")]
        public string SubSystem { get; set; }

        [JsonProperty(PropertyName = "num_gw")]
        public int? Gateways { get; set; }

        [JsonProperty(PropertyName = "num_sw")]
        public int? Switches { get; set; }


    }
}
