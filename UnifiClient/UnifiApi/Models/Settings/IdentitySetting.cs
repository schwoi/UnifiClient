using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace UnifiApi.Models
{
    public class IdentitySetting : BaseSetting
    {
        public IdentitySetting()
        {
            Key = "super_identity";
        }

        [JsonProperty("hostname")]
        public string Hostname { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
