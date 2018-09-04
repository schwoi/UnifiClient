using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace UnifiApi.Models
{
    public class SuperMgmtSetting : BaseSetting
    {
        public SuperMgmtSetting()
        {
            Key = "super_mgmt";
        }
        [JsonProperty("autobackup_cron_expr")]
        public string AutobackupCronExpr { get; set; }

        [JsonProperty("autobackup_days")]
        public long AutobackupDays { get; set; }

        [JsonProperty("autobackup_enabled")]
        public bool AutobackupEnabled { get; set; }

        [JsonProperty("autobackup_max_files")]
        public long AutobackupMaxFiles { get; set; }

        [JsonProperty("autobackup_timezone")]
        public string AutobackupTimezone { get; set; }

        [JsonProperty("data_retention_time_enabled")]
        public bool DataRetentionTimeEnabled { get; set; }

        [JsonProperty("data_retention_time_in_hours_for_5minutes_scale")]
        public long DataRetentionTimeInHoursFor5MinutesScale { get; set; }

        [JsonProperty("data_retention_time_in_hours_for_daily_scale")]
        public long DataRetentionTimeInHoursForDailyScale { get; set; }

        [JsonProperty("data_retention_time_in_hours_for_hourly_scale")]
        public long DataRetentionTimeInHoursForHourlyScale { get; set; }

        [JsonProperty("data_retention_time_in_hours_for_monthly_scale")]
        public long DataRetentionTimeInHoursForMonthlyScale { get; set; }

        [JsonProperty("data_retention_time_in_hours_for_others")]
        public long DataRetentionTimeInHoursForOthers { get; set; }

        [JsonProperty("discoverable")]
        public bool Discoverable { get; set; }

        [JsonProperty("google_maps_api_key")]
        public string GoogleMapsApiKey { get; set; }

        [JsonProperty("image_maps_use_google_engine")]
        public bool ImageMapsUseGoogleEngine { get; set; }

        [JsonProperty("live_chat")]
        public string LiveChat { get; set; }

        [JsonProperty("store_enabled")]
        public string StoreEnabled { get; set; }

        [JsonProperty("time_series_per_client_stats_enabled")]
        public bool TimeSeriesPerClientStatsEnabled { get; set; }

        [JsonProperty("voip_image_cache_enabled")]
        public bool VoipImageCacheEnabled { get; set; }
    }
}
