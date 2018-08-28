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

        [JsonProperty("num_guest", NullValueHandling = NullValueHandling.Ignore)]
        public long? NumGuest { get; set; }

        [JsonProperty(PropertyName = "num_pending")]
        public int Pending { get; set; }

        [JsonProperty("num_user", NullValueHandling = NullValueHandling.Ignore)]
        public long? NumUser { get; set; }
        [JsonProperty("rx_bytes-r", NullValueHandling = NullValueHandling.Ignore)]
        public long? RxBytes { get; set; }
        [JsonProperty("tx_bytes-r", NullValueHandling = NullValueHandling.Ignore)]
        public long? TxBytes { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "subsystem")]
        public string SubSystem { get; set; }

        [JsonProperty("gw_mac", NullValueHandling = NullValueHandling.Ignore)]
        public string GatewayMac { get; set; }

        [JsonProperty("gw_version", NullValueHandling = NullValueHandling.Ignore)]
        public string GatewayVersion { get; set; }

        [JsonProperty("lan_ip")]
        public dynamic LanIp { get; set; }

        [JsonProperty(PropertyName = "num_gw")]
        public int? Gateways { get; set; }

        [JsonProperty(PropertyName = "num_sw")]
        public int? Switches { get; set; }


    }
}
