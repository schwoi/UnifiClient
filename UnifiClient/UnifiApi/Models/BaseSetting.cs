using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace UnifiApi.Models
{
    public class BaseSetting
    {
        [JsonIgnore]
        public string Id { get; set; }

        [JsonProperty("_id")]
        private string _id
        {
            set => Id = value;
        }

        [JsonProperty("key")]
        internal string Key { get; set; }

        [JsonProperty("site_id")]
        public string SiteId { get; set; }

    }
}
