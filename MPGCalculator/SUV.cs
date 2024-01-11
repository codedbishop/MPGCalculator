using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPGCalculator
{
    internal class SUV : Vehicle
    {
        public SUV(string make, string model, int mpg, int tankSize) : base(make, model, mpg, tankSize) 
        {
            bodyType = "SUV";
        }

    }
}
