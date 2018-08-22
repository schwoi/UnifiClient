using System;
using Newtonsoft.Json;
using UnifiApi.Helpers;

namespace UnifiApi.Models
{
    public class ClientList
    {
        [JsonProperty(PropertyName = "_id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public int Duration { get; set; }

        [JsonProperty(PropertyName = "first_seen")]
        public int FirstSeenSeconds { get; set; }
        public DateTime FirstSeen => FirstSeenSeconds.ToLocalDateTime();

        [JsonProperty(PropertyName = "fixed_ip")]
        public string FixedIp { get; set; }

        [JsonProperty(PropertyName = "hostname")]
        public string Hostname { get; set; }

        [JsonProperty(PropertyName = "is_guest")]
        public bool IsGuest { get; set; }

        [JsonProperty(PropertyName = "is_wired")]
        public bool IsWired { get; set; }

        [JsonProperty(PropertyName = "last_seen")]
        public int LastSeenSeconds { get; set; }
        public DateTime LastSeen => LastSeenSeconds.ToLocalDateTime();

        [JsonProperty(PropertyName = "mac")]
        public string Mac { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "network_id")]
        public string NetworkId { get; set; }

        [JsonProperty(PropertyName = "noted")]
        public bool Noted { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty(PropertyName = "oui")]
        public string Oui { get; set; }

        [JsonProperty(PropertyName = "rx_bytes")]
        public long RxBytes { get; set; }

        [JsonProperty(PropertyName = "rx_packets")]
        public Int64 RxPackets { get; set; }

        [JsonProperty(PropertyName = "site_id")]
        public string SiteId { get; set; }

        [JsonProperty(PropertyName = "tx_bytes")]
        public long TxBytes { get; set; }

        [JsonProperty(PropertyName = "tx_packets")]
        public Int64 TxPackets { get; set; }

        [JsonProperty(PropertyName = "use_fixedip")]
        public bool UseFixedIp { get; set; }

        [JsonProperty(PropertyName = "usergroup_id")]
        public string UsergroupId { get; set; }

        [JsonProperty("blocked")]
        public bool? Blocked { get; set; }

    }
}
