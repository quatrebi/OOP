using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5.SportsEquipment
{
    public class Mat : Equipment
    {
        public override double SomethingProperty
        {
            get
            {
                return somethingField * -Application.rand.NextDouble();
            }
            set => base.SomethingProperty = value;
        }
        public override string ToStaticString()
        {
            return "Name\tSomethingProperty";
        }

        public override string ToString()
        {
            return $"Mat\t{SomethingProperty}";
        }
    }
}
