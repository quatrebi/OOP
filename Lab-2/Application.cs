using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_2
{
    class Application
    {
        static void Main(string[] args)
        {
            Driver driver = new Driver();
            Bus bus = new Bus
            {
                Driver = driver,
                BusNumber = "4725 IT-1"
            };
            Console.WriteLine(bus);
            Console.ReadKey();
        }
    }

    public class Bus
    {
        // Fields
        private Driver _driver;
        private string _busNumber;
        private short _wayNumber;
        private string _brand;
        private DateTime _startDate;
        private long _mileage;

        // Properties
        public Driver Driver
        {
            get { return _driver; }
            set { _driver = value; }
        }

        public string BusNumber
        {
            get { return _busNumber; }
            set
            {
                if (Regex.IsMatch(value, @"\d{4}\s\w{2}-[1-7]"))
                    _busNumber = value;
                else
                    Console.Error.WriteLine("[Class.Bus.BusNumber] Number mismatch with format.");
            }
        }
        public short WayNumber
        {
            get { return _wayNumber; }
            set { _wayNumber = value; }
        }

        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public long Mileage
        {
            get { return _mileage; }
            private set { _mileage = value; }
        }

        // Methods

        public override string ToString()
        {
            return $"{_brand}[{BusNumber}] {_startDate} {_mileage}kms | {Driver} - {_wayNumber}";
        }
    }

    public class Driver
    {
        string _firstName;
        string _lastName;

        public string Firstname
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string Lastname
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        Driver()
        {
            _firstName = String.Empty;
            _lastName = String.Empty;
        }

        public Driver(string firstname = "Dmitriy", string lastname = "Khudnitskiy") : this()
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public override string ToString()
        {
            return $"{_firstName} {_lastName}";
        }
    }
}
