using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6.SportsEquipment
{
    public abstract class Equipment
    {
        protected double somethingField;
       
        public double Cost { get; set; }
        public virtual double SomethingProperty
        {
            get { return somethingField; }
            set { somethingField = value; }
        }

        public Equipment()
        {
            SomethingProperty = Application.rand.Next(int.MinValue, 0);
        }

        public virtual void DoSomething()
        {
            $"{GetType().Name} is making something...".ToLog();
        }
        public abstract string ToStaticString();
        
        public override string ToString()
        {
            return $"Sports Equipement";
        }
    }
}
