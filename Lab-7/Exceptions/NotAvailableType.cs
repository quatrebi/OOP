using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7.Exceptions
{
    public class NotAvailableType : Exception
    {
        public int Type { get; set; }

        public NotAvailableType(string message, int value) : base(message) { Type = value; }

        public override string ToString()
        {
            return $"{Message} | {Type} [{GetType().Name}]";
        }
    }
}
