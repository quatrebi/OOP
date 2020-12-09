﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lab_14.SportsEquipment
{
    [Serializable, DataContract, KnownType(typeof(Equipment))]
    public partial class Mat : Equipment
    {
        public enum Type
        {
            TypeA = 10,
            TypeB = 11,
            TypeC = 12
        }
        [Serializable]
        public struct Dimensions
        {
            public float Length { get; set; }
            public float Width { get; set; }
            public float Height { get; set; }

        }

        public Type MatType { get; set; }
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
