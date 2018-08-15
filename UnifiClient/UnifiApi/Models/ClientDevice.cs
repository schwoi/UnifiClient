using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnifiApi.Helpers;
namespace UnifiApi.Models
{
    public class ClientDevice
    {
        [JsonProperty(PropertyName = "_id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "_is_guest_by_uap")]
        public bool IsGuestByUap { get; set; }

        [JsonProperty(PropertyName = "_is_guest_by_ugw")]
        public bool IsGuestByUgw { get; set; }

        [JsonProperty(PropertyName = "_last_seen_by_uap")]
        public int LastSeenByUapSeconds { get; set; }
        public DateTime LastSeenByUap => LastSeenByUapSeconds.ToLocalDateTime();

        [JsonProperty(PropertyName = "_last_seen_by_ugw")]
        public int LastSeenByUgwSeconds { get; set; }

        public DateTime LastSeenByUgw => LastSeenByUgwSeconds.ToLocalDateTime();

        [JsonProperty(PropertyName = "_uptime_by_uap")]
        public int UptimeByUap { get; set; }

        [JsonProperty(PropertyName = "_uptime_by_ugw")]
        public int UptimeByUgw { get; set; }

        [JsonProperty(PropertyName = "ap_mac")]
        public string ApMac { get; set; }

        [JsonProperty(PropertyName = "assoc_time")]
        public int AssocTimeSeconds { get; set; }
        public DateTime AssocTime => AssocTimeSeconds.ToLocalDateTime();

        [JsonProperty(PropertyName = "authorized")]
        public bool Authorized { get; set; }

        [JsonProperty(PropertyName = "bssid")]
        public string bssid { get; set; }

        [JsonProperty(PropertyName = "bytes_rate")]
        public int BytesRate { get; set; }

        [JsonProperty(PropertyName = "ccq")]
        public int Ccq { get; set; }

        [JsonProperty(PropertyName = "channel")]
        public int Channel { get; set; }

        [JsonProperty(PropertyName = "dpi_stats")]
        public List<DpiStat> DpiStats { get; set; }

        [JsonProperty(PropertyName = "dpi_stats_last_updated")]
        public int DpiStatsLastUpdatedSeconds { get; set; }
        public DateTime DpiStatsLastUpdated => DpiStatsLastUpdatedSeconds.ToLocalDateTime();

        [JsonProperty(PropertyName = "essid")]
        public string Essid { get; set; }

        [JsonProperty(PropertyName = "first_seen")]
        public int FirstSeenSeconds { get; set; }
        public DateTime FirstSeen => FirstSeenSeconds.ToLocalDateTime();

        [JsonProperty(PropertyName = "gw_mac")]
        public string GwMac { get; set; }

        [JsonProperty(PropertyName = "idletime")]
        public int IdleTime { get; set; }

        [JsonProperty(PropertyName = "ip")]
        public string Ip { get; set; }

        [JsonProperty(PropertyName = "is_guest")]
        public bool IsGuest { get; set; }

        [JsonProperty(PropertyName = "is_wired")]
        public bool IsWired { get; set; }

        [JsonProperty(PropertyName = "last_seen")]
        public int LastSeenSeconds { get; set; }
        public DateTime LastSeen => LastSeenSeconds.ToLocalDateTime();

        [JsonProperty(PropertyName = "latest_assoc_time")]
        public int LatestAssocTimeSeconds { get; set; }
        public DateTime LatestAssocTime => LatestAssocTimeSeconds.ToLocalDateTime();

        [JsonProperty(PropertyName = "mac")]
        public string Mac { get; set; }

        [JsonProperty(PropertyName = "network")]
        public string Network { get; set; }

        [JsonProperty(PropertyName = "network_id")]
        public string NetworkId { get; set; }

        [JsonProperty(PropertyName = "noise")]
        public int Noise { get; set; }

        [JsonProperty(PropertyName = "oui")]
        public string Oui { get; set; }

        [JsonProperty(PropertyName = "powersave_enabled")]
        public bool PowersaveEnabled { get; set; }

        [JsonProperty(PropertyName = "qos_policy_applied")]
        public bool QosPolicyApplied { get; set; }

        [JsonProperty(PropertyName = "radio")]
        public string Radio { get; set; }

        [JsonProperty(PropertyName = "radio_proto")]
        public string RadioProto { get; set; }

        [JsonProperty(PropertyName = "roam_count")]
        public int RoamCount { get; set; }

        [JsonProperty(PropertyName = "rssi")]
        public int Rssi { get; set; }

        [JsonProperty(PropertyName = "rx_bytes")]
        public long RxBytes { get; set; }

        [JsonProperty(PropertyName = "rx_bytes-r")]
        public int RxBytesRate { get; set; }

        [JsonProperty(PropertyName = "rx_packets")]
        public int RxPackets { get; set; }

        [JsonProperty(PropertyName = "rx_rate")]
        public int RxRate { get; set; }

        [JsonProperty(PropertyName = "signal")]
        public int Signal { get; set; }

        [JsonProperty(PropertyName = "site_id")]
        public string SiteId { get; set; }

        [JsonProperty(PropertyName = "tx_bytes")]
        public long TxBytes { get; set; }

        [JsonProperty(PropertyName = "tx_bytes-r")]
        public int TxBytesRate { get; set; }

        [JsonProperty(PropertyName = "tx_packets")]
        public int TxPackets { get; set; }

        [JsonProperty(PropertyName = "tx_power")]
        public int TxPower { get; set; }

        [JsonProperty(PropertyName = "tx_rate")]
        public int TxRate { get; set; }

        [JsonProperty(PropertyName = "uptime")]
        public int UpTime { get; set; }

        [JsonProperty(PropertyName = "user_id")]
        public string UserId { get; set; }

        [JsonProperty(PropertyName = "vlan")]
        public int Vlan { get; set; }

        [JsonProperty(PropertyName = "hostname")]
        public string Hostname { get; set; }


        [JsonProperty(PropertyName = "os_class")]
        public int? os_class { get; set; }

        [JsonProperty(PropertyName = "os_name")]
        public int? OsName { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "noted")]
        public bool? Noted { get; set; }

        [JsonProperty(PropertyName = "usergroup_id")]
        public string UsergroupId { get; set; }
    }

}
