using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestSerialization
{
    public class Car
    {
        public System.Drawing.Color Color { get; set; }
        public string Rego { get; set; }
        public string DateOfManufacture { get; set; }

        public Car(Color color, string rego, string dateOfManufacture)
        {
            Color = Color.Black;
            Rego = rego;
            DateOfManufacture = dateOfManufacture;
        }

        public Car()
        {
        }

        

    }
}
