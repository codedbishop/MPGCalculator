using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace MPGCalculator
{
    internal class SaveLoad
    {
        string fileName = "SavedVehicles.txt";
        //This function saves the list of vehicles to the file name
        public void SaveList(List<Vehicle> vehicles)
        {
            string path = Path.Combine(Environment.CurrentDirectory, fileName);//Sets the path to be saved  

            using (StreamWriter writer = new StreamWriter(path))
            {
                //Saves each vehicle in the list to the file   
                foreach (var vehicle in vehicles)
                {
                    switch (vehicle)
                    {
                        case GasVehicle gasVehicle:
                            writer.WriteLine($"{gasVehicle.vehicleType},{gasVehicle.bodyType},{gasVehicle.make},{gasVehicle.model},{gasVehicle.mpg},{gasVehicle.tankSize}");
                            break;
                        case HybridVehicle hybridVehicle:
                            writer.WriteLine($"{hybridVehicle.vehicleType},{hybridVehicle.bodyType},{hybridVehicle.make},{hybridVehicle.model},{hybridVehicle.mpg},{hybridVehicle.tankSize},{hybridVehicle.range}");
                            break;
                        case ElectricVehicle electricVehicle:
                            writer.WriteLine($"{electricVehicle.vehicleType},{electricVehicle.bodyType},{electricVehicle.make},{electricVehicle.model},{electricVehicle.range}");
                            break;
                    }
                }
            }
        }

        //This Function loads all the vehicles from the file and saves them as a list of vehicles and returns the list 
        public List<Vehicle> LoadList()
        {
           
            List<Vehicle> loadedVehicles = new List<Vehicle>();
            string path = Path.Combine(Environment.CurrentDirectory, fileName);//Gets the file path 

            //Checks if the file exists 
            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');//Separates the words into a list of strings

                        switch (parts[0])
                        {
                            case "Gas":
                                if (Enum.TryParse(parts[1], out BodyStyles.bodyStyles gasBodyType))
                                {
                                    loadedVehicles.Add(new GasVehicle(gasBodyType, parts[2], parts[3], int.Parse(parts[4]), int.Parse(parts[5])));
                                }
                                break;
                            case "Hybrid":
                                if (Enum.TryParse(parts[1], out BodyStyles.bodyStyles hybridBodyType))
                                {
                                    loadedVehicles.Add(new HybridVehicle(hybridBodyType, parts[2], parts[3], int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6])));
                                }
                                break;
                            case "Electric":
                                if (Enum.TryParse(parts[1], out BodyStyles.bodyStyles electricBodyType))
                                {
                                    loadedVehicles.Add(new ElectricVehicle(electricBodyType, parts[2], parts[3], int.Parse(parts[4])));
                                }
                                break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("File Not found");
            }

            return loadedVehicles;//returns the list of vehicles 
        }
    }
}
