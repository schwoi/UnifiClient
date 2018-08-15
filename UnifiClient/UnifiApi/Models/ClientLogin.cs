using System;
using Newtonsoft.Json;
using UnifiApi.Helpers;

namespace UnifiApi.Models
{
    public class ClientLogin
    {
        [JsonProperty(PropertyName = "_id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "ap_mac")]
        public string ApMacAddress { get; set; }
        [JsonProperty(PropertyName = "assoc_time")]
        public int AssocTimeSeconds { get; set; }
        public DateTime AssocTime => AssocTimeSeconds.ToLocalDateTime();

        [JsonProperty(PropertyName = "duration")]
        public int Duration { get; set; }
        [JsonProperty(PropertyName = "hostname")]
        public string Hostname { get; set; }
        [JsonProperty(PropertyName = "ip")]
        public string IpAddress { get; set; }
        [JsonProperty(PropertyName = "is_guest")]
        public bool IsGuest { get; set; }
        [JsonProperty(PropertyName = "is_wired")]
        public bool IsWired { get; set; }
        [JsonProperty(PropertyName = "mac")]
        public string MacAddress { get; set; }
        [JsonProperty(PropertyName = "name")]
        public object Name { get; set; }
        [JsonProperty(PropertyName = "o")]
        public string O { get; set; }
        [JsonProperty(PropertyName = "oid")]
        public string Oid { get; set; }
        [JsonProperty(PropertyName = "rx_bytes")]
        public long RxBytes { get; set; }
        [JsonProperty(PropertyName = "tx_bytes")]
        public long TxBytes { get; set; }
    }
}
