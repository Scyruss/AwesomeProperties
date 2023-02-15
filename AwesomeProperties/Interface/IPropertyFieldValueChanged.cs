using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeProperties.Interface
{
    public interface IPropertyFieldValueChanged
    {
        void OnPropertyChanged(string propertyName, object value);
    }
}
