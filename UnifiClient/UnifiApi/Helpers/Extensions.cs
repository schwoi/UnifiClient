using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace UnifiApi.Helpers
{
   public static class Extensions
    {
        public static DateTime ToLocalDateTime(this double seconds)
        {
            return new DateTime(1970, 1, 1).AddMilliseconds(seconds).ToLocalTime();
        }
        public static DateTime ToUtcDateTime(this double seconds)
        {
            return new DateTime(1970, 1, 1).AddMilliseconds(seconds);
        }

        public static DateTime ToLocalDateTime(this int seconds)
        {
            return new DateTime(1970, 1, 1).AddSeconds(seconds).ToLocalTime();
        }

        public static DateTime ToUtcDateTime(this int seconds)
        {
            return new DateTime(1970, 1, 1).AddSeconds(seconds);
        }

        /// <summary>
        /// Will get the string value for a given enums value, this will
        /// only work if you assign the StringValue attribute to
        /// the items in your enum.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetStringValue(this Enum value)
        {
            // Get the type
            Type type = value.GetType();

            // Get fieldinfo for this type
            FieldInfo fieldInfo = type.GetField(value.ToString());

            // Get the stringvalue attributes
            StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(StringValueAttribute), false) as StringValueAttribute[];

            // Return the first if there was a match.
            return attribs.Length > 0 ? attribs[0].StringValue : null;
        }
    }
}
