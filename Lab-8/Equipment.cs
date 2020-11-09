using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public struct Equipment
    {
        public int somethingField;

        public string SomethingProperty { get; set; }

        public void SomethingMethod()
        {
            Console.WriteLine("Something method from Equipment class!");
        }

        public override string ToString()
        {
            return SomethingProperty;
        }
    }
}
