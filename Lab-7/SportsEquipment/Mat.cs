using Lab_7.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7.SportsEquipment
{
    public partial class Mat : Equipment
    {
        public enum Type
        {
            TypeA = 10,
            TypeB = 11,
            TypeC = 12
        }
        public struct Dimensions
        {
            public float Length { get; set; }
            public float Width { get; set; }
            public float Height { get; set; }

        }

        private Type _matType;
        public Type MatType
        {
            get { return _matType; }
            set
            {
                if (value > Enum.GetValues(typeof(Type)).Cast<Type>().Max())
                {
                    throw new NotAvailableType("Got not available type", (int)value);
                }
                else
                {
                    _matType = value;
                }
            }
        }
        public Dimensions dimensions = new Dimensions();

        public Mat()
        {
            Cost = Application.rand.Next(100);
            dimensions = new Dimensions()
            {
                Length = Application.rand.Next() * (float)Application.rand.NextDouble(),
                Width = Application.rand.Next() * (float)Application.rand.NextDouble(),
                Height = Application.rand.Next() * (float)Application.rand.NextDouble(),
            };
        }
    }
}
