using Lab_7.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7.SportsEquipment
{
    public abstract class Equipment
    {
        protected double somethingField;

        private double _cost;
        public double Cost
        {
            get { return _cost; }
            set
            {
                if (value < 0)
                {
                    throw new CannotNegative("Got a negative value!", value);
                }
                else
                {
                    _cost = value;
                }
            }
        }
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
