using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnifiApi.Helpers;
namespace UnifiApi.Models
{
    public class CountryCode
    {
            [JsonProperty("code")]
            public long Code { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        
    }

}
