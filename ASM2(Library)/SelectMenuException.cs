using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2_Library_
{
    public class SelectMenuException : Exception
    {
        public SelectMenuException() : base() { }

        public override string Message
        {
            get { return "Enter number 1 to 6 please"; }
        }
    }
}
