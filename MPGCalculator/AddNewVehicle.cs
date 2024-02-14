using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPGCalculator
{
    internal class AddNewVehicle
    {
        InputValidation inputValidation = new InputValidation();

        //Asks the user what type of vehicle the would like to add then creates the vehicle    
        public Vehicle AddVehicle()
        {
            DisplayVehicleMenu();
            int selected = GetUserInputForVehicleType();
            Vehicle vehicle = CreateVehicle(selected);
            return vehicle;  
        }

        //Displays a list of available vehicle types to add   
        private void DisplayVehicleMenu()
        {
            Console.WriteLine("What type of Vehicle would you like to add?");
            Console.WriteLine("1: Gas");
            Console.WriteLine("2: Hybrid");
            Console.WriteLine("3: Electric");
        }

        //Checks the user input for the selected vehicle type     
        private int GetUserInputForVehicleType()
        {
            int selected;
            do
            {
                selected = inputValidation.CheckForInt();
            } while (selected < 1 || selected > 3);

            return selected;
        }

        //Creates a new vehicle of the type that was selected      
        private Vehicle CreateVehicle(int selected)
        {
            switch (selected)
            {
                case 1:
                    return new GasVehicle();
                case 2:
                    return new HybridVehicle();
                case 3:
                    return new ElectricVehicle();
                default:
                    Console.WriteLine("Vehicle Type Error");
                    return null;
            }
        }
    }
}
