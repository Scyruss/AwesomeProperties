using AwesomeProperties.Example;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AwesomeProperties.Attribute
{

    
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = true, AllowMultiple = true)]
    public class PropertyField : System.Attribute
    {
        public PropertyType Type { get; }
        public string DisplayName { get; }
        public bool IsChildren { get; }
        public string ChildrenName { get; }
        public int Order { get; }
        public UpdateSourceTrigger UpdateSourceTrigger { get; set; }


        /// <param name="childrenName">Name of the property who store the property header name</param>
        /// <param name="childrenValueName">Name of the property who store the property value</param>
        /// <param name="childrenControlTypeName">Name of the property who store the property type</param>
        /// <param name="order">Specify the property order (By default he is order by declaration)</param>

        /// <summary>
        /// Specify the property should be draw in the properties panel
        /// </summary>
        /// <param name="type">Specify the control type</param>
        /// <param name="displayName">Specify the header name</param>
        /// <param name="isChildren">Set to true when the property is not a standard field</param>
        /// <param name="childrenName">Specify the name of the field to bind</param>
        /// <param name="order">Specify the property order (By default he is order by declaration)</param>
        public PropertyField(PropertyType type, string displayName, bool isChildren = false, string childrenName = "", int order = -1, UpdateSourceTrigger sourceTrigger = UpdateSourceTrigger.PropertyChanged)
        {
            Type = type;
            DisplayName = displayName;
            IsChildren = isChildren;
            ChildrenName = childrenName;
            Order = order;
            UpdateSourceTrigger = sourceTrigger;
        }
    }
}
