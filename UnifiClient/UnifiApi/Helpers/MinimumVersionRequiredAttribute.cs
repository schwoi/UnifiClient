using System;

namespace UnifiApi.Helpers
{

    [AttributeUsage(AttributeTargets.Method)]
    public class MinimumVersionRequiredAttribute : Attribute
    {

        #region Properties

        /// <summary>
        /// Holds the stringvalue for a value in an enum.
        /// </summary>
        public int MajorValue { get; protected set; }
        public int MinorValue { get; protected set; }
        public int BuildValue { get; protected set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor used to init a MinimumVersionRequired Attribute
        /// </summary>
        /// <param name="value"></param>
        public MinimumVersionRequiredAttribute(int major, int minor)
        {
            this.MajorValue = major;
            this.MinorValue = minor;
        }

        public MinimumVersionRequiredAttribute(int major, int minor, int build)
        {
            this.MajorValue = major;
            this.MinorValue = minor;
            this.BuildValue = build;
        }

        public MinimumVersionRequiredAttribute(string version)
        {
            var requiredVersion = Version.Parse(version);
            this.MajorValue = requiredVersion.Major;
            this.MinorValue = requiredVersion.Minor;
            this.BuildValue = requiredVersion.Build;
        }
        #endregion


    }
}
