using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2_Library_
{
    public class NameException : Exception
    {
        public NameException() : base() { }

        public override string Message
        {
            get { return "The name must be more than 1 character"; }
        }
    }
}
