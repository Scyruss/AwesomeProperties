using AwesomeProperties.Attribute;
using AwesomeProperties.Example;
using System;
using System.ComponentModel;
using System.Reflection;

namespace AwesomeProperties.Page.ViewModel
{
    internal class PropertyElementViewModel : PropertyElementBase
    {
        public string displayName { get; set; }

        public object Test
        {
            get
            {
                if (property.IsChildren)
                {
                    var childType = target.PropertyType;
                    var p = childType.GetProperty(property.ChildrenName);
                    var childValue = target.GetValue(data);
                    return p.GetValue(childValue);

                }
                else
                    return target.GetValue(data);
            }
            set
            {


                if (property.IsChildren)
                {

                    var childType = target.PropertyType;
                    var p = childType.GetProperty(property.ChildrenName);
                    var childValue = target.GetValue(data);

                    var convertedData = Convert.ChangeType(value, p.PropertyType);

                    p.SetValue(childValue, convertedData);

                }
                else
                {
                    var convertedData = Convert.ChangeType(value, target.PropertyType);

                    target.SetValue(data, convertedData);
                }

                NotifyTargetPropertyChanged(target.Name, target.GetValue(data));
                NotifyPropertyChanged(nameof(Test));
            }
        }
    }
}
