using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace UnifiApi.Models
{
    public class DeviceTags
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("member_table")]
        public List<string> MemberTable { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("site_id")]
        public string SiteId { get; set; }
    
}

}
