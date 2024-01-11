using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPGCalculator
{
    internal class Truck : Vehicle
    {
        public Truck(string make, string model, int mpg, int tankSize) : base(make, model, mpg, tankSize)
        {
            bodyType = "Truck";
        }
    }
}
