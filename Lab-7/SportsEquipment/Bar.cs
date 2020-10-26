using Lab_7.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Lab_7.SportsEquipment
{
    public class Bar : Equipment
    {
        public enum Type
        {
            Parallel = 0,
            Uneven
        }

        public struct Dimensions
        {
            public float Length { get; set; }
            public float Width { get; set; }
            public float Height { get; set; }

        }

        private Type _barType;
        public Type BarType
        {
            get { return _barType; }
            set
            {
                if (value > Enum.GetValues(typeof(Bar.Type)).Cast<Bar.Type>().Max())
                {
                    throw new NotAvailableType("Got not available type", (int)value);
                }
                else
                {
                    _barType = value;
                }
            }
        }
        public Dimensions dimensions;


        public Bar()
        {
            Cost = Application.rand.Next(100);
            dimensions = new Dimensions();
            dimensions.Length = 350f + (float)(Application.rand.NextDouble() - Application.rand.NextDouble());
            dimensions.Width = 4f + (float)(Application.rand.NextDouble() - Application.rand.NextDouble()) * 0.1f;
            dimensions.Height = 200f + (float)(Application.rand.NextDouble() - Application.rand.NextDouble());
        }

        public Bar(bool flag) : this()
        {
            if (flag)
            {
                throw new CannotBeCreated("Bar cannot be a created!");
            }
        }

        public override string ToStaticString()
        {
            return "Name\tLength\tWidth\tHeight";
        }
        public override string ToString()
        {
            return $"Bar\t{dimensions.Length}cm\t{dimensions.Width}cm\t{dimensions.Height}cm";
        }
    }
}
