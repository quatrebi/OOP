using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab_14.SportsEquipment
{
    [DataContract, Serializable, XmlRoot]
    public abstract class Equipment
    {
        [DataMember, XmlElement]
        protected double somethingField;
       
        [DataMember, XmlElement]
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
