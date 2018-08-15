using Newtonsoft.Json;

namespace UnifiApi.Models
{
    public class Guest
    {
        [JsonProperty(PropertyName = "_id")]
        public string _id { get; set; }

        [JsonProperty(PropertyName = "authorized_by")]
        public string AuthorizedBy { get; set; }

        [JsonProperty(PropertyName = "end")]
        public int End { get; set; }

        [JsonProperty(PropertyName = "expired")]
        public bool Expired { get; set; }

        [JsonProperty(PropertyName = "mac")]
        public string Mac { get; set; }

        [JsonProperty(PropertyName = "site_id")]
        public string SiteId { get; set; }

        [JsonProperty(PropertyName = "start")]
        public int Start { get; set; }

        [JsonProperty(PropertyName = "unauthorized_by")]
        public string UnauthorizedBy { get; set; }

        [JsonProperty(PropertyName = "ap_mac")]
        public string ApMac { get; set; }

        [JsonProperty(PropertyName = "bytes")]
        public int? Bytes { get; set; }

        [JsonProperty(PropertyName = "channel")]
        public int? Channel { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public int? Duration { get; set; }

        [JsonProperty(PropertyName = "ip")]
        public string Ip { get; set; }

        [JsonProperty(PropertyName = "radio")]
        public string Radio { get; set; }

        [JsonProperty(PropertyName = "roam_count")]
        public int? RoamCount { get; set; }

        [JsonProperty(PropertyName = "rx_bytes")]
        public int? RxBytes { get; set; }

        [JsonProperty(PropertyName = "tx_bytes")]
        public int? TxBytes { get; set; }
        
    }
}
