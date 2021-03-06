﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6.SportsEquipment
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

        public Type BarType { get; set; }
        public Dimensions dimensions;


        public Bar()
        {
            Cost = Application.rand.Next(100);
            dimensions = new Dimensions();
            dimensions.Length = 350f + (float)(Application.rand.NextDouble() - Application.rand.NextDouble());
            dimensions.Width = 4f + (float)(Application.rand.NextDouble() - Application.rand.NextDouble()) * 0.1f;
            dimensions.Height = 200f + (float)(Application.rand.NextDouble() - Application.rand.NextDouble());
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
