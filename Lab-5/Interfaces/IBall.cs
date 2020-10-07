using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5.Interfaces
{
    public interface IBall
    {
        int Weight { get; }

        void DoKick();

        void DoSomething();
    }
}
