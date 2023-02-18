using AwesomeProperties.Attribute;
using System;
using System.ComponentModel;
using System.Reflection;

namespace AwesomeProperties.Page.ViewModel
{
    internal class PropertyListElementViewModel : PropertyElementBase
    {
        public PropertyInfo valueInfo;
        public PropertyInfo nameInfo;

        public string displayName
        {
            get
            {
                return (string)nameInfo.GetValue(data);
            }
        }

        public object Test
        {
            get
            {
                return valueInfo.GetValue(data);
            }
            set
            {
                var convertedData = Convert.ChangeType(value, valueInfo.PropertyType);

                valueInfo.SetValue(data, convertedData);

                NotifyTargetPropertyChanged(displayName,data);
                NotifyPropertyChanged(nameof(Test));

                
            }
        }


    }
}
