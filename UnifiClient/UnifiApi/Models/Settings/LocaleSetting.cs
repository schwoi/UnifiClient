using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace UnifiApi.Models
{
    public class LocaleSetting : BaseSetting
    {
        public LocaleSetting()
        {
            Key = "locale";
        }

        [JsonProperty("timezone", NullValueHandling = NullValueHandling.Ignore)]
        public string Timezone { get; set; }
    }
}
