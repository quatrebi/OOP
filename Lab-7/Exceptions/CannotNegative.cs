using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7.Exceptions
{
    public class CannotNegative : ArgumentException
    {
        private double value;
        public CannotNegative(string message, double value) : base(message)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return $"{Message} | Value ({value}) cannot be a negative [{GetType().Name}]";
        }
    }
}
