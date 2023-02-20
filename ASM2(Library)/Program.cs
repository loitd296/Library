using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2_Library_
{
    public class Program
    {
        static void Main(string[] args)
        {
            int type = 0;

            while (type != 6)
            {
                IMenu menu = MenuFactory.GetMenu(type);

                menu.showMenu();
                type = menu.SelectMenu();
            }
        }
    }
}
