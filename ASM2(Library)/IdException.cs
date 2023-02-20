using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2_Library_
{
    public class IdException : Exception
    {
        public IdException() : base() {}

        public override string Message
        {
            get { return "Enter id must be number"; }
        }

    }
}
