using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using UnifiApi.Helpers;

namespace UnifiApi.Models
{
    public class FirewallGroup
    {
        private GroupType _groupType;

        [JsonProperty(PropertyName = "_id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "group_members")]
        public List<string> GroupMembers { get; set; }

        [JsonProperty(PropertyName = "group_type")]
        internal string GroupTypeString { get; set; }

        [JsonIgnore]
        public GroupType GroupType
        {
            get
            {
                if (_groupType != default(GroupType))
                    return _groupType;

                if (GroupTypeString == GroupType.AddressGroup.GetStringValue())
                    return GroupType.AddressGroup;

                if (GroupTypeString == GroupType.IPV6AddressGroup.GetStringValue())
                    return GroupType.IPV6AddressGroup;

                if (GroupTypeString == GroupType.PortGroup.GetStringValue())
                    return GroupType.PortGroup;

                return default(GroupType);
            }

            set
            {
                GroupTypeString = value.GetStringValue();
                _groupType = value;
            }
        }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "site_id")]
        public string SiteId { get; set; }

    }


    public enum GroupType
    {
        [StringValue("address-group")]
        [EnumMember]
        AddressGroup,
        [StringValue("ipv6-address-group")]
        [EnumMember]
        IPV6AddressGroup,
        [StringValue("port-group")]
        [EnumMember]
        PortGroup
    }
}
