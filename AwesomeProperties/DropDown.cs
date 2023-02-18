using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeProperties
{
    /// <summary>
    /// DropDown class is inherit with field class
    /// </summary>
    public class DropDown : Field
    {
        public DropDown(PropertyType type, string name ,string value, string[] options) : base(type,name,value)
        {
            Options = options;
        }

        public DropDown(string[] options)
        {
            Options = options;
        }

        public DropDown()
        {

        }

        public string[] Options { get; }

        public new Field Copy()
        {
            return new DropDown(type, name, value, Options);
        }
    }
}
