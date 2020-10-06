using Lab_5.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5.SportsEquipment
{
    public class BasketballBall : Equipment, IBall
    {
        public int Weight { get; private set; }

        public BasketballBall()
        {
            Weight = (Application.rand.Next(2) * 620 != 0 ? 620 : 570);
        }

        public void DoKick()
        {
            $"BasketballBall ({Weight}g) was kicked!".ToLog();
        }

        public override void DoSomething()
        {
            $"{GetHashCode()} - {GetType().Name} is making something...".ToLog();
        }

        public override bool Equals(object obj)
        {
            return Weight == (obj as BasketballBall).Weight;
        }

        public override int GetHashCode()
        {
            return Weight.GetHashCode();
        }

        public override string ToStaticString()
        {
            return "Name\tWeight";
        }

        public override string ToString()
        {
            return $"BasketBall\t{Weight}g";
        }
    }
}
