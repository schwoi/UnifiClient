using System;
using System.Collections.Generic;
using System.Text;

namespace UnifiApi.Helpers
{
   public static class Extensions
    {
        public static DateTime ToLocalDateTime(this int seconds)
        {
            return new DateTime(1970, 1, 1).AddSeconds(seconds).ToLocalTime();
        }

        public static DateTime ToUtcDateTime(this int seconds)
        {
            return new DateTime(1970, 1, 1).AddSeconds(seconds);
        }
    }
}
