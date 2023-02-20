using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2_Library_
{
    public class GroupException : Exception
    {
        public GroupException() : base() { }
        public override string Message
        {
            get { return "The Group must be more than 5 character: "; }
        }
    }
}
