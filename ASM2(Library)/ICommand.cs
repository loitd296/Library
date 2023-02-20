using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2_Library_
{
    public interface ICommand
    {
        void Execute(List<Lecturer> lecturers);
    }
}
