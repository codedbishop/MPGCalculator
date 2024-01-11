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
        //This function saves the list of vehicles to the file name
        public static void SaveList(List<Vehicle> vehicles, string fileName)
        {
            string path = Path.Combine(Environment.CurrentDirectory, fileName);//Sets the path to be saved  

            using (StreamWriter writer = new StreamWriter(path))
            {
                //Saves each vehicle in the list to the file   
                foreach (var vehicle in vehicles)
                {
                    writer.WriteLine($"{vehicle.bodyType},{vehicle.make},{vehicle.model},{vehicle.mpg},{vehicle.tankSize}");
                }
            }
        }

        //This Function loads all the vehicles from the file and saves them as a list of vehicles and returns the list 
        public static List<Vehicle> LoadList(string fileName)
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

                        //Checks that the data has the correct number variables, then creates the correct vehicle type and adds it to the list 
                        if (parts.Length == 5)
                        {
                            if (parts[0] == "SUV")
                            {
                                loadedVehicles.Add(new SUV(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4])));
                            }
                            else if (parts[0] == "Sedan")
                            {
                                loadedVehicles.Add(new Sedan(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4])));
                            }
                            else if (parts[0] == "Truck")
                            {
                                loadedVehicles.Add(new Truck(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4])));
                            }
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
