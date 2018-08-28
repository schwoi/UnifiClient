using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace UnifiApi.Models
{
    public class RougeAp
    {

        [JsonProperty("_id")] public string Id { get; set; }

        [JsonProperty("age")] public long Age { get; set; }

        [JsonProperty("ap_mac")] public string ApMac { get; set; }

        [JsonProperty("band")] public string Band { get; set; }

        [JsonProperty("bssid")] public string Bssid { get; set; }

        [JsonProperty("bw")] public long Bw { get; set; }

        [JsonProperty("center_freq")] public long CenterFreq { get; set; }

        [JsonProperty("channel")] public long Channel { get; set; }

        [JsonProperty("essid")] public string Essid { get; set; }

        [JsonProperty("freq")] public long Freq { get; set; }

        [JsonProperty("is_adhoc")] public bool IsAdhoc { get; set; }

        [JsonProperty("is_rogue")] public bool IsRogue { get; set; }

        [JsonProperty("is_ubnt")] public bool IsUbnt { get; set; }

        [JsonProperty("last_seen")] public long LastSeen { get; set; }

        [JsonProperty("ng-channel", NullValueHandling = NullValueHandling.Ignore)]
        public long? NgChannel { get; set; }

        [JsonProperty("noise")] public long Noise { get; set; }

        [JsonProperty("oui")] public string Oui { get; set; }

        [JsonProperty("radio")] public string Radio { get; set; }

        [JsonProperty("report_time")] public long ReportTime { get; set; }

        [JsonProperty("rssi")] public long Rssi { get; set; }

        [JsonProperty("rssi_age")] public long RssiAge { get; set; }

        [JsonProperty("security")] public string Security { get; set; }

        [JsonProperty("signal")] public long Signal { get; set; }

        [JsonProperty("site_id")] public string SiteId { get; set; }

        [JsonProperty("na-channel", NullValueHandling = NullValueHandling.Ignore)]
        public long? NaChannel { get; set; }

        [JsonProperty("is_default", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsDefault { get; set; }

        [JsonProperty("is_isolated", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsIsolated { get; set; }

        [JsonProperty("is_locating", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsLocating { get; set; }

        [JsonProperty("is_meshv3", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsMeshv3 { get; set; }

        [JsonProperty("is_unifi", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsUnifi { get; set; }

        [JsonProperty("is_vport", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsVport { get; set; }

        [JsonProperty("is_vwire", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsVwire { get; set; }

        [JsonProperty("mac", NullValueHandling = NullValueHandling.Ignore)]
        public string Mac { get; set; }

        [JsonProperty("model", NullValueHandling = NullValueHandling.Ignore)]
        public string Model { get; set; }

        [JsonProperty("model_display", NullValueHandling = NullValueHandling.Ignore)]
        public string ModelDisplay { get; set; }

        [JsonProperty("serialno", NullValueHandling = NullValueHandling.Ignore)]
        public string Serialno { get; set; }
    }
}