using System;
using System.ComponentModel;
using System.Reflection;

namespace AwesomeProperties.Page.ViewModel
{
    internal class PropertyListElementViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Type baseType;
        public object baseTypeData;

        public PropertyInfo valueInfo;
        public PropertyInfo nameInfo;
        public object data;

        public void NotifyPropertyChanged(string name)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }

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
                var method = baseType.GetMethod("OnPropertyChanged");
                //var convertedData = PropertyDataConverter.CheckData(this.valueInfo, property, value);

                valueInfo.SetValue(data, value);

                if (method != null)
                    method.Invoke(baseTypeData, new object[] { valueInfo.Name, value });

                NotifyPropertyChanged(nameof(Test));
            }
        }


    }
}
