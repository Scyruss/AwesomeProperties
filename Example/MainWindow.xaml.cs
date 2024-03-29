﻿using Example.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
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
using WpfApp1;

namespace Example
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : UiWindow
    {
        public CarViewModel ViewModel { get { return (CarViewModel)(DataContext); } }

        public MainWindow()
        {
            InitializeComponent();

            ViewModel.Cars = new System.Collections.ObjectModel.ObservableCollection<Car>();

            ViewModel.Cars.Add(new ElectricCar() { Name = "Tesla"});
            ViewModel.Cars.Add(new ThermalCar() { Name = "Opel"});
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in ViewModel.Cars)
            {
                item.Name = "test";
            }

            ((PropertiesPanel)ViewModel.Properties).RefreshProperties();
        }
    }
}
