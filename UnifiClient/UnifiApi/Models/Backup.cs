using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using UnifiApi.Helpers;

namespace UnifiApi.Models
{
    public class Backup
    {
        [JsonProperty("datetime")]
        public DateTimeOffset DateTimeUtc { get; set; }

        [JsonProperty("days")]
        public long Days { get; set; }

        [JsonProperty("filename")]
        public string Filename { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("time")]
        internal long TimeMilliseconds { get; set; }

        [JsonIgnore]
        public DateTime DateTimeLocal => TimeMilliseconds.ToLocalDateTime();

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
