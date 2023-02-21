using AwesomeProperties.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeProperties
{
    /// <summary>
    /// Base field class
    /// </summary>
    public class Field : IFieldUtils, INotifyPropertyChanged
    {
        public Field(PropertyType type, string name, string value)
        {
            this.type = type;
            this.value = value;
            this.name = name;
        }
     
        public Field(string value)
        {
            this.value = value;
        }

        public Field()
        {

        }

        public PropertyType type { get; set; }
        public string value { get; set; }
        public string name { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public Field Copy()
        {
            return new Field(type,name,value);
        }

        private void SetProperty<T>(ref T field, T value, [CallerMemberName] string name = "")
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                var handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }
        }
    }
}
