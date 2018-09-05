using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace UnifiApi.Models
{
    public class PortaSetting : BaseSetting
    {
        public PortaSetting()
        {
            Key = "porta";
        }

        [JsonProperty("ugw3_wan2_enabled")]
        public bool Ugw3Wan2Enabled { get; set; }
    }
}
