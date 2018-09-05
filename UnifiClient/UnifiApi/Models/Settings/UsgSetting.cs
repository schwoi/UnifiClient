using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace UnifiApi.Models
{
    public class UsgSetting : BaseSetting
    {
        public UsgSetting()
        {
            Key = "usg";
        }
        [JsonProperty("broadcast_ping")]
        public bool BroadcastPing { get; set; }

        [JsonProperty("ftp_module")]
        public bool FtpModule { get; set; }

        [JsonProperty("gre_module")]
        public bool GreModule { get; set; }

        [JsonProperty("h323_module")]
        public bool H323Module { get; set; }

        [JsonProperty("mdns_enabled")]
        public bool MdnsEnabled { get; set; }

        [JsonProperty("mss_clamp")]
        public string MssClamp { get; set; }

        [JsonProperty("offload_accounting")]
        public bool OffloadAccounting { get; set; }

        [JsonProperty("offload_l2_blocking")]
        public bool OffloadL2Blocking { get; set; }

        [JsonProperty("offload_sch")]
        public bool OffloadSch { get; set; }

        [JsonProperty("pptp_module")]
        public bool PptpModule { get; set; }

        [JsonProperty("receive_redirects")]
        public bool ReceiveRedirects { get; set; }

        [JsonProperty("send_redirects")]
        public bool SendRedirects { get; set; }

        [JsonProperty("sip_module")]
        public bool SipModule { get; set; }

        [JsonProperty("syn_cookies")]
        public bool SynCookies { get; set; }

        [JsonProperty("tftp_module")]
        public bool TftpModule { get; set; }

        [JsonProperty("upnp_enabled")]
        public bool UpnpEnabled { get; set; }

        [JsonProperty("upnp_nat_pmp_enabled")]
        public bool UpnpNatPmpEnabled { get; set; }

        [JsonProperty("upnp_secure_mode")]
        public bool UpnpSecureMode { get; set; }

        [JsonProperty("upnp_wan_interface")]
        public string UpnpWanInterface { get; set; }
    }
}
