using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using AwesomeProperties;
using AwesomeProperties.Attribute;
using AwesomeProperties.Interface;

namespace Example
{
    public class Car : IPropertyFieldValueChanged
    {
        [PropertyField(PropertyType.Text,"Name", order: 1, sourceTrigger: System.Windows.Data.UpdateSourceTrigger.LostFocus)]
        public string Name { get; set; }

        [PropertyField(PropertyType.FileBrowser,"Description", order: 2)]
        public string Description { get; set; }
        
        [PropertyField(PropertyType.Text,"Power (HP)", order: 3)]
        public int HorsePower { get; set; }

        [PropertyField(PropertyType.CheckBox, "Is hybrid", order: 4)]
        public bool IsHybrid { get; set; }

        [PropertyField(PropertyType.ColorField, "Paint", order: 5)]
        public Color Paint { get; set; }

        public void OnPropertyChanged(string propertyName, object baseObject, object targetProperty)
        {

        }
    }
}
