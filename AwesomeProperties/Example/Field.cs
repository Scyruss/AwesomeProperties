using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeProperties.Example
{
    public class Field
    {
        public Field(string value)
        {
            this.value = value;
        }

        public PropertyType type { get; set; }
        public string value { get; set; }
        public string name { get; set; }
    }
}
