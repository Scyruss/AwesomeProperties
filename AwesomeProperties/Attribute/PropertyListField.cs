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

        public PropertyListField(PropertyType type, string childrenName = "", string childrenValueName = "", string childrenControlTypeName = "", int order = -1)
        {
            Type = type;
            ChildrenName = childrenName;
            ChildrenValueName = childrenValueName;
            ChildrenControlTypeName = childrenControlTypeName;
            Order = order;
        }
    }
}
