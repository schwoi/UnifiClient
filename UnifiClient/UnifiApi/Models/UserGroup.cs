using Newtonsoft.Json;

namespace UnifiApi.Models
{
    public class UserGroup
    {
        [JsonProperty(PropertyName = "_id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "attr_hidden_id")]
        public string AttrHiddenId { get; set; }

        [JsonProperty(PropertyName = "attr_no_delete")]
        public bool AttrNoDelete { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "qos_rate_max_down")]
        public int QosRateMaxDown { get; set; }

        [JsonProperty(PropertyName = "qos_rate_max_up")]
        public int QosRateMaxUp { get; set; }

        [JsonProperty(PropertyName = "site_id")]
        public string SiteId { get; set; }
        
    }
}
