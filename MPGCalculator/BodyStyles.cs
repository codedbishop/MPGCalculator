using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MPGCalculator
{
    internal class BodyStyles
    {
        InputValidation inputValidation = new InputValidation();  
        public enum bodyStyles { Sedan, Truck, SUV }
        private bodyStyles[] allBodyStyles = (bodyStyles[])Enum.GetValues(typeof(bodyStyles));
        
        
        
        public void DisplayStyles()
        {
            int option = 1;

            // Print each enum value
            foreach (bodyStyles bodyType in allBodyStyles)
            {
                Console.WriteLine(option + ": " + bodyType);
                option++;
            }
        }

        //gets the selected body type and then returns it
        public int SelectBodyType()
        {
            int selectedVehicle = inputValidation.CheckForInt();

            while (selectedVehicle == 0 || selectedVehicle > allBodyStyles.Length)
            {
                Console.WriteLine("Invalid number please type again");
                selectedVehicle = selectedVehicle = inputValidation.CheckForInt();
            }
            return selectedVehicle;
        }

        //asks the user what body type they would like to search and then returns 
        public bodyStyles SetBodyType()
        {
            DisplayStyles();
            return allBodyStyles[SelectBodyType() - 1];
        }
    }
}
