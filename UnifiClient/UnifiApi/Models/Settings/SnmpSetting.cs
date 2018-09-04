using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace UnifiApi.Models
{
    public class SnmpSetting : BaseSetting
    {
        public SnmpSetting()
        {
            Key = "snmp";
        }
        [JsonProperty("community")]
        public string Community { get; set; }
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }
}
