using System;
using Newtonsoft.Json;
using UnifiApi.Helpers;

namespace UnifiApi.Models
{
    public class Voucher
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("site_id")]
        public string SiteId { get; set; }

        [JsonProperty("create_time")]
        public long CreateTime { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("for_hotspot")]
        public bool ForHotspot { get; set; }

        [JsonProperty("admin_name")]
        public string AdminName { get; set; }

        [JsonProperty("quota")]
        public long Quota { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("used")]
        public long Used { get; set; }

        [JsonProperty("qos_overwrite")]
        public bool QosOverwrite { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("status_expires")]
        public long StatusExpires { get; set; }

    }
}
