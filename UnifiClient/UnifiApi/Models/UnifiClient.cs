using Newtonsoft.Json;
using System.Collections.Generic;

namespace UnifiApi.Models
{
    public class UnifiClient : ClientDevice
    {
       
        [JsonProperty(PropertyName = "dev_cat")]
        public int? DevCat { get; set; }

        [JsonProperty(PropertyName = "dev_family")]
        public int? DevFamily { get; set; }

        [JsonProperty(PropertyName = "dev_id")]
        public int? DevId { get; set; }

        [JsonProperty(PropertyName = "dev_vendor")]
        public int? DevVendor { get; set; }
    }


}
