using Catel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HenneckeCut.Models
{
    /// <summary>
    /// CutMark model which fully supports serialization, property changed notifications,
    /// backwards compatibility and error checking.
    /// </summary>
#if !SILVERLIGHT
    [Serializable]
#endif
    public class CutMark : ModelBase
    {
        #region Fields
        #endregion

        #region Constructors
        public CutMark() { }
        #endregion

        #region Properties
        // TODO: Define your custom properties here using the modelprop code snippet
        /// <summary>
            /// Gets or sets the property value.
            /// </summary>
        public string LampConnectionStatus
        {
            get { return GetValue<string>(LampConnectionStatusProperty); }
            set { SetValue(LampConnectionStatusProperty, value); }
        }

        /// <summary>
        /// Register the LampConnectionStatus property so it is known in the class.
        /// </summary>
        public static readonly PropertyData LampConnectionStatusProperty = RegisterProperty("LampConnectionStatus", typeof(string), Colors.DarkGray.ToString());
        #endregion

        #region Methods
        
        #endregion
    }
}
