﻿using AwesomeProperties;
using AwesomeProperties.Attribute;
using AwesomeProperties.Page.ViewModel;
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
using Wpf.Ui.Controls;

namespace WpfApp1
{
    public partial class PropertiesPanel : UserControl
    {
        public delegate void OnPropertieChangedEvent();
        public OnPropertieChangedEvent OnPropertieChanged;
        public bool OrderByGroup { get; }

        /// <summary>
        /// Generate and show mark properties of a class
        /// </summary>
        /// <param name="data">Instance of a class to show</param>
        public PropertiesPanel(object data,bool orderByGroup = false)
        {
            if (data == null) return;

            OrderByGroup= orderByGroup;

            InitializeComponent();

            DataContext = this;

            InitProperties(data);
        }

        public void RefreshProperties()
        {
            foreach (FrameworkElement i in PropertiesList.Children)
            {
                if (i.DataContext.GetType().Name.Contains("PropertyElementViewModel"))
                {
                    var dc = (PropertyElementViewModel)i.DataContext;

                    dc.NotifyPropertyChanged(nameof(dc.Test));
                }

                if (i.DataContext.GetType().Name.Contains("PropertyListElementViewModel"))
                {
                    var dc = (PropertyListElementViewModel)i.DataContext;

                    dc.NotifyPropertyChanged(nameof(dc.Test));
                }
            }
        }

        private void InitProperties(object data)
        {
            //Create a list of Element for store fields (he will help for reorder fields)
            List<FrameworkElement> fields = new List<FrameworkElement>();
            List<string> groups = new List<string>();

            var objectType = data.GetType();

            if (objectType == null) return;


            foreach (var item in objectType.GetProperties())
            {
                List<PropertyListField> listProperty = null;
                List<PropertyField> property = null;

                if (item == null) continue;
                if (!GetFieldType(item, out property) && !GetListFieldType(item, out listProperty)) continue;

                if (property != null)
                {
                    foreach (var p in property)
                    {
                        if (!groups.Contains(p.GroupDisplay))
                            groups.Add(p.GroupDisplay);

                        if (p.Type == PropertyType.None) continue;

                        PropertyElement e = new PropertyElement(this, objectType, item, data, p);

                        if (e == null || PropertiesList == null) continue;

                        fields.Add(e);
                    }

                }

                if (listProperty != null)
                {
                    foreach (var p in listProperty)
                    {

                        if (typeof(IList).IsAssignableFrom(item.PropertyType))
                        {
                            if (!groups.Contains(p.GroupDisplay))
                                groups.Add(p.GroupDisplay);

                            foreach (var indexData in item.GetValue(data) as IList)
                            {
                                if (indexData == null) continue;

                                var propertyTargetType = indexData.GetType();

                                if (propertyTargetType == null) continue;

                                var nameInfo = propertyTargetType.GetProperty(p.ChildrenName);
                                var valueInfo = propertyTargetType.GetProperty(p.ChildrenValueName);
                                var typeInfo = propertyTargetType.GetProperty(p.ChildrenControlTypeName);

                                if (nameInfo == null || valueInfo == null || typeInfo == null || !typeInfo.PropertyType.Name.Contains(nameof(PropertyType))) continue;

                                p.Type = (PropertyType)typeInfo.GetValue(indexData);

                                PropertyElement e = new PropertyElement(this, objectType, nameInfo, valueInfo, indexData, p, data);

                                if (e == null || PropertiesList == null) continue;

                                fields.Add(e);
                            }
                        }
                    }
                }
            }

            var reordered = fields.OrderBy(o => ((int)(o.Tag) == -1) ? 9999 : (int)(o.Tag));

            if (OrderByGroup)
            {
                Dictionary<string,CardExpander> cards = new Dictionary<string, CardExpander>();

                foreach (var group in groups)
                {
                    CardExpander ex = new CardExpander();
                    ex.Margin = new Thickness(0,0,0,10);
                    ex.IsExpanded = true;
                    ex.Header = group;
                    ex.Content = new StackPanel();
                    PropertiesList.Children.Add(ex);
                    cards.Add(group,ex);
                }

                foreach (var i in reordered)
                {
                    var dt = (PropertyElementViewModel)i.DataContext;
                    var group = dt.property.GroupDisplay;

                    ((StackPanel)cards[group].Content).Children.Add(i);
                }
            }
            else
            {


                foreach (var i in reordered)
                    PropertiesList.Children.Add(i);

            }


        }

        private bool GetFieldType(PropertyInfo field, out List<PropertyField> property)
        {
            property = new List<PropertyField>();

            foreach (var attribute in field.CustomAttributes)
            {
                if (attribute != null && attribute.AttributeType.Name.Contains(nameof(PropertyField)))
                {
                    property.Add(new PropertyField((PropertyType)attribute.ConstructorArguments[0].Value,
                                                (string)attribute.ConstructorArguments[1].Value,
                                                (bool)attribute.ConstructorArguments[2].Value,
                                                (string)attribute.ConstructorArguments[3].Value,
                                                (int)attribute.ConstructorArguments[4].Value,
                                                (UpdateSourceTrigger)attribute.ConstructorArguments[5].Value,
                                                (string)attribute.ConstructorArguments[6].Value));

                }
            }

            return (property.Count > 0);
        }

        private bool GetListFieldType(PropertyInfo field, out List<PropertyListField> property)
        {
            property = new List<PropertyListField>();

            foreach (var attribute in field.CustomAttributes)
            {
                if (attribute != null && attribute.AttributeType.Name.Contains(nameof(PropertyListField)))
                {
                    property.Add(new PropertyListField((string)attribute.ConstructorArguments[0].Value,
                                                (string)attribute.ConstructorArguments[1].Value,
                                                (string)attribute.ConstructorArguments[2].Value,
                                                (int)attribute.ConstructorArguments[3].Value,
                                                (UpdateSourceTrigger)attribute.ConstructorArguments[4].Value,
                                                (string)attribute.ConstructorArguments[5].Value));

                }
            }
            
            return (property.Count > 0);
        }
    }
}
