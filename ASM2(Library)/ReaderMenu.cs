using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ASM2_Library_
{
    public class ReaderMenu : IMenu
    {
        public static List<Reader> readers = new List<Reader>();
        public void showMenu()
        {
            Console.Clear();
            Console.WriteLine("------Reader Menu------");
            Console.WriteLine("-------------------------");
            Console.WriteLine("* 1. Add Reader        *");
            Console.WriteLine("* 2. Update Reader     *");
            Console.WriteLine("* 3. Delete Reader     *");
            Console.WriteLine("* 4. Show all            *");
            Console.WriteLine("* 5. Find Reader       *");
            Console.WriteLine("* 6. Exit                *");
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


            if (type == 1)
            {
                Reader.Instance.AddReader(readers);
                type = 1;
                Console.ReadKey();
            }
            else if (type == 2)
            {
                Reader.Instance.UpdateReader(readers);
                type = 1;
                Console.ReadKey();
            }
            else if (type == 3)
            {
                Reader.Instance.DeleteReader(readers);
                type = 1;
                Console.ReadKey();
            }
            else if (type == 4)
            {
                Reader.Instance.showAll(readers);
                type = 1;// lecturer menu
                Console.ReadKey();
            }
            else if (type == 5)
            {
                Reader.Instance.FindReader(readers);
                type = 1;// lecturer menu
                Console.ReadKey();
            }
            else if (type == 6)
            {
                type = 10;
            }

            return type;
        }
    }
}

