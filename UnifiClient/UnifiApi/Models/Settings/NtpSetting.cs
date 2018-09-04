using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace UnifiApi.Models
{
    public class NtpSetting : BaseSetting
    {
        public NtpSetting()
        {
            Key = "ntp";
        }

        [JsonProperty("ntp_server_1")]
        public string NtpServer1 { get; set; }
        [JsonProperty("ntp_server_2")]
        public string NtpServer2 { get; set; }
        [JsonProperty("ntp_server_3")]
        public string NtpServer3 { get; set; }
        [JsonProperty("ntp_server_4")]
        public string NtpServer4 { get; set; }
    }
}
