using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using UnifiApi.Helpers;

namespace UnifiApi.Models
{
    public class Enumerations
    {
        public enum OverrideMode
        {
            [StringValue("off")] [EnumMember] Off,
            [StringValue("on")] [EnumMember] On,
            [StringValue("default")] [EnumMember] Default
        }

        public enum SecurityType
        {
            [StringValue("open")] [EnumMember] Open, 
            [StringValue("wep")] [EnumMember] WEP, 
            [StringValue("wpapsk")] [EnumMember] WPAPSK,
            [StringValue("wpaeap")] [EnumMember] WPAEAP
    }

        public enum WPAMode
        {
            [StringValue("wpa")] [EnumMember] WPA,
            [StringValue("wpa2")] [EnumMember] WPA2,
            [StringValue("wpa3")] [EnumMember] WPA3
        }

        public enum WPAEncryption
        {
            [StringValue("auto")] [EnumMember] Auto,
            [StringValue("ccmp")] [EnumMember] CCMP
        }
    }
}
