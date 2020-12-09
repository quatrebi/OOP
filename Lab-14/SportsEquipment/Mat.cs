using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab_14.SportsEquipment
{
    [Serializable, DataContract]
    public partial class Mat : Equipment
    {
        public enum Type
        {
            TypeA = 10,
            TypeB = 11,
            TypeC = 12
        }
        [Serializable, DataContract]
        public struct Dimensions
        {
            [DataMember]
            public float Length { get; set; } 
            [DataMember]
            public float Width { get; set; }
            [DataMember]
            public float Height { get; set; }

        }

        [DataMember]
        public Type MatType { get; set; }
        [DataMember]
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
