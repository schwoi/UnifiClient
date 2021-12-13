using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using static UnifiApi.Models.Enumerations;

namespace UnifiApi.Models
{
    public class WLan
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("x_iapp_key")]
        public string XIappKey { get; set; }

        [JsonProperty("wpa_mode")]
        public WPAMode WpaMode { get; set; }

        [JsonProperty("minrate_na_advertising_rates")]
        public bool MinrateNaAdvertisingRates { get; set; }

        [JsonProperty("dtim_na")]
        public long DtimNa { get; set; }

        [JsonProperty("is_guest", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsGuest { get; set; }

        [JsonProperty("minrate_na_enabled")]
        public bool MinrateNaEnabled { get; set; }

        [JsonProperty("minrate_ng_advertising_rates")]
        public bool MinrateNgAdvertisingRates { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("mac_filter_policy")]
        public string MacFilterPolicy { get; set; }

        [JsonProperty("security")]
        public SecurityType Security { get; set; }

        [JsonProperty("wep_idx")]
        public long WepIdx { get; set; }

        [JsonProperty("group_rekey")]
        public long GroupRekey { get; set; }

        [JsonProperty("minrate_ng_enabled")]
        public bool MinrateNgEnabled { get; set; }

        [JsonProperty("minrate_ng_data_rate_kbps")]
        public long MinrateNgDataRateKbps { get; set; }

        [JsonProperty("wpa_enc", NullValueHandling = NullValueHandling.Ignore)]
        public WPAEncryption WpaEnc { get; set; }

        [JsonProperty("bc_filter_enabled")]
        public bool BcFilterEnabled { get; set; }

        [JsonProperty("minrate_na_beacon_rate_kbps", NullValueHandling = NullValueHandling.Ignore)]
        public long? MinrateNaBeaconRateKbps { get; set; }

        [JsonProperty("usergroup_id")]
        public string UsergroupId { get; set; }

        [JsonProperty("mac_filter_list")]
        public List<object> MacFilterList { get; set; }

        [JsonProperty("minrate_na_mgmt_rate_kbps")]
        public long MinrateNaMgmtRateKbps { get; set; }

        [JsonProperty("dtim_mode")]
        public string DtimMode { get; set; }

        [JsonProperty("schedule")]
        public List<object> Schedule { get; set; }

        [JsonProperty("minrate_ng_beacon_rate_kbps")]
        public long MinrateNgBeaconRateKbps { get; set; }

        [JsonProperty("minrate_ng_mgmt_rate_kbps")]
        public long MinrateNgMgmtRateKbps { get; set; }

        [JsonProperty("bc_filter_list")]
        public List<object> BcFilterList { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("site_id")]
        public string SiteId { get; set; }

        [JsonProperty("minrate_na_data_rate_kbps")]
        public long MinrateNaDataRateKbps { get; set; }

        [JsonProperty("mac_filter_enabled")]
        public bool MacFilterEnabled { get; set; }

        [JsonProperty("dtim_ng")]
        public long DtimNg { get; set; }

        [JsonProperty("minrate_ng_cck_rates_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? MinrateNgCckRatesEnabled { get; set; }

        [JsonProperty("x_passphrase", NullValueHandling = NullValueHandling.Ignore)]
        public string Passphrase { get; set; }

        [JsonProperty("no2ghz_oui")]
        public bool No2GhzOui { get; set; }

        [JsonProperty("pmf_mode", NullValueHandling = NullValueHandling.Ignore)]
        public string PmfMode { get; set; }

        [JsonProperty("b_supported")]
        public bool BSupported { get; set; }

        [JsonProperty("ap_group_ids")]
        public List<string> ApGroupIds { get; set; }

        [JsonProperty("wlan_band")]
        public string WlanBand { get; set; }

        [JsonProperty("networkconf_id", NullValueHandling = NullValueHandling.Ignore)]
        public string NetworkconfId { get; set; }

        [JsonProperty("iapp_enabled")]
        public bool IappEnabled { get; set; }

        [JsonProperty("hide_ssid", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HideSsid { get; set; }

        [JsonProperty("schedule_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ScheduleEnabled { get; set; }

        [JsonProperty("uapsd_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? UapsdEnabled { get; set; }

        [JsonProperty("x_wep", NullValueHandling = NullValueHandling.Ignore)]
        public string XWep { get; set; }

        [JsonProperty("mcastenhance_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? McastenhanceEnabled { get; set; }

        [JsonProperty("fast_roaming_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FastRoamingEnabled { get; set; }

        [JsonProperty("radiusprofile_id", NullValueHandling = NullValueHandling.Ignore)]
        public string RadiusprofileId { get; set; }

        [JsonProperty("radius_mac_auth_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RadiusMacAuthEnabled { get; set; }

        [JsonProperty("radius_macacl_format", NullValueHandling = NullValueHandling.Ignore)]
        public string RadiusMacaclFormat { get; set; }

        [JsonProperty("radius_macacl_empty_password", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RadiusMacaclEmptyPassword { get; set; }

        [JsonProperty("radius_das_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RadiusDasEnabled { get; set; }
    }
}
