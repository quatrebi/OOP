using Lab_7.Exceptions;
using Lab_7.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7.SportsEquipment
{
    public class BasketballBall : Equipment, IBall
    {
        public enum Type
        {
            Size7 = 0,
            Size6, Size5, Size3
        }
        public struct Dimensions
        {
            public float Radius { get; set; }
            public int Weight { get; set; }
        }
        private Type _ballType;
        public Type BallType
        {
            get { return _ballType; }
            set
            {
                if (value > Enum.GetValues(typeof(Type)).Cast<Type>().Max())
                {
                    throw new NotAvailableType("Got not available type", (int)value);
                }
                else
                {
                    _ballType = value;
                }
            }
        }
        public Dimensions dimensions = new Dimensions();

        public int Weight => dimensions.Weight;

        public BasketballBall()
        {
            Cost = Application.rand.Next(100);
            BallType = (Type)Application.rand.Next(4);
            dimensions.Weight = (Application.rand.Next(2) * 620 != 0 ? 620 : 570);
        }

        public void DoKick()
        {
            $"BasketballBall ({dimensions.Weight}g) was kicked!".ToLog();
        }

        void IBall.DoSomething()
        {
            $"{GetHashCode()} - {GetType().Name} is making something... [Interface]".ToLog();
        }
        public override void DoSomething()
        {
            $"{GetHashCode()} - {GetType().Name} is making something... [Abstract class]".ToLog();
        }

        public override bool Equals(object obj)
        {
            return dimensions.Weight == (obj as BasketballBall).dimensions.Weight;
        }

        public override int GetHashCode()
        {
            return dimensions.Weight.GetHashCode();
        }

        public override string ToStaticString()
        {
            return "Name\tWeight\tCost";
        }

        public override string ToString()
        {
            return $"BasketBall\t{dimensions.Weight}g\t{Cost}";
        }
    }
}
