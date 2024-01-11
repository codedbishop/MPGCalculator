using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MPGCalculator
{
    internal class VehicleTypeSelector
    {
        
        
        private VehicleListDisplay vehicleListDisplay;
        public string type { get; private set; }

        //Saves a instance of VehicleTypeSelector for this class to use 
        public VehicleTypeSelector(VehicleListDisplay vehicleListDisplay)
        {
            this.vehicleListDisplay = vehicleListDisplay;
        }

        //Function asks the user to chose a vehicle body type that they want to calculate
        public void ChooseType()
        {
            Console.Write("Type in the type of Vehicle body type that you would like to Calculate? (Truck, SUV, or Sedan) ");
           
            type = Console.ReadLine()?.ToLower();//Adds empty line and ignores uppercase  
            GetType();//Gets the type of vehicle body type based on user input 
        }

        //Function chechks if the user input a body type that exists and if not asks the user to type again 
        public void GetType()
        {
            switch (type)
            {
                case "suv":
                    Console.WriteLine("List of SUV's");
                    type = "SUV";
                    vehicleListDisplay.SortPickedVehicle(type);
                    break;
                case "sedan":
                    Console.WriteLine("List of Sedan's");
                    type = "Sedans";
                    vehicleListDisplay.SortPickedVehicle(type);
                    break;
                case "truck":
                    Console.WriteLine("List of Sedan's");
                    type = "Truck";
                    vehicleListDisplay.SortPickedVehicle(type);
                    break;
                default:
                    Console.WriteLine("Invaled Input, Please Type again");
                    ChooseType();//Asks the user again for the body type 
                    break;

            }
        }
    }
}
