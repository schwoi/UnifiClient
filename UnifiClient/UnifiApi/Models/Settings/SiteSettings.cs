using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace UnifiApi.Models
{
    public class SiteSettings
    {
        public SiteSettings()
        {
            this.UnmappedObjects = new List<JObject>();
        }

        public AutoSpeedtestSetting AutoSpeedTest { get; set; }
        public CountrySetting Country { get; set; }
        public ConnectivitySetting Connectivity { get; set; }
        public DpiSetting Dpi { get; set; }
        public GuestAccessSetting GuestAccess { get; set; }
        public IdentitySetting Identity { get; set; }
        public LocaleSetting Locale { get; set; }
        public MgmtSetting Managememt { get; set; }
        public NtpSetting Ntp { get; set; }
        public PortaSetting Porta { get; set; }
        public RadiusSetting Radius { get; set; }
        public RsyslogdSetting RsysLogd { get; set; }
        public SmtpSetting Smtp { get; set; }
        public SnmpSetting Snmp { get; set; }
        public SuperMgmtSetting SuperManagement { get; set; }
        public UsgSetting Usg { get; set; }


        public List<JObject> UnmappedObjects { get; set; }
    }

}



