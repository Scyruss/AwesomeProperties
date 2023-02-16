using AwesomeProperties.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeProperties.Page.ViewModel
{
    public class PropertyElementBase: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Type baseType;
        public object data;
        public object baseTypeData;
        public PropertyField property;
        public PropertyInfo target;

        public void NotifyPropertyChanged(string name)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void NotifyTargetPropertyChanged(string elementName, object data)
        {
            var method = baseType.GetMethod("OnPropertyChanged");

            if (method != null)
                method.Invoke(baseTypeData, new object[] { elementName, baseTypeData, data });
        }
    }
}
