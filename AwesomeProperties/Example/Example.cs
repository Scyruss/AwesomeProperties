using AwesomeProperties.Attribute;
using AwesomeProperties.Interface;
using System.Collections.Generic;

namespace AwesomeProperties.Example
{
    public class Example : IPropertyFieldValueChanged
    {
        [PropertyListField(PropertyType.Text, "name", "value")]
        public List<Field> Name { get; set; }


        [PropertyField(PropertyType.Int, "Count",  true, "value")]
        public Field Count { get; set; }


        [PropertyField(PropertyType.CheckBox, "Enable", true, "value")]
        public Field Enable { get; set; }

        public Example()
        {
            Name = new List<Field>() { new Field("") { name = "test", value = "fofo" }, new Field("") { name = "test1", value = "fof1o" }, new Field("") { name = "test2", value = "4fofo" } };
            Count = new Field("");
            Enable = new Field("False");
        }

        public void OnPropertyChanged(string propertyName, object value)
        {

        }
    }
}
