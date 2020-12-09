using Lab_14.SportsEquipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab_14
{
    [CollectionDataContract, Serializable, XmlRoot]
    public class Gym
    {
        [DataMember, SoapElement, XmlArray]
        private List<Equipment> equipments;
        [DataMember]
        private double curMoney;
        [IgnoreDataMember, SoapIgnore, XmlIgnore]
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

        public Gym()
        {
            equipments = new List<Equipment>();
        }

        public Gym(double money) : this()
        {
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

    [Serializable, CollectionDataContract, XmlRoot]
    public class GymController
    {
        [DataMember, XmlElement]
        public Gym gym;

        public GymController()
        {
            gym = new Gym();
        }

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

        public override string ToString() => gym.ToString();
    }
}
