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
        public PropertyType Type { get; }
        public string ChildrenName { get; }
        public string ChildrenValueName { get; }

        public PropertyListField(PropertyType type, string childrenName = "", string childrenValueName = "")
        {
            Type = type;
            ChildrenName = childrenName;
            ChildrenValueName = childrenValueName;
        }
    }
}
