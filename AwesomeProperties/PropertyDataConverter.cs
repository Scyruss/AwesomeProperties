using AwesomeProperties.Attribute;
using System;
using System.Reflection;


namespace AwesomeProperties
{
    internal class PropertyDataConverter
    {
        public static object CheckData(PropertyInfo target, PropertyField field, object value)
        {
            if (target.PropertyType.Name.ToLower().Contains("string") && field.Type == PropertyType.CheckBox)
            {
                if (string.IsNullOrEmpty(value.ToString()))
                    return false.ToString();
                else
                    return value.ToString();
            }

            if (target.PropertyType.Name.Contains("Int"))
            {
                if (string.IsNullOrEmpty(value.ToString()))
                    return 0;
                else
                    return Convert.ToInt32(value.ToString());
            }
            else
                return value;
        }
    }
}
