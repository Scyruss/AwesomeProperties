# AwesomeProperties

## Setup

Install on nuget market place or at this link: https://www.nuget.org/packages/AwesomeProperties/

## Sample

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
