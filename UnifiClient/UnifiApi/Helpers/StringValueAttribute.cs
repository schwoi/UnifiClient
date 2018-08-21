using System;

namespace UnifiApi.Helpers
{
    /// <summary>
    /// This attribute is used to represent a string value
    /// for a value in an enum.
    /// 
    /// Reference : http://weblogs.asp.net/stefansedich/archive/2008/03/12/enum-with-string-values-in-c.aspx
    /// </summary>
    public class StringValueAttribute : Attribute
    {

        #region Properties

        /// <summary>
        /// Holds the stringvalue for a value in an enum.
        /// </summary>
        public string StringValue { get; protected set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor used to init a StringValue Attribute
        /// </summary>
        /// <param name="value"></param>
        public StringValueAttribute(string value)
        {
            this.StringValue = value;
        }

        #endregion


    }
}
