using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPGCalculator
{
    internal class GasVehicle: Vehicle
    {
        public int mpg { get; private set; }//saves the miles per gallons
        public int tankSize { get; private set; }//saves the size of the gas tank
        
        //creates a new gas vehicle with loaded values
        public GasVehicle(BodyStyles.bodyStyles bodyType, string make, string model, int mpg, int tankSize) : base(bodyType, make, model)
        {
            vehicleType = "Gas";
            this.mpg = mpg;
            this.tankSize = tankSize;
        }

        //creates a new gas vehicle with user input values 
        public GasVehicle()
        {
            Console.WriteLine("What is the mpg?");
            mpg = inputValidation.CheckForInt();
            Console.WriteLine();
            Console.WriteLine("What is the gas take size?");
            tankSize = inputValidation.CheckForInt();
            Console.WriteLine();
            vehicleType = "Gas";
        }

        //Function calculates the range that the vehicle can travel and then displays it  
        public override void PrintRange()
        {
            Console.Write("The ");
            DisplayVehicleName();
            Console.WriteLine($" can travel {(tankSize * mpg)} miles on a full tank of gas");
            Console.WriteLine();
        }

        ////Function calculates the total fuel that will be used and then displays it  
        public override void PrintVehicleInfo(int avgSpeed, float timeTraveled)
        {
            float milesTraveled = ((float)avgSpeed / 60) * timeTraveled;
            Console.WriteLine($"You will travel {milesTraveled.ToString("0.00")} miles.");
            Console.WriteLine($"You will use {(milesTraveled / mpg).ToString("0.00")} Gallons of gas.");
            GetTanksUsed(milesTraveled);
        }


        //Function calculates the total fuel that will be used and then displays it    
        private void GetTanksUsed(float milesTraveled)
        {
            if (tankSize * mpg < milesTraveled)
            {
                Console.WriteLine($"You will need to refill your tank {(int)(milesTraveled / (tankSize * mpg))} times.");
            }
            else
            {
                Console.WriteLine("You will not need to fill up.");
            }
            Console.WriteLine();
        }
    }
}
