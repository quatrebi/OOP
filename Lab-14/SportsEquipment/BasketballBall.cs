using Lab_14.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lab_14.SportsEquipment
{
    [Serializable, DataContract, KnownType(typeof(Equipment))]
    public class BasketballBall : Equipment, IBall
    {
        public enum Type
        {
            Size7 = 0,
            Size6, Size5, Size3
        }
        [Serializable]
        public struct Dimensions
        {
            public float Radius { get; set; }
            public int Weight { get; set; }
        }
        public Type BallType { get; set; }
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
