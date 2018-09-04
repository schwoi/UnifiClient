using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace UnifiApi.Models
{
    public class CountrySetting : BaseSetting
    {
        public CountrySetting()
        {
            Key = "country";
        }
     
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public long? Code { get; set; }
    }
}
