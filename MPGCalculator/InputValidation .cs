using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPGCalculator
{
    internal class InputValidation
    {
        //Checks that a string is a yes or a no          
        public bool CheckForYesOrNo(string stringToCheck)
        {
            return stringToCheck.ToLower() == "yes" || stringToCheck.ToLower() == "no";
        }

        //Checks that a input is a int        
        public int CheckForInt()
        {
            int userAnswer = 0;

            if (int.TryParse(Console.ReadLine(), out userAnswer))//Checks that input is a int 
            {
                return userAnswer;
            }
            return 0;
        }
    }
}
