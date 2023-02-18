using AwesomeProperties;
using AwesomeProperties.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    public class ThermalCar:Car
    {
        [PropertyField(PropertyType.Int, "Cylinder Number",order:10)]
        public int CylinderNumber { get; set; }
    }
}
