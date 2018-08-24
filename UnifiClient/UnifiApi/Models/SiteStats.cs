using Newtonsoft.Json;
using System.Collections.Generic;

namespace UnifiApi.Models
{
    public class SiteStats : Site
    {

        [JsonProperty("health")]
        public List<Health> Health { get; set; }

        [JsonProperty("num_new_alarms")]
        public long NumNewAlarms { get; set; }
    }


}
