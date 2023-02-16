using System;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

using AwesomeProperties;
using AwesomeProperties.Attribute;
using AwesomeProperties.Page.ViewModel;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour PropertyElement.xaml
    /// </summary>
    public partial class PropertyElement : UserControl
    {
        public PropertyElement(Type baseType, PropertyInfo nameInfo, PropertyInfo valueInfo, Object data, PropertyListField property, Object baseData)
        {

            var view = new PropertyListElementViewModel();
            view.baseType = baseType;
            view.nameInfo = nameInfo;
            view.valueInfo = valueInfo;
            view.data = data;
            view.baseTypeData = baseData;
            view.property = new PropertyField(property.Type,"",order: property.Order);
            Tag = property.Order;

            InitializeComponent();

            DataContext = view;

            if (property.Type == PropertyType.Text)
            {

                TextBox textBlock = new TextBox();
                Binding binding = new Binding("Test");
                binding.Source = DataContext;
                binding.Mode = BindingMode.TwoWay;
                binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

                textBlock.Margin = new Thickness(0, 0, 0, 5);
                textBlock.HorizontalAlignment = HorizontalAlignment.Stretch;
                textBlock.VerticalAlignment = VerticalAlignment.Stretch;

                Grid.SetColumn(textBlock, 1);

                BindingOperations.SetBinding(textBlock, TextBox.TextProperty, binding);
                Property.Children.Add(textBlock);
            }

            else if (property.Type == PropertyType.Int)
            {
                TextBox textBlock = new TextBox();
                Binding binding = new Binding("Test");
                binding.Source = DataContext;
                binding.Mode = BindingMode.TwoWay;
                binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

                textBlock.Margin = new Thickness(0, 0, 0, 5);
                textBlock.HorizontalAlignment = HorizontalAlignment.Stretch;
                textBlock.VerticalAlignment = VerticalAlignment.Stretch;
                textBlock.PreviewTextInput += (object sender, TextCompositionEventArgs e) =>
                {
                    Regex regex = new Regex("[^0-9]+");
                    e.Handled = regex.IsMatch(e.Text);
                };

                Grid.SetColumn(textBlock, 1);

                BindingOperations.SetBinding(textBlock, TextBox.TextProperty, binding);
                Property.Children.Add(textBlock);
            }

            else if (property.Type == PropertyType.CheckBox)
            {
                CheckBox ckeckBox = new CheckBox();
                Binding binding = new Binding("Test");
                binding.Source = DataContext;
                binding.Mode = BindingMode.TwoWay;
                binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

                ckeckBox.Margin = new Thickness(0, 0, 0, 5);
                ckeckBox.HorizontalAlignment = HorizontalAlignment.Stretch;
                ckeckBox.VerticalAlignment = VerticalAlignment.Center;

                Grid.SetColumn(ckeckBox, 1);

                BindingOperations.SetBinding(ckeckBox, CheckBox.IsCheckedProperty, binding);
                Property.Children.Add(ckeckBox);
            }
        }

        public PropertyElement(Type baseType, PropertyInfo target, Object data, PropertyField property)
        {
            var view = new PropertyElementViewModel();
            view.baseType = baseType;
            view.target = target;
            view.data = data;
            view.displayName = property.DisplayName;
            view.property = property;
            Tag = property.Order;

            InitializeComponent();

            DataContext = view;

            if (property.Type == PropertyType.Text)
            {
                TextBox textBlock = new TextBox();
                Binding binding = new Binding("Test");
                binding.Source = DataContext;
                binding.Mode = BindingMode.TwoWay;
                binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

                textBlock.Margin = new Thickness(0, 0, 0, 5);
                textBlock.HorizontalAlignment = HorizontalAlignment.Stretch;
                textBlock.VerticalAlignment = VerticalAlignment.Stretch;

                Grid.SetColumn(textBlock,1);

                BindingOperations.SetBinding(textBlock, TextBox.TextProperty, binding);
                Property.Children.Add(textBlock);
            }

            else if (property.Type == PropertyType.Int)
            {
                TextBox textBlock = new TextBox();
                Binding binding = new Binding("Test");
                binding.Source = DataContext;
                binding.Mode = BindingMode.TwoWay;
                binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

                textBlock.Margin = new Thickness(0, 0, 0, 5);
                textBlock.HorizontalAlignment = HorizontalAlignment.Stretch;
                textBlock.VerticalAlignment = VerticalAlignment.Stretch;
                textBlock.PreviewTextInput += (object sender, TextCompositionEventArgs e) =>
                {
                    Regex regex = new Regex("[^0-9]+");
                    e.Handled = regex.IsMatch(e.Text);
                };

                Grid.SetColumn(textBlock, 1);

                BindingOperations.SetBinding(textBlock, TextBox.TextProperty, binding);
                Property.Children.Add(textBlock);
            }

            else if (property.Type == PropertyType.CheckBox)
            {
                CheckBox ckeckBox = new CheckBox();
                Binding binding = new Binding("Test");
                binding.Source = DataContext;
                binding.Mode = BindingMode.TwoWay;
                binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

                ckeckBox.Margin = new Thickness(0, 0, 0, 5);
                ckeckBox.HorizontalAlignment = HorizontalAlignment.Stretch;
                ckeckBox.VerticalAlignment = VerticalAlignment.Center;

                Grid.SetColumn(ckeckBox, 1);

                BindingOperations.SetBinding(ckeckBox, CheckBox.IsCheckedProperty, binding);
                Property.Children.Add(ckeckBox);
            }

        }
    }
}
