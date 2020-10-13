using Lab_6;
using Lab_6.SportsEquipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    public class Gym
    {
        private List<Equipment> equipments;
        private double curMoney;
        public double TotalMoney { get; private set; }
        public bool HasMoney => curMoney < TotalMoney;

        public Equipment this[int i]
        {
            get { return equipments[i]; }
            set { equipments[i] = value; }
        }
        public int Length
        {
            get { return equipments.Count; }
        }

        public Gym(double money)
        {
            equipments = new List<Equipment>();
            TotalMoney = money;
        }

        public void AddItem(Equipment item)
        {
            curMoney += item.Cost;
            equipments.Add(item);
        }

        public void RemoveItem(Equipment item)
        {
            curMoney -= item.Cost;
            equipments.Remove(item);
        }

        public override string ToString()
        {
            string r = string.Empty;
            foreach (var item in equipments)
            {
                r += item.ToString() + '\n';
            }
            return r;
        }
    }

    public class GymController
    {
        public Gym gym;

        public GymController(Gym gym)
        {
            this.gym = gym;
        }

        public void Sort()
        {
            for (int i = 0; i < gym.Length; i++)
            {
                int cur = i;
                while (cur > 0 && gym[cur - 1].Cost > gym[cur].Cost)
                {
                    Equipment temp = gym[cur - 1];
                    gym[cur - 1] = gym[cur];
                    gym[cur] = temp;
                    cur--;
                }
            }
        }

        public List<Equipment> Find(double startMoneyRange, double endMoneyRange)
        {
            List<Equipment> r = new List<Equipment>();
            for (int i = 0; i < gym.Length; i++)
            {
                if (gym[i].Cost > startMoneyRange && gym[i].Cost < endMoneyRange)
                    r.Add(gym[i]);
            }
            return r;
        }
    }
}
