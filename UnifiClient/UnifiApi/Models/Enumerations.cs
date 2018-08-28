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
    }
}
