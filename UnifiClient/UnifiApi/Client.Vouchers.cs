using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnifiApi.Models;
using UnifiApi.Responses;

namespace UnifiApi
{
    public partial class Client
    {
        #region Voucher Methods

        /// <summary>
        /// Create voucher(s).
        /// </summary>

        /// <param name="minutes">minutes the voucher is valid after activation (expiration time).</param>
        /// <param name="count">number of vouchers to create, default value is 1.</param>
        /// <param name="quota">single-use or multi-use vouchers, value '0' is for multi-use, '1' is for single-use, 'n' is for multi-use n times</param>
        /// <param name="uploadKbps">The upload limit KBPS.</param>
        /// <param name="downloadKbps">The download limit KBPS.</param>
        /// <param name="transferMb">The data transfer limit MB.</param>
        /// <param name="note">note text to add to voucher when printing.</param>
        /// <returns>List containing the create_time(stamp) of the voucher(s) created</returns>
        public async Task<BaseResponse<Voucher>> CreateVoucherAsync( int minutes, int count = 1, int quota = 0, int? uploadKbps = null,
            int? downloadKbps = null, int? transferMb = null, string note = null)
        {
            var path = $"api/s/{Site}/cmd/hotspot";

            var oJsonObject = new JObject();
            oJsonObject.Add("cmd", "create-voucher");
            oJsonObject.Add("n", count);
            oJsonObject.Add("expire", minutes);
            oJsonObject.Add("quota", quota);
            if (uploadKbps != null)
                oJsonObject.Add("up", uploadKbps);
            if (downloadKbps != null)
                oJsonObject.Add("down", downloadKbps);
            if (transferMb != null)
                oJsonObject.Add("bytes", transferMb);
            if (note != null)
                oJsonObject.Add("note", note);

            var response = await ExecuteJsonCommandAsync(path, oJsonObject);
            return JsonConvert.DeserializeObject<BaseResponse<Voucher>>(response.Result);
        }

        /// <summary>
        /// Revoke voucher
        /// </summary>
        /// <param name="voucherId">id of the voucher to revoke.</param>
        /// <returns>BoolResponse. true on success</returns>
        public async Task<BoolResponse> RevokeVoucherAsync(string voucherId)
        {
            var path = $"api/s/{Site}/cmd/stamgr";

            var oJsonObject = new JObject();
            oJsonObject.Add("cmd", "delete-voucher");
            oJsonObject.Add("_id", voucherId);

            return await ExecuteBoolCommandAsync(path, oJsonObject);

        }


        /// <summary>
        /// List vouchers
        /// </summary>
        /// <param name="createTime">create time of the vouchers to fetch in Unix timestamp in seconds</param>
        /// <returns>returns an list of voucher objects</returns>
        public async Task<BaseResponse<Voucher>> ListVouchersAsync(long? createTime = null)
        {
            var path = $"api/s/{Site}/stat/voucher";

            var oJsonObject = new JObject();
            if (createTime != null)
                oJsonObject.Add("create_time", createTime);

            var response = await ExecuteJsonCommandAsync(path, oJsonObject);

            return JsonConvert.DeserializeObject<BaseResponse<Voucher>>(response.Result);
        }

        #endregion
    }
}