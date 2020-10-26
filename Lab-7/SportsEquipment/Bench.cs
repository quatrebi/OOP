using Lab_7.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7.SportsEquipment
{
    public class Bench : Equipment
    {
        public enum BenchType
        {
            Flat = 0,
            Adjustable,
            Olympic,
            Folding,
            Abdominal,
            Preacher = 20
        }

        public struct Dimensions
        {
            public float Width { get; set; }
            public float Height { get; set; }

        }

        private BenchType _benchType;
        public BenchType Type
        {
            get { return _benchType; }
            set
            {
                if (value > Enum.GetValues(typeof(BenchType)).Cast<BenchType>().Max())
                {
                    throw new NotAvailableType("Got not available type", (int)value);
                }
                else
                {
                    _benchType = value;
                }
            }
        }
        public Dimensions dimensions = new Dimensions();

        public Bench()
        {
            Cost = Application.rand.Next(100);
            BenchType[] types = Enum.GetValues(typeof(BenchType)).Cast<BenchType>().ToArray();
            Type = types[Application.rand.Next(types.Length)];
        }

        public override string ToStaticString()
        {
            return "Name\tType";
        }

        public override string ToString()
        {
            return $"Bench\t{Type}";
        }
    }
}
