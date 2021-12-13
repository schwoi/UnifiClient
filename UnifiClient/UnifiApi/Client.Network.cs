using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnifiApi.Helpers;
using UnifiApi.Models;
using UnifiApi.Responses;
using static UnifiApi.Models.Enumerations;

namespace UnifiApi
{
    public partial class Client
    {
        /// <summary>
        /// Get a list of non-wireless networks and their settings
        /// </summary>
        /// <param name="networkId">id value of the network to fetch the settings. (Optional)</param>
        /// <returns>List WLan</returns>
        public async Task<BaseResponse<Network>> ListNetworksAsync(string networkId = null)
        {
            var path = $"api/s/{Site}/rest/networkconf/{networkId}";
            
            var response = await ExecuteGetCommandAsync(path);
            return JsonConvert.DeserializeObject<BaseResponse<Network>>(response.Result);
        }
    }
}