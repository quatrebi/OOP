using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6.SportsEquipment
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

        public BenchType Type { get; set; }
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
