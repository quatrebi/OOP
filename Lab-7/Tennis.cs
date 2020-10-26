using Lab_7.SportsEquipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
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
