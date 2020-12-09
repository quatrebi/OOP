using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab_14.SportsEquipment
{
    [Serializable, DataContract]
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

        [Serializable, DataContract]
        public struct Dimensions
        {
            [DataMember]
            public float Width { get; set; }
            [DataMember]
            public float Height { get; set; }

        }
        [DataMember]
        public BenchType Type { get; set; }
        [DataMember]
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
