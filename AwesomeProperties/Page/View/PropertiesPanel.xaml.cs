using AwesomeProperties;
using AwesomeProperties.Attribute;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    public partial class PropertiesPanel : UserControl
    {
        public object data;
        public Type type;

        /// <summary>
        /// Generate and show mark properties of a class
        /// </summary>
        /// <param name="data">Instance of a class to show</param>
        public PropertiesPanel(object data)
        {
            if (data == null) return;

            InitializeComponent();

            DataContext = this;

            InitProperties(data);
        }

        private void InitProperties(object data)
        {
            //Create a list of Element for store fields (he will help for reorder fields)
            List<FrameworkElement> fields = new List<FrameworkElement>();

            var objectType = data.GetType();

            if (objectType == null) return;

            foreach (var item in objectType.GetProperties())
            {
                PropertyListField listProperty = null;
                PropertyField property = null;

                if (item == null) continue;
                if (!GetFieldType(item, out property) && !GetListFieldType(item, out listProperty)) continue;

                if (property != null)
                {
                    if (property.Type == PropertyType.None) continue;

                    PropertyElement e = new PropertyElement(objectType, item, data, property);

                    if (e == null || PropertiesList == null) continue;

                    fields.Add(e);
                }

                if (listProperty != null)
                {
                    if (typeof(IList).IsAssignableFrom(item.PropertyType))
                    {
                        foreach (var indexData in item.GetValue(data) as IList)
                        {
                            if (indexData == null) continue;

                            var propertyTargetType = indexData.GetType();

                            if (propertyTargetType == null) continue;

                            var nameInfo = propertyTargetType.GetProperty(listProperty.ChildrenName);
                            var valueInfo = propertyTargetType.GetProperty(listProperty.ChildrenValueName);
                            var typeInfo = propertyTargetType.GetProperty(listProperty.ChildrenControlTypeName);

                            if (nameInfo == null || valueInfo == null || typeInfo == null || !typeInfo.PropertyType.Name.Contains(nameof(PropertyType))) continue;

                            listProperty.Type = (PropertyType)typeInfo.GetValue(indexData);

                            PropertyElement e = new PropertyElement(objectType, nameInfo, valueInfo, indexData, listProperty, data);
                            
                            if (e == null || PropertiesList == null) continue;

                            fields.Add(e);
                        }
                    }
                }
            }

            var reordered = fields.OrderBy(o => ((int)(o.Tag) == -1)?9999: (int)(o.Tag));

            foreach (var i in reordered)
                PropertiesList.Children.Add(i);


        }

        private bool GetFieldType(PropertyInfo field, out PropertyField property)
        {
            property = null;

            foreach (var attribute in field.CustomAttributes)
            {
                if (attribute != null && attribute.AttributeType.Name.Contains(nameof(PropertyField)))
                {
                    if (attribute.ConstructorArguments.Count != 5) continue;

                    property = new PropertyField((PropertyType)attribute.ConstructorArguments[0].Value,
                                                (string)attribute.ConstructorArguments[1].Value,
                                                (bool)attribute.ConstructorArguments[2].Value,
                                                (string)attribute.ConstructorArguments[3].Value,
                                                (int)attribute.ConstructorArguments[4].Value);

                    return true;
                }
            }

            return false;
        }

        private bool GetListFieldType(PropertyInfo field, out PropertyListField property)
        {
            property = null;

            foreach (var attribute in field.CustomAttributes)
            {
                if (attribute != null && attribute.AttributeType.Name.Contains(nameof(PropertyListField)))
                {
                    if (attribute.ConstructorArguments.Count != 4) continue;

                    property = new PropertyListField((string)attribute.ConstructorArguments[0].Value,
                                                (string)attribute.ConstructorArguments[1].Value,
                                                (string)attribute.ConstructorArguments[2].Value,
                                                (int)attribute.ConstructorArguments[3].Value);

                    return true;
                }
            }

            return false;
        }
    }
}
