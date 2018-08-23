using System.Threading.Tasks;
using Newtonsoft.Json;
using UnifiApi.Models;
using UnifiApi.Responses;

namespace UnifiApi
{
    public partial class Client
    {
        #region Stat Methods

        /// <summary>
        /// list health metrics.
        /// </summary>
        /// <returns>returns an array of health metrics</returns>
        public async Task<BaseResponse<Health>> ListHealthAsync()
        {
            var path = $"/api/s/{Site}/stat/health";

            var response = await ExecuteGetCommandAsync(path);
            return JsonConvert.DeserializeObject<BaseResponse<Health>>(response.Result);
        }

        public async Task<BaseResponse<DashboardMetric>> ListDashboardAsync(bool fiveMinScale = false)
        {
            var path = $"/api/s/{Site}/stat/dashboard{(fiveMinScale ? "?scale=5minutes" : "")}";

            var response = await ExecuteGetCommandAsync(path);
            return JsonConvert.DeserializeObject<BaseResponse<DashboardMetric>>(response.Result);
        }

        #endregion
    }
}