using Lab_6.SportsEquipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    sealed public class Tennis
    {
        Equipment[] equipments;

        public Tennis(Equipment[] equipments)
        {
            this.equipments = equipments;
        }
    }
}
