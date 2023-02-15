using AwesomeProperties.Attribute;
using AwesomeProperties.Example;
using System;
using System.ComponentModel;
using System.Reflection;

namespace AwesomeProperties.Page.ViewModel
{
    internal class PropertyElementViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Type baseType;
        public PropertyInfo target;
        public object data;

        public void NotifyPropertyChanged(string name)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string displayName { get; set; }

        public PropertyField property;

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
                var method = baseType.GetMethod("OnPropertyChanged");
                var convertedData = PropertyDataConverter.CheckData(target, property, value);

                if (property.IsChildren)
                {
                    var childType = target.PropertyType;
                    var p = childType.GetProperty(property.ChildrenName);
                    var childValue = target.GetValue(data);

                    convertedData = PropertyDataConverter.CheckData(p, property, value);

                    p.SetValue(childValue, convertedData);

                }
                else
                    target.SetValue(data, convertedData);

                if (method != null)
                    method.Invoke(data, new object[] { target.Name, convertedData });

                NotifyPropertyChanged(nameof(Test));
            }
        }


    }
}
