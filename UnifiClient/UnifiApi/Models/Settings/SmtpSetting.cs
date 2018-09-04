using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace UnifiApi.Models
{
    public class SmtpSetting : BaseSetting
    {
        public SmtpSetting()
        {
            Key = "super_smtp";
        }
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("port")]
        public long Port { get; set; }

        [JsonProperty("sender")]
        public string Sender { get; set; }

        [JsonProperty("use_auth")]
        public bool UseAuth { get; set; }

        [JsonProperty("use_sender")]
        public bool UseSender { get; set; }

        [JsonProperty("use_ssl")]
        public bool UseSsl { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("x_password")]
        public string XPassword { get; set; }
    }
}
