using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace UnifiApi.Models
{
    public class DpiStat
    {
        [JsonProperty(PropertyName = "app")]
        public int App { get; set; }

        [JsonProperty(PropertyName = "cat")]
        public int Cat { get; set; }

        [JsonProperty(PropertyName = "rx_bytes")]
        public long RxBytes { get; set; }

        [JsonProperty(PropertyName = "rx_packets")]
        public int RxPackets { get; set; }

        [JsonProperty(PropertyName = "tx_bytes")]
        public long TxBytes { get; set; }

        [JsonProperty(PropertyName = "tx_packets")]
        public int TxPackets { get; set; }
    }
}
