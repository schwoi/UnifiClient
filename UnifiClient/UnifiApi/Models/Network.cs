using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnifiApi.Models
{
    public class Network
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("is_nat", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsNat { get; set; }

        [JsonProperty("dhcpd_dns_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DhcpdDnsEnabled { get; set; }

        [JsonProperty("purpose")]
        public string Purpose { get; set; }

        [JsonProperty("dhcpd_leasetime", NullValueHandling = NullValueHandling.Ignore)]
        public long? DhcpdLeasetime { get; set; }

        [JsonProperty("dhcpguard_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DhcpguardEnabled { get; set; }

        [JsonProperty("dhcpd_dns_1", NullValueHandling = NullValueHandling.Ignore)]
        public string DhcpdDns1 { get; set; }

        [JsonProperty("dhcpd_start", NullValueHandling = NullValueHandling.Ignore)]
        public string DhcpdStart { get; set; }

        [JsonProperty("dhcpd_stop", NullValueHandling = NullValueHandling.Ignore)]
        public string DhcpdStop { get; set; }

        [JsonProperty("enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Enabled { get; set; }

        [JsonProperty("dhcpd_wins_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DhcpdWinsEnabled { get; set; }

        [JsonProperty("domain_name", NullValueHandling = NullValueHandling.Ignore)]
        public string DomainName { get; set; }

        [JsonProperty("dhcpd_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DhcpdEnabled { get; set; }

        [JsonProperty("ip_subnet", NullValueHandling = NullValueHandling.Ignore)]
        public string IpSubnet { get; set; }

        [JsonProperty("dhcpd_dns_2", NullValueHandling = NullValueHandling.Ignore)]
        public string DhcpdDns2 { get; set; }

        [JsonProperty("networkgroup", NullValueHandling = NullValueHandling.Ignore)]
        public string Networkgroup { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("site_id")]
        public string SiteId { get; set; }

        [JsonProperty("dhcpd_ip_1", NullValueHandling = NullValueHandling.Ignore)]
        public string DhcpdIp1 { get; set; }

        [JsonProperty("attr_no_delete", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AttrNoDelete { get; set; }

        [JsonProperty("attr_hidden_id", NullValueHandling = NullValueHandling.Ignore)]
        public string AttrHiddenId { get; set; }

        [JsonProperty("vlan_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? VlanEnabled { get; set; }

        [JsonProperty("upnp_lan_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? UpnpLanEnabled { get; set; }

        [JsonProperty("lte_lan_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? LteLanEnabled { get; set; }

        [JsonProperty("ipsec_dh_group", NullValueHandling = NullValueHandling.Ignore)]
        public long? IpsecDhGroup { get; set; }

        [JsonProperty("ipsec_hash", NullValueHandling = NullValueHandling.Ignore)]
        public string IpsecHash { get; set; }

        [JsonProperty("ipsec_peer_ip", NullValueHandling = NullValueHandling.Ignore)]
        public string IpsecPeerIp { get; set; }

        [JsonProperty("ipsec_dynamic_routing", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IpsecDynamicRouting { get; set; }

        [JsonProperty("ipsec_key_exchange", NullValueHandling = NullValueHandling.Ignore)]
        public string IpsecKeyExchange { get; set; }

        [JsonProperty("vpn_type", NullValueHandling = NullValueHandling.Ignore)]
        public string VpnType { get; set; }

        [JsonProperty("ipsec_pfs", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IpsecPfs { get; set; }

        [JsonProperty("remote_vpn_subnets", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> RemoteVpnSubnets { get; set; }

        [JsonProperty("ipsec_profile", NullValueHandling = NullValueHandling.Ignore)]
        public string IpsecProfile { get; set; }

        [JsonProperty("ipsec_encryption", NullValueHandling = NullValueHandling.Ignore)]
        public string IpsecEncryption { get; set; }

        [JsonProperty("ipsec_local_ip", NullValueHandling = NullValueHandling.Ignore)]
        public string IpsecLocalIp { get; set; }

        [JsonProperty("x_ipsec_pre_shared_key", NullValueHandling = NullValueHandling.Ignore)]
        public string XIpsecPreSharedKey { get; set; }

        [JsonProperty("ifname", NullValueHandling = NullValueHandling.Ignore)]
        public string Ifname { get; set; }

        [JsonProperty("radiusprofile_id", NullValueHandling = NullValueHandling.Ignore)]
        public string RadiusprofileId { get; set; }

        [JsonProperty("wan_networkgroup", NullValueHandling = NullValueHandling.Ignore)]
        public string WanNetworkgroup { get; set; }

        [JsonProperty("wan_type", NullValueHandling = NullValueHandling.Ignore)]
        public string WanType { get; set; }

        [JsonProperty("wan_ip", NullValueHandling = NullValueHandling.Ignore)]
        public string WanIp { get; set; }

        [JsonProperty("wan_netmask", NullValueHandling = NullValueHandling.Ignore)]
        public string WanNetmask { get; set; }

        [JsonProperty("wan_gateway", NullValueHandling = NullValueHandling.Ignore)]
        public string WanGateway { get; set; }

        [JsonProperty("wan_dns1", NullValueHandling = NullValueHandling.Ignore)]
        public string WanDns1 { get; set; }

        [JsonProperty("wan_dns2", NullValueHandling = NullValueHandling.Ignore)]
        public string WanDns2 { get; set; }

        [JsonProperty("wan_type_v6", NullValueHandling = NullValueHandling.Ignore)]
        public string WanTypeV6 { get; set; }

        [JsonProperty("wan_dhcpv6_pd_size", NullValueHandling = NullValueHandling.Ignore)]
        public long? WanDhcpv6PdSize { get; set; }

        [JsonProperty("report_wan_event", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ReportWanEvent { get; set; }

        [JsonProperty("wan_egress_qos", NullValueHandling = NullValueHandling.Ignore)]
        public string WanEgressQos { get; set; }

        [JsonProperty("wan_load_balance_type", NullValueHandling = NullValueHandling.Ignore)]
        public string WanLoadBalanceType { get; set; }

        [JsonProperty("wan_load_balance_weight", NullValueHandling = NullValueHandling.Ignore)]
        public long? WanLoadBalanceWeight { get; set; }

        [JsonProperty("vlan", NullValueHandling = NullValueHandling.Ignore)]
        public long? Vlan { get; set; }
    }
}
