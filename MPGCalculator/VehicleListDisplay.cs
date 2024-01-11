using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MPGCalculator
{
    internal class VehicleListDisplay
    {
        List<Vehicle> vehicles = new List<Vehicle> ();
        List<Vehicle> pickedVehicles = new List<Vehicle> ();
        AddVehicle addVehicle = new AddVehicle();
        public Vehicle selectedVehicle { get; private set; }

        //Load Data from saved file and saves it as a list 
        public void LoadData()
        {
            vehicles = SaveLoad.LoadList("SavedVehicles.txt");
        }

        //Function finds out what type of vehicle to create when the user props program to add vehicle 
        public void CreateNewVehicle(string type)
        {
            Vehicle vehicle;

            Console.WriteLine();

            switch (type)
            {
                case "SUV":
                    vehicle = new SUV(addVehicle.GetMake(), addVehicle.GetModel(), addVehicle.GetMPG(), addVehicle.GetTankeSize());
                    SaveNewVehicle(vehicle);
                    break;
                case "Sedan":
                    vehicle = new Sedan(addVehicle.GetMake(), addVehicle.GetModel(), addVehicle.GetMPG(), addVehicle.GetTankeSize());
                    SaveNewVehicle(vehicle);
                    break;
                case "Truck":
                    vehicle = new Truck(addVehicle.GetMake(), addVehicle.GetModel(), addVehicle.GetMPG(), addVehicle.GetTankeSize());
                    SaveNewVehicle(vehicle);
                    break;

            }
        }

        //Function creates the vehicle adds it to the list and saves it to file 
        private void SaveNewVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);//Adds vehicle to the list 
            SaveLoad.SaveList(vehicles, "SavedVehicles.txt");//Saves list of vehicles 
            Console.WriteLine(vehicle.make + ", " + vehicle.model + " Added to list;");//Displays the car that was just added 
            Console.WriteLine();//Adds empty line 
        }

        //Function sorts the list of vehicles based on the body type and adds them to a list  
        public void SortPickedVehicle(string type)
        {
            pickedVehicles.Clear();//Clears the list of displayed vehicles
            foreach (var vehicle in vehicles) 
            {
                if (vehicle.bodyType.Equals(type))
                {
                    pickedVehicles.Add(vehicle);//Adds vehicle to the list 
                }
            }
            DisplayVehicles();//Displays the list of sorted vehicles 
        }

        //Displays the list of sorted vehicles with corresponding int option for user to enter 
        public void DisplayVehicles()
        {
            int count = 1;//Option number on
            //Loops through all the sorted vehicles in the list  
            foreach (var pickedVehicle in pickedVehicles)
            {
                pickedVehicle.display(count);//Displays the vehicle with the int option 
                count++;
            }
            Console.WriteLine(count + " : " + "Enter a new vehicle");//Number option to enter a new vehicle to list 
            Console.WriteLine();//Adds a blank line
            PickVehicle();//Gets the vehicle that the user wants to calculate 
        }

        //Function asks user to select vehicle from list then validates input    
        public void PickVehicle()
        {
            int vehicleSelected;
            Console.Write("Pick a Vehicle? ");

            if (int.TryParse(Console.ReadLine(), out vehicleSelected))//Checks that input is a int 
            {
                if (vehicleSelected <= pickedVehicles.Count && vehicleSelected > 0)//If input is one of the vehicles 
                {
                    selectedVehicle = pickedVehicles[vehicleSelected - 1];
                }
                else if (vehicleSelected == pickedVehicles.Count + 1)//If intoug is 1 more then the list of vehicles 
                {
                    selectedVehicle = null;
                }
                else
                {
                    Console.WriteLine("Vehicle doesn’t exist. Please enter the number for a new vehicle.");
                    PickVehicle();//Loops through the function if there is a invalid input  
                }
            }
            else //If input is not a then displays error and re-loops through method
            {
                Console.WriteLine("Invalid input entered. Please enter the number for a new vehicle.");
                PickVehicle();//Loops through the method if there is a invalid input  
            }
         
        } 
    }
}
