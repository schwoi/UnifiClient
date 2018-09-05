using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace UnifiApi.Models
{
    public class DpiSetting : BaseSetting
    {
        public DpiSetting()
        {
            Key = "dpi";
        }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }
}
