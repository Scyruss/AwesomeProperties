# AwesomeProperties

## Setup

Install on nuget market place or at this link: https://www.nuget.org/packages/AwesomeProperties/

## Sample

Example with a listview bind with a custom class ElectricCar and ThermalCar inherit from a class Car

![alt text](https://raw.githubusercontent.com/Scyruss/AwesomeProperties/main/Tesla.png)
![alt text](https://raw.githubusercontent.com/Scyruss/AwesomeProperties/main/Opel.png)

Awesome properties also support graphics library like WPF-UI:

![alt text](https://raw.githubusercontent.com/Scyruss/AwesomeProperties/main/WPFUI.png)

### Basic Usage

To show on the properties window you should mark with PropertyField attribute

Some property type are available:²
```CS
    public enum PropertyType
    {
        None,
        Text,
        Int,
        CheckBox,
        Dropdown
    }
```

Basic class declaration:
```CS
    public class Example
    {
        [PropertyField(PropertyType.Text, "Name")]
        public string Name { get; set; }

        [PropertyField(PropertyType.Text, "Model")]
        public string Model { get; set; }

        public Example()
        {

        }
    }

```

Create new instance of your custom class
```CS

    public class MainWindow
    {
        public Example MyCustomClass{ get; set;}

        public Example()
        {
            MyCustomClass = new Example();
        }
    }
```

To show the properties panel:
```CS

    public void ShowProperties(){
        //Put your data to bind in the constructor of PropertiesPanel
        PropertiesPanel panel = new PropertiesPanel(MyCustomClass);
        
        //Add the property panel to a container
        MyGrid.Children.Clear();
        MyGrid.Children.Add(panel);
    }
```

### Advance Usage

```CS

    public class Example
    {
        [PropertyField(PropertyType.Text, "Name")]
        public string Name { get; set; }

        [PropertyField(PropertyType.Text, "Model")]
        public string Model { get; set; }

        public Example()
        {

        }
    }
```

