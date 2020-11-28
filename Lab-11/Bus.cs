using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_11
{
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

        public static int Count;

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
                if (Application.busNumberPattern.IsMatch(value))
                {
                    _busNumber = value;
                }
                else
                {
                    _busNumber = "1337 IT-4";
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Error.WriteLine($" Error: [Class.Bus.BusNumber] Number mismatch with format {value}.");
                    Console.ResetColor();
                }
            }
        }
        public short WayNumber
        {
            get { return _wayNumber; }
            set
            {
                if (value > 0 && value < 200)
                {
                    _wayNumber = value;
                }
                else
                {
                    _wayNumber = 1;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Error.WriteLine($" Error: [Class.Bus.WayNumber] Incorrect way number {value}.");
                    Console.ResetColor();
                }
            }
        }

        public string Brand
        {
            get { return _brand; }
            set
            {
                if (m_availableBrands.Contains(value))
                {
                    _brand = value;
                }
                else
                {
                    _brand = m_availableBrands[0];
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Error.WriteLine($" Error: [Class.Bus.Brand] Unavailable brand {value}.");
                    Console.ResetColor();
                }
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

        public static string About
        {
            get { return "Представляет информацию о Автобусе."; }
        }

        // Constructors

        Bus(long seed = 27032002)
        {
            _id = seed.GetHashCode();
            Count++;
        }

        ~Bus() => Count--;

        static Bus()
        {
            m_availableBrands = new string[] { "МАЗ-103", "МАЗ-104", "МАЗ-105", "МАЗ-107", "МАЗ-152", "МАЗ-203", "МАЗ-206", "МАЗ-251", "МАЗ-256" };
        }

        public Bus() : this(DateTime.Now.Millisecond)
        {
            Brand = m_availableBrands[Application.rand.Next(m_availableBrands.Length)];
            StartDate = new DateTime(year: Application.rand.Next(1997, DateTime.Now.Year - 1),
                                     month: Application.rand.Next(1, 12),
                                     day: Application.rand.Next(1, 28));
            Mileage = (DateTime.Now.Hour - StartDate.Hour) * Application.rand.Next(50, m_maxSpeed);
            Driver = new Driver(Application.months[Application.rand.Next(12)] + ' ' + Application.months[Application.rand.Next(12)]);
            WayNumber = (short)Application.rand.Next(1, 11);
            BusNumber = $"{Application.rand.Next(1111, 9999)} IT-{Application.rand.Next(0, 9)}";
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

        public int GetBusAge()
        {
            return DateTime.Now.Year - StartDate.Year;
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
            return $"{_brand} [{BusNumber}] {_startDate.ToShortDateString()} {_mileage}kms\t{Driver}\t{_wayNumber}";
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

        public Driver(string name)
        {
            string[] splited = name.Split(' ');
            Firstname = splited[0];
            Lastname = splited[1];
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
