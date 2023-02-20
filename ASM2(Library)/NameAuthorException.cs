using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2_Library_
{
    public class NameAuthorException : Exception
    {
        public NameAuthorException() : base() { }

        public override string Message
        {
            get { return "Enter name: xxxx"; }
        }
    }
}
