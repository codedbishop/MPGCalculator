using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPGCalculator
{
    internal class ElectricVehicle: Vehicle
    {
        public int range { get; private set; }//saves the range of the vehicle

        //creates a new electric vehicle with loaded values
        public ElectricVehicle(BodyStyles.bodyStyles bodyType, string make, string model, int range) : base(bodyType, make, model)
        {
            vehicleType = "Electric";
            this.range = range;
        }

        //creates a new electric vehicle with user input values 
        public ElectricVehicle()
        {
            Console.WriteLine("What is the range?");
            range = inputValidation.CheckForInt();
            Console.WriteLine();
            vehicleType = "Electric";

        }

        //Function calculates the range that the vehicle can travel and then displays it  
        public override void PrintRange()
        {
            Console.Write("The ");
            DisplayVehicleName();
            Console.WriteLine($" can travel  {range} miles on a full battery.");
            Console.WriteLine();
        }

        ////Function calculates the total fuel that will be used and then displays it  
        public override void PrintVehicleInfo(int avgSpeed, float timeTraveled)
        {
            float milesTraveled = ((float)avgSpeed / 60) * timeTraveled;
            Console.WriteLine($"You will travel {milesTraveled.ToString("0.00")} miles.");
            GetNumberOfCharges(milesTraveled);
        }


        //Function calculates the total charges that will be needed and then displays it    
        private void GetNumberOfCharges(float milesTraveled)
        {
            if (range < milesTraveled)
            {
                Console.WriteLine($"You will need to charge your vehicle {(int)(milesTraveled / range)} times.");
            }
            else
            {
                Console.WriteLine("You will not need to charge your vehicle.");
            }
            Console.WriteLine();
        }
    }
}
