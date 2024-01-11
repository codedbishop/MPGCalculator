using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPGCalculator
{
    internal class Vehicle
    {
        public string bodyType { get; set; }//this is the body type of the vehicle     
        public string make;//This is the vehicle make    
        public string model;//This is the vehicle model      
        public int mpg { get; set; }
        public int tankSize;

        //Constructer creates a new vehicle 
        public Vehicle(string make, string model, int mpg, int tankSize)
        {
            this.make = make;
            this.model = model;
            this.mpg = mpg;
            this.tankSize = tankSize;
        }

        //Displays the vehicle name with the corresponding int option for selection  
        public void display(int count)
        {
            Console.WriteLine(count + " : " + make + " " + model);
        }

        //Displays the vehicle name
        public void DisplayVehicleName()
        {
            Console.Write(make + ", " + model);
        }

        //Function calculates the range that the vehicle can travel and then displays it   
        public void GetMaxRange()
        {
            Console.Write("The ");
            DisplayVehicleName();
            Console.WriteLine(" can travel " + (tankSize * mpg + " on a full tank of gas"));
            Console.WriteLine();
        }

        //Function calculates the total fuel that will be used and then displays it    
        public void GetFuelUsed(float milesTraveled)
        {
            Console.WriteLine("You will use " + (milesTraveled / mpg).ToString("0.00") + " Gallons.");
            GetTanksUsed(milesTraveled);
        }

        //Function calculates the total fuel that will be used and then displays it    
        public void GetTanksUsed(float milesTraveled)
        {
            if (tankSize * mpg < milesTraveled)
            {
                Console.WriteLine("You will need to refill your tank " + (int)(milesTraveled /(tankSize * mpg) ) + " times.");
            }
            else
            {
                Console.WriteLine("You will not need to fill up.");
            }
            Console.WriteLine();
        }

    }
}
