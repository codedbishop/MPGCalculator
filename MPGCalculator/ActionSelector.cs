using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MPGCalculator
{
    internal class ActionSelector
    {
        VehicleList vehicleList = new VehicleList();//creates a class for the list of vehicles 
        SelectVehicle selectVehicle;//creates class to select the vehicles 
        AddNewVehicle addNewVehicle = new AddNewVehicle();//creates class to add a new vehicle 
        InputValidation inputValidation = new InputValidation();//creates a class to validate input 
        
        //loads and creates a list of vehicles 
        public void CreateList()
        {
            vehicleList.CreateListOfVehicles();
            selectVehicle = new SelectVehicle(vehicleList);  
        }

        //Displays a list of options user can select then gets the selected option  
        public void GetSelectedOption()
        {
            int selectedOption;
            do
            {
                DisplayMenu();
                selectedOption = inputValidation.CheckForInt();
                Console.WriteLine();
            } while (selectedOption == 0);
            ExecuteSelectedOption(selectedOption);
        }

        //List of options the user can select   
        private void DisplayMenu()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1: Calculate Vehicle.");
            Console.WriteLine("2: Add a new Vehicle.");
            Console.WriteLine("3: Exit.");
        }

        //Function that executes the option that the user selected    
        private void ExecuteSelectedOption(int selectedOption)
        {
            switch (selectedOption)
            {
                case 1:
                    selectVehicle.ChooseVehicleType();
                    break;
                case 2:
                    vehicleList.AddVehicle(addNewVehicle.AddVehicle());
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("That was not a option. Please type again");
                    GetSelectedOption();
                    break;
            }
            GetSelectedOption();
        }

    }
}
