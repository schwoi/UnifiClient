using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
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

        /// <summary>
        /// Checks if the version supplied is valid againts the Methods Minimum Required Version Attribute.
        /// Returns true if ... is valid.
        /// </summary>
        /// <param name="version">The version.</param>
        /// <param name="methodName">Name of the calling method.</param>
        /// <returns><c>true</c> if the specified version is valid; otherwise, <c>false</c>.</returns>
        public static bool IsValid(this Version version, [CallerMemberName] string methodName = null)
        {
            StackTrace stackTrace = new StackTrace();
            if (stackTrace.GetFrames() == null || methodName == null)
                return true;

            var stackTraceFrames = stackTrace.GetFrames();

            var versionObjecet = stackTraceFrames?.FirstOrDefault(x => x.GetMethod().Name.Contains(methodName));

            var requiredVersionMethod = versionObjecet?.GetMethod().GetCustomAttributes(typeof(MinimumVersionRequiredAttribute), false) as MinimumVersionRequiredAttribute[];

            if (requiredVersionMethod == null || !requiredVersionMethod.Any())
                return true;

            var versionRequired = requiredVersionMethod.First();

            if (versionRequired.MajorValue > version.Major)
                return false;

            if (versionRequired.MajorValue == version.Major &&
                versionRequired.MinorValue > version.Minor)
                return false;

            if (versionRequired.MajorValue == version.Major &&
                versionRequired.MinorValue == version.Minor &&
                versionRequired.BuildValue > version.Build)
                return false;

            return true;
        }
    }
}
