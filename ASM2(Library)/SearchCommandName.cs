using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2_Library_
{
    public class SearchCommandName : ICommand
    {
        public void Execute(List<Lecturer> lecturers)
        {
            
            
                var lect = Lecturer.Instance.searchLecByName(lecturers);
                

            
            Lecturer.Instance.showAll(lect);
        }
    }
}
