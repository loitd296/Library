using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2_Library_
{
    public class DebtException : Exception
    {
        public DebtException() : base() { }

        public override string Message
        {
            get { return "The debt must be more 3 characters"; }
        }
    }
}
