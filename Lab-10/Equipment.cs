using System;

namespace Lab_10
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
            return somethingField.ToString();
        }
    }
}
