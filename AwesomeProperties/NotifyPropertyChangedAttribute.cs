using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeProperties
{
    [Serializable]
    public class NotifyPropertyChangedAttribute : LocationInterceptionAspect
    {
        public override void OnSetValue(LocationInterceptionArgs args)
        {
            object oldValue = args.GetCurrentValue();
            object newValue = args.Value;
            base.OnSetValue(args);
            if (args.Instance is INotifyPropertyChanged)
            {
                if (!Equals(oldValue, newValue))
                {
                    RaisePropertyChanged(args.Instance, args.LocationName);
                }
            }
        }

        private void RaisePropertyChanged(object instance, string propertyName)
        {
            PropertyChangedEventHandler handler = GetPropertyChangedHandler(instance);
            if (handler != null)
                handler(instance, new PropertyChangedEventArgs(propertyName));
        }

        private PropertyChangedEventHandler GetPropertyChangedHandler(object instance)
        {
            Type type = instance.GetType().GetEvent("PropertyChanged").DeclaringType;
            FieldInfo propertyChanged = type.GetField("PropertyChanged",
                                                      BindingFlags.Instance | BindingFlags.NonPublic);
            if (propertyChanged != null)
                return propertyChanged.GetValue(instance) as PropertyChangedEventHandler;

            return null;
        }
    }
}
