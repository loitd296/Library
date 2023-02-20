using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ASM2_Library_
{
    public class ReaderBookMenu : IMenu
    {
        public static List<ReaderBook> readerbooks = new List<ReaderBook>();
        public void showMenu()
        {
            Console.Clear();
            Console.WriteLine("------ReaderBook Menu-------");
            Console.WriteLine("------------------------");
            Console.WriteLine("* 1. Add ReaderBook        *");
            Console.WriteLine("* 2. Update ReaderBook     *");
            Console.WriteLine("* 3. Delete ReaderBook     *");
            Console.WriteLine("* 4. Show all          *");
            Console.WriteLine("* 5. Find ReaderBook       *");
            Console.WriteLine("* 6. Exit              *");
            Console.WriteLine("------------------------");

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
                ReaderBook.Instance.AddReaderBook(readerbooks);
                type = 3;
                Console.ReadKey();
            }
            else if (type == 2)
            {
                ReaderBook.Instance.UpdateReaderBook(readerbooks);
                type = 3;
                Console.ReadKey();
            }
            else if (type == 3)
            {
                ReaderBook.Instance.DeleteReaderBook(readerbooks);
                type = 3;
                Console.ReadKey();
            }
            else if (type == 4)
            {
                ReaderBook.Instance.showAll(readerbooks);
                type = 3;// lecturer menu
                Console.ReadKey();
            }
            else if (type == 5)
            {
                ReaderBook.Instance.FindReaderBook(readerbooks);
                type = 3;// lecturer menu
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
