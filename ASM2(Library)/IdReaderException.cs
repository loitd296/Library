using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2_Library_
{
    public class IdReaderException : Exception
    {
        public IdReaderException() : base() { }

        public override string Message
        {
            get { return "The reader id must follow the format GCCxxxx"; }
        }
    }
}
