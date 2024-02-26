using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MPGCalculator
{
    internal class HybridVehicle: Vehicle
    {
        public int mpg { get; private set; }//saves the miles per gallons
        public int tankSize { get; private set; }//saves the size of the gas tank
        public int range { get; private set; }//saves the range of the vehicle


        //creates a new electric vehicle with loaded values
        public HybridVehicle(BodyStyles.bodyStyles bodyType, string make, string model,int mpg ,int tankSize, int range) : base(bodyType, make, model)
        {
            vehicleType = "Hybrid";
            this.mpg = mpg;
            this.tankSize = tankSize;
            this.range = range;
        }

        //creates a new electric vehicle with user input values 
        public HybridVehicle()
        {
            Console.WriteLine("What is the mpg?");
            mpg = inputValidation.CheckForInt();
            Console.WriteLine();
            Console.WriteLine("What is the gas take size?");
            tankSize = inputValidation.CheckForInt();
            Console.WriteLine();
            Console.WriteLine("What is the range?");
            range = inputValidation.CheckForInt();
            Console.WriteLine();
            vehicleType = "Hybrid";
        }

        //Function calculates the range that the vehicle can travel and then displays it  
        public override void PrintRange()
        {
            Console.Write("The ");
            DisplayVehicleName();
            Console.WriteLine($" can travel {range} miles on a full battery and it can also travail {(tankSize * mpg)} miles on a full tank of gas");
            Console.WriteLine();
        }

        ////Function calculates the total fuel that will be used as well as the battery and then displays it  
        public override void PrintVehicleInfo(int avgSpeed, float timeTraveled)
        {
            float milesTraveled = ((float)avgSpeed / 60) * timeTraveled;
            Console.WriteLine($"You will travel { milesTraveled.ToString("0.00")} miles.");
            if (milesTraveled >= range)
            {
                Console.WriteLine($"You will use your full battery as well as {((milesTraveled - range) / mpg).ToString("0.00")} Gallons of gas.");
            }
            else
            {
                Console.WriteLine("You can travel the distance on a full battery.");
            }
            GetTanksUsed(milesTraveled);
        }


        //Function calculates the total times the battery needs to be charged and times the tank will need to be refueled and then displays it    
        private void GetTanksUsed(float milesTraveled)
        {
            if(milesTraveled > range)
            {
                if (tankSize * mpg < milesTraveled)
                {
                    Console.WriteLine($"You will need to refill your tank and charge your battery {(int)(milesTraveled / ((tankSize * mpg) + range))} times.");
                }
                else
                {
                    Console.WriteLine("You will use all your battery but you will not need to fill up your tank.");
                }
            }
            else 
            {
                Console.WriteLine("You will not use your full battery and you will not need to fill up your tank.");
            }
            Console.WriteLine();
        }
    }
}
