using AwesomeProperties.Attribute;
using AwesomeProperties.Interface;
using System.Collections.Generic;

namespace AwesomeProperties.Example
{
    public class Example
    {
        [PropertyListField("name", "value")]
        public List<Field> Name { get; set; }


        [PropertyField(PropertyType.Int, "Count",  true, "value")]
        public Field Count { get; set; }


        [PropertyField(PropertyType.CheckBox, "Enable", true, "value")]
        public Field Enable { get; set; }

        public Example()
        {

        }

    }
}
