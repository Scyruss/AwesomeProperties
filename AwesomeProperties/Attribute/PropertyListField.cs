using AwesomeProperties.Example;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeProperties.Attribute
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = true, AllowMultiple = true)]
    public class PropertyListField : System.Attribute
    {
        public PropertyType Type { get; set; }
        public string ChildrenName { get; }
        public string ChildrenValueName { get; }
        public string ChildrenControlTypeName { get; }
        public int Order { get; }
        public bool HasOrder { get => (Order == -1);  }

        /// <summary>
        /// Specify the property should be draw in the properties panel
        /// </summary>
        /// <param name="childrenName">Name of the property who store the property header name</param>
        /// <param name="childrenValueName">Name of the property who store the property value</param>
        /// <param name="childrenControlTypeName">Name of the property who store the property type</param>
        /// <param name="order">Specify the property order (By default he is order by declaration)</param>
        public PropertyListField(string childrenName = "", string childrenValueName = "", string childrenControlTypeName = "", int order = -1)
        {
            ChildrenName = childrenName;
            ChildrenValueName = childrenValueName;
            ChildrenControlTypeName = childrenControlTypeName;
            Order = order;
        }
    }
}
