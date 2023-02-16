using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeProperties
{
    /// <summary>
    /// Base field type
    /// </summary>
    public class Field
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

        public PropertyType type { get; set; }
        public string value { get; set; }
        public string name { get; set; }
    }
}
