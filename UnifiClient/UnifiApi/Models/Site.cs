using Newtonsoft.Json;
using System.Collections.Generic;

namespace UnifiApi.Models
{
    public class Site
    {
       
        [JsonProperty(PropertyName = "_id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "desc")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "role")]
        public string Role { get; set; }
    }


}
