using AwesomeProperties;
using AwesomeProperties.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    public class ElectricCar:Car
    {
        [PropertyField(PropertyType.Int, "Motor Number", order: 10)]
        public int MotorNumber { get; set; }
    }
}
