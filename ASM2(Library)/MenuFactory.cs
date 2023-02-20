using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2_Library_
{
    public class MenuFactory
    {
        public static IMenu GetMenu(int type)
        {
            IMenu menu = null;

            if (type == 1)
            {
                menu = new ReaderMenu();
            }
            else if (type == 2)
            {
                menu = new LecturerMenu();
            }
            else if (type == 3)
            {
                menu = new ReaderBookMenu();
            }
            else if (type == 4)
            {
                menu = new BookMenu(); 
            }
            else if(type == 5)
            {
                menu = new AuthorMenu();
            }
            else
            {
                menu = new Menu();
            }

            return menu;
        }
    }
}
