using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2_Library_
{
    public class AddressException : Exception
    {
        public AddressException() : base() { }

        public override string Message
        {
            get { return "The Address must be more than 5 characters:: "; }
        }

    }
}
