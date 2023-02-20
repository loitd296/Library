using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ASM2_Library_
{
    public class Menu : IMenu
    {
        public void showMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("-----Library Management--");
            Console.WriteLine("--------Main Menu--------");
            Console.WriteLine("-------------------------");
            Console.WriteLine("* 1. Manage Reader      *");
            Console.WriteLine("* 2. Manage Lecturer    *");
            Console.WriteLine("* 3. Manage ReaderBook  *");
            Console.WriteLine("* 4. Manage Book        *");
            Console.WriteLine("* 5. Manage Author      *");
            Console.WriteLine("* 6. Exit               *");
            Console.WriteLine("-------------------------");
            Console.WriteLine("Please choose option!");
        }

        public int SelectMenu()
        {
            int type = 0;
            lbType:
            try
            {
                Console.Write("Number: ");
                type = Convert.ToInt32(Console.ReadLine());
                if (!Regex.IsMatch(type.ToString(), @"^[0-9]*$"))
                {

                    throw new SelectMenuException();
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Please input number 1 to 6");
                goto lbType;
            }
            catch (SelectMenuException ex)
            {
                Console.WriteLine(ex);
                goto lbType;
            }

            return type;
        }
    }
}
