using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnifiApi.Models;
using UnifiApi.Responses;

namespace UnifiApi
{
    public partial class Client
    {
        #region Client Methods

        /// <summary>
        /// Blocks a client device.
        /// </summary>
        /// <param name="clientMac">The client MAC address.</param>
        /// <returns>BoolResponse.</returns>
        public async Task<BoolResponse> BlockClientAsync(string clientMac)
        {
            var path = $"api/s/{Site}/cmd/stamgr";

            var oJsonObject = new JObject();
            oJsonObject.Add("cmd", "block-sta");
            oJsonObject.Add("mac", clientMac);

            return await ExecuteBoolCommandAsync(path, oJsonObject);
        }

        /// <summary>
        /// Unblocks a client device.
        /// </summary>
        /// <param name="clientMac">The client MAC address.</param>
        /// <returns>BoolResponse.</returns>
        public async Task<BoolResponse> UnblockClientAsync(string clientMac)
        {
            var path = $"api/s/{Site}/cmd/stamgr";

            var oJsonObject = new JObject();
            oJsonObject.Add("cmd", "unblock-sta");
            oJsonObject.Add("mac", clientMac);

            return await ExecuteBoolCommandAsync(path, oJsonObject);
        }

        /// <summary>
        /// Get details for a single client device
        /// </summary>
        /// <param name="clientMac">The client MAC Address.</param>
        /// <returns>returns an object with the client device information</returns>
        public async Task<BaseResponse<ClientDevice>> ClientDetailsAsync(string clientMac)
        {
            var path = $"api/s/{Site}/stat/user/{clientMac}";

            var oJsonObject = new JObject();

            var response = await ExecuteJsonCommandAsync(path, oJsonObject);
            return JsonConvert.DeserializeObject<BaseResponse<ClientDevice>>(response.Result);
        }

        /// <summary>
        /// Show latest 'n' login sessions for a single client device
        /// </summary>
        /// <param name="clientMac">Client MAC address</param>
        /// <param name="limit">maximum number of sessions to get (default value is 5)</param>
        /// <returns>returns an array of latest login session objects for given client device</returns>
        public async Task<BaseResponse<ClientLogin>> ShowClientLoginsAsync(string clientMac, int? limit = null)
        {
            var path = $"api/s/{Site}/stat/session";

            var oJsonObject = new JObject();
            oJsonObject.Add("mac", clientMac);
            oJsonObject.Add("_limit", limit == null ? 5 : limit);
            oJsonObject.Add("_sort", "-assoc_time");

            var response = await ExecuteJsonCommandAsync(path, oJsonObject);
            var records = JsonConvert.DeserializeObject<BaseResponse<ClientLogin>>(response.Result);
            return records; // response;
        }

        /// <summary>
        /// List online client device(s)
        /// </summary>
        /// <param name="clientMac">Client MAC address</param>
        /// <returns>returns an array of online client device objects, or in case of a single device request, returns a single client device object.</returns>
        public async Task<BaseResponse<UnifiClient>> ListOnlineClientsAsync(string clientMac = "")
        {
            var path = $"api/s/{Site}/stat/sta/{clientMac}";

            var oJsonObject = new JObject();

            var response = await ExecuteJsonCommandAsync(path, oJsonObject);
            var records = JsonConvert.DeserializeObject<BaseResponse<UnifiClient>>(response.Result);
            return records;
        }

        /// <summary>
        /// List all client devices ever connected to the site.
        /// </summary>
        /// <remarks>
        /// within is only used to select clients that were online within that period,
        /// the returned stats per client are all-time totals, irrespective of the value of within
        /// </remarks>
        /// <param name="within">hours to go back (default is 8760 hours or 1 year)</param>
        /// <returns>returns an array of client device objects</returns>
        public async Task<BaseResponse<ClientList>> ListAllClientsAsync(int within = 8760)
        {
            var path = $"api/s/{Site}/stat/alluser";

            var oJsonObject = new JObject();
            oJsonObject.Add("type", "all");
            oJsonObject.Add("conn", "all");
            oJsonObject.Add("within", within);

            var response = await ExecuteJsonCommandAsync(path, oJsonObject);
            return JsonConvert.DeserializeObject<BaseResponse<ClientList>>(response.Result);
        }

        /// <summary>
        /// Lists the known clients.
        /// </summary>
        /// <returns>returns a list of known client device</returns>
        public async Task<BaseResponse<ClientList>> ListKnownClientsAsync()
        {
            var path = $"api/s/{Site}/list/user";

            var response = await ExecuteGetCommandAsync(path);
            return JsonConvert.DeserializeObject<BaseResponse<ClientList>>(response.Result);
        }

        /// <summary>
        /// Add or Modify a client device note.
        /// </summary>
        /// <param name="clientMac">The client mac.</param>
        /// <param name="note">The note.</param>
        /// <returns>BoolResponse.</returns>
        /// <remarks>When note is empty or not set, the existing note for the user will be removed and "noted" attribute set to false</remarks>
        public async Task<BoolResponse> AddClientNoteAsync(string clientMac, string note = "")
        {
            return await SetClientNoteAsync(clientMac, note);
        }

        /// <summary>
        /// Removes the client note.
        /// </summary>
        /// <param name="clientMac">The client mac.</param>
        /// <returns>BoolResponse.</returns>
        public async Task<BoolResponse> RemoveClientNoteAsync(string clientMac)
        {
            return await SetClientNoteAsync(clientMac, "");
        }

        /// <summary>
        /// Add/modify/remove a client device note.
        /// </summary>
        /// <param name="clientMac">The client mac.</param>
        /// <param name="note">The note to be applied to the user device.</param>
        /// <returns>BoolResponse.</returns>
        /// <remarks>When note is empty or not set, the existing note for the user will be removed and "noted" attribute set to false</remarks>
        public async Task<BoolResponse> SetClientNoteAsync(string clientMac, string note)
        {
            var path = $"api/s/{Site}/upd/user/{clientMac}";

            var oJsonObject = new JObject();
            oJsonObject.Add("note", note);
            oJsonObject.Add("noted", !string.IsNullOrEmpty(note));

            return await ExecuteBoolCommandAsync(path, oJsonObject);
        }

        #endregion
    }
}