using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnifiApi.Models;
using UnifiApi.Responses;

namespace UnifiApi
{
    public partial class Client
    {
        #region Group Methods

        /// <summary>
        /// Create user group
        /// </summary>
        /// <param name="groupName">name of the user group</param>
        /// <param name="maxRateDown">limit download bandwidth in Kbps (default = -1, which sets bandwidth to unlimited)</param>
        /// <param name="maxRatepUp">limit upload bandwidth in Kbps (default = -1, which sets bandwidth to unlimited)</param>
        /// <returns>an array containing a single object with attributes of the new usergroup ("_id", "name", "qos_rate_max_down", "qos_rate_max_up", "site_id") on success</returns>
        public async Task<BaseResponse<UserGroup>> CreateUserGroupAsync(string groupName, int maxRateDown = -1,
            int maxRatepUp = -1)
        {
            var path = $"api/s/{Site}/rest/usergroup";

            var oJsonObject = new JObject();
            oJsonObject.Add("name", groupName);
            oJsonObject.Add("qos_rate_max_down", maxRateDown);
            oJsonObject.Add("qos_rate_max_up", maxRatepUp);

            var response = await ExecuteJsonCommandAsync(path, oJsonObject);
            var records = JsonConvert.DeserializeObject<BaseResponse<UserGroup>>(response.Result);
            return records;
        }

        /// <summary>
        /// Delete user group
        /// </summary>
        /// <returns>true on success</returns>
        public async Task<BoolResponse> DeleteUserGroupAsync(string groupId)
        {
            var path = $"api/s/{Site}/rest/usergroup/{groupId}";

            var response = await ExecuteDeleteCommandAsync(path);

            return response;
        }

        /// <summary>
        /// Update user group
        /// </summary>
        /// <param name="groupId">id of the user group</param>
        /// <param name="siteId">id of the site</param>
        /// <param name="groupName">name of the user group</param>
        /// <param name="maxRateDown">limit download bandwidth in Kbps (default = -1, which sets bandwidth to unlimited)</param>
        /// <param name="maxRatepUp">limit upload bandwidth in Kbps (default = -1, which sets bandwidth to unlimited)</param>
        /// <returns>returns an array containing a single object with attributes of the updated usergroup on success</returns>
        public async Task<BaseResponse<UserGroup>> UpdateUserGroupAsync(string groupId, string siteId, string groupName,
            int maxRateDown = -1, int maxRatepUp = -1)
        {
            var path = $"api/s/{Site}/rest/usergroup/{groupId}";

            var oJsonObject = new JObject();
            oJsonObject.Add("_id", groupId);
            oJsonObject.Add("name", groupName);
            oJsonObject.Add("qos_rate_max_down", maxRateDown);
            oJsonObject.Add("qos_rate_max_up", maxRatepUp);
            oJsonObject.Add("site_id", siteId);

            var response = await ExecuteJsonCommandAsync(path, oJsonObject);
            var records = JsonConvert.DeserializeObject<BaseResponse<UserGroup>>(response.Result);
            return records;
        }

        /// <summary>
        /// Assigns the client to user group.
        /// </summary>
        /// <param name="clientId">The id of the user device in the Unifi Controller to be modified.</param>
        /// <param name="groupId">The id of the group to assign user to.</param>
        /// <returns>return true on success</returns>
        public async Task<BoolResponse> AssignClientToUserGroupAsync(string clientId, string groupId)
        {
            var path = $"api/s/{Site}/upd/user/{clientId}";

            var oJsonObject = new JObject();
            oJsonObject.Add("usergroup_id", groupId);

            var response = await ExecuteBoolCommandAsync(path, oJsonObject);
            return response;
        }

        /// <summary>
        /// list user groups.
        /// </summary>
        /// <returns>returns a list of user group</returns>
        public async Task<BaseResponse<UserGroup>> ListUserGroupsAsync()
        {
            var path = $"api/s/{Site}/list/usergroup";

            var oJsonObject = new JObject();

            var response = await ExecuteJsonCommandAsync(path, oJsonObject);

            return JsonConvert.DeserializeObject<BaseResponse<UserGroup>>(response.Result);
        }

        #endregion
    }
}