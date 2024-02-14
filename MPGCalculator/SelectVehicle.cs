using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPGCalculator
{
    internal class SelectVehicle
    {
        BodyStyles bodyStyles = new BodyStyles();
        InputValidation inputValidation = new InputValidation();
        public VehicleList vehicleList = new VehicleList(); 
        Vehicle selected = null;

        public SelectVehicle(VehicleList vehicleList)
        {
            this.vehicleList = vehicleList;
        }

        //Function that asks the user to input vehicle type
        public void ChooseVehicleType()
        {
            Console.WriteLine("What body type would you like to check for?");    
            vehicleList.GetVehiclesOfBodyType(bodyStyles.SetBodyType());
            vehicleList.DisplaySelectedVehicleList();
            Console.WriteLine();
            VehicleSelect();
        }

        //Gets the vehicle the user want to select and then checks that it exists     
        private void VehicleSelect()
        {
            do
            {
                int selectedVehicle = GetSelectedVehicle();

                selected = vehicleList.CheckVehicle(selectedVehicle);

                if (selected == null)
                {
                    Console.WriteLine("Invalid vehicle. Please try again.");
                }

            } while (selected == null);

            GetVehicleRange(selected);
            GetDistanceDrove();
        }
      

        //Gets the speed and the travel time and sends it as a argument to calculate car stats       
        private void GetDistanceDrove()
        {
            selected.PrintVehicleInfo(SetSpeed(), SetTravelTime());
            AskForNewCalculation();
        }

        //prints the range that the vehicle can drive        
        private void GetVehicleRange(Vehicle selectedVehicle)
        {
            selectedVehicle.PrintRange();
        }

        //Asks the user for the average speed that they are traveling         
        private int SetSpeed()
        {
            int speed = 0;
            Console.WriteLine("What is the average speed?");
            while (speed <= 0)
            {
                if(int.TryParse(Console.ReadLine(), out speed))//Checks that input is a int 
                {
                    Console.WriteLine();
                    return speed;
                }
                else
                {
                    Console.WriteLine("Invalid input entered. Please enter number.");
                    Console.WriteLine();
                }
            }
            return 0;
        }

        //Asks the user for the time that was traveled then converts it to minutes 
        private float SetTravelTime()
        {
            float travelTime = 0f;
            float totalMinutesTraveled = 0f;
            while (travelTime <= 0)
            {
                Console.WriteLine("What is the time that was traveled? (Example 5.5 would be 5 hours and 30 minutes) ");
                if (float.TryParse(Console.ReadLine(), out travelTime))
                {
                    totalMinutesTraveled = ((int)travelTime * 60) + ((int)(travelTime % 1.0f) * 60);
                    Console.WriteLine();
                    return totalMinutesTraveled;
                }
                else
                {
                    Console.WriteLine("Invalid input entered. Please enter number.");
                    Console.WriteLine();
                }
            }
            return 0;
        }

        //Asks the suer to enter a vehicle to select      
        public int GetSelectedVehicle()
        {
            int selectedVehicle = 0;

            do
            {
                Console.WriteLine("What vehicle would you like to search for?");
                selectedVehicle = inputValidation.CheckForInt();

                if (selectedVehicle == 0)
                {
                    Console.WriteLine("Invalid vehicle. Please try again.");
                    Console.WriteLine();
                }

            } while (selectedVehicle == 0);

            return selectedVehicle;
        }

        //Asks the user if the want to calculate with the current selected vehicle  
        private void AskForNewCalculation()
        {
            string userString = null;

            do
            {
                Console.WriteLine($"Do you want to calculate a new calculation using {selected.make}, {selected.model}? (yes or no)");
                userString = Console.ReadLine();
                if (!inputValidation.CheckForYesOrNo(userString))
                {
                    Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                    Console.WriteLine();
                }
            } while (!inputValidation.CheckForYesOrNo(userString));
            Console.WriteLine();
            if (userString == "yes")
            {
                GetDistanceDrove();
            }
            else
            {
                return;
            }  
        }
    }
}

