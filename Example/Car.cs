using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AwesomeProperties;
using AwesomeProperties.Attribute;
using AwesomeProperties.Interface;

namespace Example
{
    public class Car : IPropertyFieldValueChanged
    {
        [PropertyField(PropertyType.Text,"Name", order: 1)]
        public string Name { get; set; }

        [PropertyField(PropertyType.Text,"Description", order: 2)]
        public string Description { get; set; }
        
        [PropertyField(PropertyType.Text,"Power (HP)", order: 3)]
        public int HorsePower { get; set; }

        public void OnPropertyChanged(string propertyName, object baseObject, object targetProperty)
        {

        }
    }
}
