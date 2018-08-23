using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnifiApi.Helpers;
using UnifiApi.Models;
using UnifiApi.Responses;

namespace UnifiApi
{
    public partial class Client
    {
        #region Firewall Methods

        /// <summary>
        /// create firewall groups as an asynchronous operation.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="type">The type.</param>
        /// <param name="members">The members.</param>
        /// <returns>returns a list containing a single firewall group of the created firewall group on success</returns>
        public async Task<BaseResponse<FirewallGroup>> CreateFirewallGroupAsync(string name, GroupType type,
            List<string> members)
        {
            var path = $"/api/s/{Site}/rest/firewallgroup";
            var oJsonObject = new JObject();
            oJsonObject.Add("name", name);
            oJsonObject.Add("group_type", type.GetStringValue());
            oJsonObject.Add("group_members", new JArray {members.ToArray()});

            var response = await ExecuteJsonCommandAsync(path, oJsonObject);
            return JsonConvert.DeserializeObject<BaseResponse<FirewallGroup>>(response.Result);
        }

        /// <summary>
        /// update firewall group.
        /// </summary>
        /// <param name="group">The firewall group.</param>
        /// <returns>returns a list containing a single firewall group of the updated firewall group on success</returns>
        public async Task<BaseResponse<FirewallGroup>> UpdateFirewallGroupAsync(FirewallGroup group)
        {
            var path = $"/api/s/{Site}/rest/firewallgroup/{@group.Id}";

            var oJsonObject = JObject.FromObject(@group);

            var response = await ExecuteJsonCommandAsync(path, oJsonObject, "PUT");
            return JsonConvert.DeserializeObject<BaseResponse<FirewallGroup>>(response.Result);
        }

        /// <summary>
        /// update firewall group.
        /// </summary>
        /// <param name="groupId">The group identifier.</param>
        /// <param name="siteId">The site identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="type">The type.</param>
        /// <param name="members">The members.</param>
        /// <returns>returns a list containing a single firewall group of the updated firewall group on success</returns>
        public async Task<BaseResponse<FirewallGroup>> UpdateFirewallGroupAsync(string groupId, string siteId,
            string name, GroupType type, List<string> members)
        {
            return await UpdateFirewallGroupAsync(new FirewallGroup
            {
                Id = groupId,
                SiteId = siteId,
                Name = name,
                GroupType = type,
                GroupMembers = members
            });
        }

        /// <summary>
        /// delete firewall groups.
        /// </summary>
        /// <param name="groupId">The firewall group identifier.</param>
        /// <returns>returns true on success</returns>
        public async Task<BoolResponse> DeleteFirewallGroupAsync(string groupId)
        {
            var path = $"/api/s/{Site}/rest/firewallgroup/{groupId}";

            var response = await ExecuteDeleteCommandAsync(path);

            return response;
        }

        /// <summary>
        /// list firewall groups.
        /// </summary>
        /// <returns>returns list of firewall groups</returns>
        public async Task<BaseResponse<FirewallGroup>> ListFirewallGroupsAsync()
        {
            var path = $"/api/s/{Site}/rest/firewallgroup";

            var response = await ExecuteGetCommandAsync(path);
            return JsonConvert.DeserializeObject<BaseResponse<FirewallGroup>>(response.Result);
        }

        #endregion
    }
}