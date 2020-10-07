using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6.SportsEquipment
{
    public class Bar : Equipment
    {
        private float[] dimensions;
        public float Length
        {
            get { return dimensions[0]; }
            set { dimensions[0] = value; }
        }
        public float Width
        {
            get { return dimensions[1]; }
            set { dimensions[1] = value; }
        }

        public float Height
        {
            get { return dimensions[2]; }
            set { dimensions[2] = value; }
        }

        public Bar()
        {
            dimensions = new float[3];
            Length = 350f + (float)(Application.rand.NextDouble() - Application.rand.NextDouble());
            Width = 4f + (float)(Application.rand.NextDouble() - Application.rand.NextDouble()) * 0.1f;
            Height = 200f + (float)(Application.rand.NextDouble() - Application.rand.NextDouble());
        }

        public override string ToStaticString()
        {
            return "Name\tLength\tWidth\tHeight";
        }
        public override string ToString()
        {
            return $"Bar\t{Length}cm\t{Width}cm\t{Height}cm";
        }
    }
}
