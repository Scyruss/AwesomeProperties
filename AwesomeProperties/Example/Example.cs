﻿using AwesomeProperties.Attribute;
using AwesomeProperties.Interface;
using System.Collections.Generic;
using System.Windows.Controls;
using WpfApp1;

namespace AwesomeProperties.Example
{
    public class Example
    {
        //[PropertyListField("name", "value")]
        //public List<Field> Name { get; set; }


        //[PropertyField(PropertyType.Int, "Count", true, "value")]
        //public Field Count { get; set; }


        //[PropertyField(PropertyType.CheckBox, "Enable", true, "value")]
        //public Field Enable { get; set; }

        [PropertyField(PropertyType.Text, "Name")]
        public string Name { get; set; }

        [PropertyField(PropertyType.Text, "Model")]
        public string Model { get; set; }

        public Example()
        {

        }

        public void ShowProperties()
        {
            //PropertiesPanel panel = new PropertiesPanel(example);
            //MyGrid.Children.Clear();
            //MyGrid.Children.Add(panel);
        }
    }
}
