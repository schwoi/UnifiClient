using System;
using Newtonsoft.Json;
using UnifiApi.Helpers;

namespace UnifiApi.Models
{
    public class DashboardMetric
    {
        [JsonProperty(PropertyName = "time")]
        public long TimeSeconds { get; set; }
        public DateTime Time => TimeSeconds.ToLocalDateTime();

        [JsonProperty(PropertyName = "rx_bytes-r")]
        public long? RxBytes { get; set; }

        [JsonProperty(PropertyName = "tx_bytes-r")]
        public long? TxBytes { get; set; }

    }
}
