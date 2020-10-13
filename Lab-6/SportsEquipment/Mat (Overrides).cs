using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6.SportsEquipment
{
    public partial class Mat : Equipment
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
