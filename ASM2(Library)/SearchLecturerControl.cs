using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2_Library_
{
    public class SearchLecturerControl
    {
        public ICommand command;

        public void setCommand(ICommand command)
        {
            this.command = command;

        }
        public void run(List<Lecturer> lecturers)
        {
            command.Execute(lecturers);
        }
    }
}
