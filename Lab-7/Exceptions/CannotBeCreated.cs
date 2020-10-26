using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7.Exceptions
{
    public class CannotBeCreated : NullReferenceException
    {
        public CannotBeCreated(string msg) : base(msg) { }
    }
}
