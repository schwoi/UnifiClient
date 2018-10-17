using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace UnifiApi.Responses
{

    public class Meta
    {
        [JsonProperty(PropertyName = "rc")]
        public string Rc { get; set; }

        [JsonProperty(PropertyName = "msg")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }

        [JsonProperty(PropertyName = "server_version")]
        public string ServerVersion { get; set; }

        [JsonProperty(PropertyName = "up")]
        public bool? Up { get; set; }

        [JsonProperty(PropertyName = "uuid")]
        public Guid Uuid { get; set; }
    }

    public class BaseResponse<T>
    {
        [JsonProperty(PropertyName = "data")]
        public List<T> Data { get; set; }
        [JsonProperty(PropertyName = "meta")]
        public Meta Meta { get; set; }
    }

    public class BaseResponse
    {
        [JsonProperty(PropertyName = "meta")]
        public Meta Meta { get; set; }
    }
}
