using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPGCalculator
{
    internal class AddVehicle
    {
        //Asks the user what the make of the new vehicle is and then returns the input   
        public string GetMake()
        {
            Console.Write("What is the make of the vehicle you would like to add? ");
            return Console.ReadLine();
        }

        //Asks the user what the model of the new vehicle is and then returns the input   
        public string GetModel()
        {
            Console.Write("What is the model of the vehicle you would like to add? ");
            return Console.ReadLine();
        }

        //Asks the user what the mpg of the new vehicle is, then checks that is a int above 0 and returns it
        public int GetMPG()
        {
            int mpg = 0;

            while (mpg <= 0)
            {
                Console.Write("What is the mpg of the vehicle you would like to add? ");
                mpg = CheckForInt(Console.ReadLine());
            }
            return mpg;
        }

        //Asks the user what the tankeSize of the new vehicle is, then checks that is a int above 0 and returns it
        public int GetTankeSize()
        {
            int tankeSize = 0;
            while (tankeSize <= 0)
            {
                Console.Write("What is the tanke size of the vehicle you would like to add? ");
                tankeSize = CheckForInt(Console.ReadLine());
            }
            return tankeSize;
        }

        //Checks if a string is a int and returns the value if it is otherwise it returns 0 
        private int CheckForInt(string input)
        {
            if (int.TryParse(input, out int intInput))
            {
                return intInput;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter again.");
                return 0;
            }
        }
    }
}
