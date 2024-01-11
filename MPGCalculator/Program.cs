using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;



namespace MPGCalculator
{
    class Program
    {
        static VehicleListDisplay vehicleListDisplay = new VehicleListDisplay();
        static Questions questions = new Questions();
        static VehicleTypeSelector vehicleTypeSelector = new VehicleTypeSelector(vehicleListDisplay);

        //Main entry point of the program
        static void Main(string[] args)
        {
            vehicleListDisplay.LoadData();
            ChooseVehicleType();
            Console.ReadLine();
        }

        //Function that askes the user to input vehicle type
        private static void ChooseVehicleType()
        {
            vehicleTypeSelector.ChooseType();
            CheckForVehicle();
        }

        //Function askes user to select vehicle from list or to create a new vehicle
        private static void CheckForVehicle()
        {
            if (vehicleListDisplay.selectedVehicle != null) 
            {
                ProcessVehicle();
            }
            else
            {
                //If vehicle is not in list function will have user create new vehicle
                vehicleListDisplay.CreateNewVehicle(vehicleTypeSelector.type);
                ChooseVehicleType();
            }
        }

        //Function gets and displays the range of the vehicle 
        private static void ProcessVehicle()
        {
            vehicleListDisplay.selectedVehicle.GetMaxRange();//Calculates the maximum range a vehicle can go on one take of gas 
            AskQuestions();//Askes the user for needed information about to calculate 
        }

        //Fuction asks the user for the speed, and time traviled
        private static void AskQuestions() 
        {
            while (!questions.SetAvgSpeed()) { }//Asks for the average speed traveled 
            while (!questions.SetTravelTime()) { }//Gets the time traveled 

            Console.WriteLine();//Adds empty line
            CalculateVehicleStats();//Calculates the mpg  
        }

        //Function calculates the total miles traveled, gallons used, and the times needed to refill
        private static void CalculateVehicleStats()
        {
            vehicleListDisplay.selectedVehicle.GetFuelUsed(questions.Calculate()); //Gets and displays vehicle calculations
            YesOrNoAction("Do you want to calculate with a new vehicle? (Yes or No)", AskQuestions, AskForNewVehicle);//Asks if the user wants to run another calculation with the same vehicle 
        }

        //asks if the user want to check a different type of vehicle
        private static void AskForNewVehicle()
        {
            YesOrNoAction("Do you want to calculate a new vehicle body type a new vehicle Type? (Yes or No)", ChooseVehicleType, ExitProgram);//Asks if the user wants to run another calculation with the same vehicle
        }

        //Fuction checks if user enters yes or no then does the corresponding method 
        private static void YesOrNoAction(string question, Action yesAction, Action noAction)
        {
            Console.WriteLine(question);

            string answer = Console.ReadLine()?.ToLower();//Gets the answer the user inputs and lower cases it
            Console.WriteLine();//Adds empty line;

            if (answer == "yes")
            {
                yesAction();
            }
            if (answer == "no")
            {
                noAction();
            }
            else
            {
                Console.WriteLine("Invalid answer. Please answer again.");
                YesOrNoAction(question, yesAction, noAction);//Loops through the same method if invalid answer is given
            }
        }

        //Exits the program 
        private static void ExitProgram()
        {
            Environment.Exit(0);
        } 
    }
}
