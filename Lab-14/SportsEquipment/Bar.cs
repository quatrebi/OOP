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
    public class Bar : Equipment
    {
        public enum Type
        {
            Parallel = 0,
            Uneven
        }

        [Serializable, DataContract]
        public struct Dimensions
        {
            [DataMember, XmlAttribute]
            public float Length { get; set; }
            [DataMember]
            public float Width { get; set; }
            [DataMember, XmlAttribute]
            public float Height { get; set; }

        }

        [DataMember, XmlAttribute]
        public Type BarType { get; set; }
        [DataMember]
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
