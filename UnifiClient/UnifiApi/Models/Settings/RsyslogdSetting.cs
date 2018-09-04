using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace UnifiApi.Models
{
    public class RsyslogdSetting : BaseSetting
    {
        public RsyslogdSetting()
        {
            Key = "rsyslogd";
        }
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("port")]
        public long Port { get; set; }

        [JsonProperty("debug")]
        public bool Debug { get; set; }

        [JsonProperty("ip")]
        public string Ip { get; set; }

    }
}
