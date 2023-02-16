using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeProperties.Interface
{
    public interface IPropertyFieldValueChanged
    {

        /// <summary>
        /// Get notified whe property value changed
        /// </summary>
        /// <param name="propertyName">Display name of the property</param>
        /// <param name="baseObject">Root element (object bind in PropertiesPanel control)</param>
        /// <param name="targetProperty">Current modify element</param>
        void OnPropertyChanged(string propertyName, object baseObject, object targetProperty);
    }
}
