using AwesomeProperties.Attribute;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1;

namespace Example.ViewModel
{
    public class CarViewModel: INotifyPropertyChanged
    {
        public MainWindow View { get => (MainWindow)ViewsAccessibility.GetCorresponingWindow(this); }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public CarViewModel()
        {
            
        }

        private Car selectedCar;
        public Car SelectedCar
        {
            get => selectedCar;
            set
            {
                selectedCar = value;
                NotifyPropertyChanged(nameof(SelectedCar));

                var propertiesPanel = new PropertiesPanel(selectedCar);
                propertiesPanel.OnPropertieChanged += OnPropertieChanged;

                Properties = propertiesPanel;
            }
        }


        private ObservableCollection<Car> cars;
        public ObservableCollection<Car> Cars 
        {
            get => cars;
            set
            {
                cars = value;
                NotifyPropertyChanged(nameof(Cars));
            }
        }

        private UIElement properties;
        public UIElement Properties
        {
            get => properties;
            set
            {
                properties = value;

                View.PropertiesPanel.Children.Clear();
                View.PropertiesPanel.Children.Add(properties);
            }
        }


        private void OnPropertieChanged()
        {
            View.CarsList.Items.Refresh();
        }
    }
}
