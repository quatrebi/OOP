using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_2
{
    class Application
    {
        public static Random rand;
        static void Main(string[] args)
        {
            rand = new Random(DateTime.Now.Millisecond);

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

    public partial class Bus
    {
        // Fields
        private readonly long _id;
        private Driver _driver;
        private string _busNumber;
        private short _wayNumber;
        private string _brand;
        private DateTime _startDate;
        private long _mileage;

        private static string[] m_availableBrands;
        private const short m_maxSpeed = 90;

        // Properties
        public long ID
        {
            get { return _id; }
        }
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
            set
            {
                if (value > 0)
                    _wayNumber = value;
                else
                    Console.Error.WriteLine("[Class.Bus.WayNumber] Incorrect way number");
            }
        }

        public string Brand
        {
            get { return _brand; }
            set
            {
                if (m_availableBrands.Contains(value))
                    _brand = value;
                else
                    Console.Error.WriteLine("[Class.Bus.Brand] Unavailable brand.");
            }
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

        // Constructors

        Bus(long seed = 27032002)
        {
            _id = seed.GetHashCode();
        }

        static Bus()
        {
            m_availableBrands = new string[] { "МАЗ-103", "МАЗ-104", "МАЗ-105", "МАЗ-107", "МАЗ-152", "МАЗ-203", "МАЗ-206", "МАЗ-251", "МАЗ-256" };
        }

        public Bus() : this(DateTime.Now.Millisecond)
        {
            Brand = m_availableBrands[Application.rand.Next(m_availableBrands.Length)];
            StartDate = new DateTime(year: Application.rand.Next(1997, DateTime.Now.Year - 1),
                                     month: Application.rand.Next(1, 12),
                                     day: Application.rand.Next(1, 31));
            Mileage = (DateTime.Now.Hour - StartDate.Hour) * Application.rand.Next(50, m_maxSpeed);
        }

        public Bus(string busNumber = "1337 IT-4") : this()
        {
            BusNumber = busNumber;
        }

        public Bus(Driver driver, short wayNumber) : this()
        {
            Driver = driver;
            WayNumber = wayNumber;
        }

        // Methods

        public int GetBusAge(out int currentYear)
        {
            currentYear = DateTime.Now.Year;
            return currentYear - StartDate.Year;
        }

        public override bool Equals(object obj)
        {
            return (BusNumber == ((Bus)obj).BusNumber && Brand == ((Bus)obj).Brand);
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

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
