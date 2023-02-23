using System;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using AwesomeProperties;
using AwesomeProperties.Attribute;
using AwesomeProperties.Page.ViewModel;
using Xceed.Wpf.Toolkit;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour PropertyElement.xaml
    /// </summary>
    public partial class PropertyElement : UserControl
    {

        public PropertyElement(PropertiesPanel panel,Type baseType, PropertyInfo nameInfo, PropertyInfo valueInfo, Object data, PropertyListField property, Object baseData)
        {

            var view = new PropertyListElementViewModel();
            view.Panel = panel;
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
                binding.UpdateSourceTrigger = property.UpdateSourceTrigger;

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
                binding.UpdateSourceTrigger = property.UpdateSourceTrigger;

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
                binding.UpdateSourceTrigger = property.UpdateSourceTrigger;

                ckeckBox.Margin = new Thickness(0, 0, 0, 5);
                ckeckBox.HorizontalAlignment = HorizontalAlignment.Stretch;
                ckeckBox.VerticalAlignment = VerticalAlignment.Center;

                Grid.SetColumn(ckeckBox, 1);

                BindingOperations.SetBinding(ckeckBox, CheckBox.IsCheckedProperty, binding);
                Property.Children.Add(ckeckBox);
            }

            else if (property.Type == PropertyType.Dropdown)
            {
                ComboBox comboBox = new ComboBox();
                Binding binding = new Binding("Test");
                binding.Source = DataContext;
                binding.Mode = BindingMode.TwoWay;
                binding.UpdateSourceTrigger = property.UpdateSourceTrigger;

                comboBox.Margin = new Thickness(0, 0, 0, 5);
                comboBox.HorizontalAlignment = HorizontalAlignment.Stretch;
                comboBox.VerticalAlignment = VerticalAlignment.Center;
                comboBox.ItemsSource = ((DropDown)(data)).Options;

                Grid.SetColumn(comboBox, 1);

                BindingOperations.SetBinding(comboBox, ComboBox.SelectedItemProperty, binding);
                Property.Children.Add(comboBox);
            }

            else if (property.Type == PropertyType.ColorField)
            {
                ColorPicker colorpicker = new ColorPicker();
                Binding binding = new Binding("Test");
                binding.Source = DataContext;
                binding.Mode = BindingMode.TwoWay;
                binding.UpdateSourceTrigger = property.UpdateSourceTrigger;

                colorpicker.Margin = new Thickness(0, 0, 0, 5);
                colorpicker.HorizontalAlignment = HorizontalAlignment.Stretch;
                colorpicker.Height = 25;
                colorpicker.VerticalAlignment = VerticalAlignment.Center;
                colorpicker.ShowStandardColors = false;
                colorpicker.ColorMode = ColorMode.ColorCanvas;
                colorpicker.DropDownBackground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF5E5E5E"));
                colorpicker.TabBackground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3D3D3D"));
                colorpicker.TabForeground = new SolidColorBrush(Colors.White);
                colorpicker.DropDownBorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF262626"));
                colorpicker.DropDownBorderThickness = new Thickness(2);
                Grid.SetColumn(colorpicker, 1);

                BindingOperations.SetBinding(colorpicker, ColorPicker.SelectedColorProperty, binding);
                Property.Children.Add(colorpicker);
            }
        }

        public PropertyElement(PropertiesPanel panel,Type baseType, PropertyInfo target, Object data, PropertyField property)
        {
            var view = new PropertyElementViewModel();
            view.Panel = panel;
            view.baseType = baseType;
            view.target = target;
            view.data = data;
            view.baseTypeData = data;
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
                binding.UpdateSourceTrigger = property.UpdateSourceTrigger;

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
                binding.UpdateSourceTrigger = property.UpdateSourceTrigger;

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
                binding.UpdateSourceTrigger = property.UpdateSourceTrigger;

                ckeckBox.Margin = new Thickness(0, 0, 0, 5);
                ckeckBox.HorizontalAlignment = HorizontalAlignment.Stretch;
                ckeckBox.VerticalAlignment = VerticalAlignment.Center;

                Grid.SetColumn(ckeckBox, 1);

                BindingOperations.SetBinding(ckeckBox, CheckBox.IsCheckedProperty, binding);
                Property.Children.Add(ckeckBox);
            }

            else if (property.Type == PropertyType.Dropdown)
            {
                ComboBox comboBox = new ComboBox();
                Binding binding = new Binding("Test");
                binding.Source = DataContext;
                binding.Mode = BindingMode.TwoWay;
                binding.UpdateSourceTrigger = property.UpdateSourceTrigger;

                comboBox.Margin = new Thickness(0, 0, 0, 5);
                comboBox.HorizontalAlignment = HorizontalAlignment.Stretch;
                comboBox.VerticalAlignment = VerticalAlignment.Center;
                comboBox.ItemsSource = ((DropDown)target.GetValue(data)).Options;

                Grid.SetColumn(comboBox, 1);

                BindingOperations.SetBinding(comboBox, ComboBox.SelectedItemProperty, binding);
                Property.Children.Add(comboBox);
            }

            else if (property.Type == PropertyType.ColorField)
            {
                ColorPicker colorpicker = new ColorPicker();
                Binding binding = new Binding("Test");
                binding.Source = DataContext;
                binding.Mode = BindingMode.TwoWay;
                binding.UpdateSourceTrigger = property.UpdateSourceTrigger;

                colorpicker.Margin = new Thickness(0, 0, 0, 5);
                colorpicker.HorizontalAlignment = HorizontalAlignment.Stretch;
                colorpicker.Height = 25;
                colorpicker.VerticalAlignment = VerticalAlignment.Center;
                colorpicker.ShowStandardColors = false;
                colorpicker.ColorMode = ColorMode.ColorCanvas;
                colorpicker.DropDownBackground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF5E5E5E"));
                colorpicker.TabBackground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3D3D3D"));
                colorpicker.TabForeground = new SolidColorBrush(Colors.White);
                colorpicker.DropDownBorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF262626"));
                colorpicker.DropDownBorderThickness = new Thickness(2);

                Grid.SetColumn(colorpicker, 1);

                BindingOperations.SetBinding(colorpicker, ColorPicker.SelectedColorProperty, binding);
                Property.Children.Add(colorpicker);
            }
        }
    }
}
