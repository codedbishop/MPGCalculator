using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace MPGCalculator
{
    internal class VehicleList
    {
        private List<Vehicle> vehicles = new List<Vehicle>();
        private List<Vehicle> vehiclesOfBodyType = new List<Vehicle>();
        SaveLoad saveLoad = new SaveLoad();

        //Create a list of vehicles 
        public void CreateListOfVehicles()
        {
            vehicles.Clear();
            vehicles = saveLoad.LoadList();
        }

        //Get a list of the selected body type 
        public bool GetVehiclesOfBodyType(BodyStyles.bodyStyles bodyType)
        {
            Console.WriteLine($"The body type is {bodyType}");
            vehiclesOfBodyType.Clear();

            vehiclesOfBodyType = vehicles.Where(vehicle => vehicle.bodyType == bodyType).ToList();
            return vehiclesOfBodyType.Any();
        }

        //Display a list of the vehicles with the selected body type and give them a number for user to select 
        public void DisplaySelectedVehicleList()
        {
            int numberOn = 1;
            foreach (var vehicle in vehiclesOfBodyType)
            {
                Console.WriteLine($"{numberOn}: {vehicle.make}, {vehicle.model}");
                numberOn++;
            }
            Console.WriteLine();
        }

        //Checks that the user selected a vehicle that exists 
        public Vehicle CheckVehicle(int selected)
        {
            if (selected > 0 && selected <= vehiclesOfBodyType.Count)
            {
                return vehiclesOfBodyType[selected - 1];//Remove 1 from number to account for 0 index in list 
            }
            return null;
        }

        //Add a new vehicle and return the list of vehicles to be saved 
        public void AddVehicle(Vehicle newVehicle)
        {
            vehicles.Add(newVehicle);
            saveLoad.SaveList(vehicles);
            CreateListOfVehicles();
            return;
        }
    }
}
