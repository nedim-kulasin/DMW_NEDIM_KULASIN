using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMV_GUI
{
    abstract class MotorVehicle
    {
        string VIN;
        string make;
        string model;
        DateTime dateOfProduction; //datetime , has to be >now
        protected int noOfWheels; //has to be >2 , <18
        protected int noOfSeats;  //has to be >=1

        public MotorVehicle() { }
        public MotorVehicle(string VIN, string make, string model, int noOfWheels, int noOfSeats, DateTime dateOfProduction)  //, int noOfWheels, int noOfSeats)
        {
            this.VIN = VIN;
            this.make = make;
            this.model = model;
            this.noOfSeats = noOfSeats;
            this.noOfWheels = noOfWheels;
            this.dateOfProduction = dateOfProduction;
        }



        //if VIN is valid return true, otherwise return false
        public bool SetVIN(string VIN)
        {
            if (VIN.Length != 17) return false;
            else return true;
        }

        public string show()
        {
            return string.Format("{1,17}{0}{2,15}{0}{3,15}{0}{4:MMddyy}{0}{5,1}{0}{6,2}", " ", VIN, make, model, dateOfProduction, noOfWheels, noOfSeats);
        }

        public const char fieldSeparator = '|';
        public const char recordSeparator = '\n';
        
    }

    class Truck : MotorVehicle
    {
        private double maxWeight;
        public Truck(string VIN, string make, string model, int noOfSeats, int noOfWheels, DateTime dateOfProduction, double maxWeight) : base(VIN, make, model, noOfSeats, noOfWheels, dateOfProduction)
        {
            this.maxWeight = maxWeight;
        }

        string show()
        {
            return "Truck " + "make and model " + fieldSeparator + " and has max weight of" + maxWeight + recordSeparator;
        }
        
    }

    //has to have >8 seats to be a bus
    class Bus : MotorVehicle
    {
        private string companyName;
        public Bus(string VIN, string make, string model, int noOfSeats, int noOfWheels, DateTime dateOfProduction, string companyName) : base(VIN, make, model, noOfSeats, noOfWheels, dateOfProduction)
        {
            this.companyName = companyName;
        }
        string show()
        {
            return "Bus " + "make and model " + fieldSeparator + ", company: " + companyName + recordSeparator;
        }
    }

    //has to have <8 seats to be a car
    class Car : MotorVehicle
    {
        private string color;
        private bool AC;
        private int airbags;
        public Car() { }
        public Car(string VIN, string make, string model, int noOfSeats, int noOfWheels, DateTime dateOfProduction, string color, bool AC, int airbags) : base(VIN, make, model, noOfSeats, noOfWheels, dateOfProduction)
        {
            this.color = color;
            this.AC = AC;
            this.airbags = airbags;
        }
        string show()
        {
            return "Car " + "make and model " + " in " + color + "has AC: " + AC + " and has" + airbags + "airbags.";
        }
    }

    class Taxi : Car
    {
        private bool licence;
        public Taxi(string VIN, string make, string model, int noOfSeats, int noOfWheels, DateTime dateOfProduction, string color, bool AC, int airbags, bool licence)
    {
        new Car(VIN, make, model, noOfSeats, noOfWheels, dateOfProduction, color, AC, airbags);
        this.licence = licence;
    }
        string show()
        {
            return "Taxi " + "make and model " + " and has the licence plate: " + licence;
        }
    }

    class Motorcycle : MotorVehicle
    {
        private double ccm;
        public Motorcycle(string VIN, string make, string model, int noOfSeats, int noOfWheels, DateTime dateOfProduction, double ccm)
            : base(VIN, make, model, noOfSeats, noOfWheels, dateOfProduction)
        {
            this.ccm = ccm;
        }
             string show()
        {
            return "Motorcycle " + "make and model " + " and has ccm of: " + ccm;
        }
    }
}
