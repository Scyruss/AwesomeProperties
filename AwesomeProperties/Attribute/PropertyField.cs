using AwesomeProperties.Example;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeProperties.Attribute
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = true, AllowMultiple = true)]
    public class PropertyField : System.Attribute
    {
        public PropertyType Type { get; }
        public string DisplayName { get; }
        public bool IsChildren { get; }
        public string ChildrenName { get; }

        public PropertyField(PropertyType type, string displayName, bool isChildren = false, string childrenName = "")
        {
            Type = type;
            DisplayName = displayName;
            IsChildren = isChildren;
            ChildrenName = childrenName;
        }
    }
}
