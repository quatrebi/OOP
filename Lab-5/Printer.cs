using Lab_5.SportsEquipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    public class Printer
    {
        public void IAmPrinting(Equipment obj)
        {
            if (obj is Bar) $"Getting object as {(obj as Bar).GetType().Name} [Printer]".ToLog();
            else if (obj is BasketballBall) $"Getting object as {(obj as BasketballBall).GetType().Name} [Printer]".ToLog();
            else if (obj is Bench) $"Getting object as {(obj as Bench).GetType().Name} [Printer]".ToLog();
            else if (obj is Mat) $"Getting object as {(obj as Mat).GetType().Name} [Printer]".ToLog();
            else obj.DoSomething();
        }
    }
}
