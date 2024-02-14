using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace MPGCalculator
{
    abstract internal class Vehicle
    {
        public InputValidation inputValidation = new InputValidation();
        public BodyStyles DisplayStyles = new BodyStyles();//sets the class that keeps the different body styles 
        public BodyStyles.bodyStyles bodyType { get; private set; }//this is the body type that the vehicle is
        public string vehicleType { get; set; }//This is the type of vehicle
        public string make { get; private set; }//This is the vehicle make    
        public string model { get; private set; }//This is the vehicle model      

        //Constructor creates a new vehicle with all values 
        public Vehicle(BodyStyles.bodyStyles bodyType, string make, string model)
        {
            this.bodyType = bodyType;
            this.make = make;
            this.model = model; 
        }

        //constructor creates a new vehicle 
        public Vehicle()
        {      
            Console.WriteLine("What is the body style of the vehicle?");
            SetBodyStyle();
            Console.WriteLine();
            Console.WriteLine("What is the make of the vehicle?");
            make = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("What is the model of the vehicle?");
            model = Console.ReadLine();
            Console.WriteLine();
        }

        //returns the range of the vehicle 
        public virtual void PrintRange() 
        {
            return;
        }

        //returns vehicle stats 
        public virtual void PrintVehicleInfo(int speed, float timeTraveled)
        {
            return;
        }

        //returns the vehicle name
        public void DisplayVehicleName()
        {
            Console.Write(make + ", " + model);
        }

        //sets the body style for the vehicle 
        private void SetBodyStyle()
        {
            bodyType = DisplayStyles.SetBodyType();
        }      
    }
}
