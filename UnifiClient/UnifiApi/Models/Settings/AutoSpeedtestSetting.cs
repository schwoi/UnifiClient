using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace UnifiApi.Models
{
    public class AutoSpeedtestSetting : BaseSetting
    {
        public AutoSpeedtestSetting()
        {
            Key = "auto_speedtest";
        }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("interval")]
        public long Interval { get; set; }
    }
}
