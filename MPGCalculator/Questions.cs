using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPGCalculator
{
    internal class Questions
    {
        int avgSpeed;
        float travelTime;
        int totalMinutesTraveled;
        public bool testBool = true;


        //Function gets user input for speed and checks that it is a int and if not return false 
        public bool SetAvgSpeed()
        {
            Console.Write("What is the average speed per hour? ");
            if (int.TryParse(Console.ReadLine(), out avgSpeed))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid input entered. Please enter number.");
                return false;
            }  
        }

        //Function gets user input for time traveled and checks that it is a float and if not return false 
        public bool SetTravelTime()
        {
            Console.Write("What is the time that was traveled? (Example 5.5 would be 5 hours and 30 minutes) ");
            if (float.TryParse(Console.ReadLine(), out travelTime))
            {
                totalMinutesTraveled = ((int)travelTime * 60) + ((int)(travelTime % 1.0f) * 60);
                return true;
            }
            else
            {
                Console.WriteLine("Invalid input entered. Please enter number.");
                return false;
            }
        }

        //Calculates the total miles traveled and then displays it 
        public float Calculate()
        {         
            float milesTraveled = ((float)avgSpeed / 60) * (float)totalMinutesTraveled;
            Console.WriteLine("You will travel " + milesTraveled.ToString("0.00") + " miles.");
            return milesTraveled;
        }
    }
}
