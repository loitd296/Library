using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ASM2_Library_
{
    public class AuthorMenu : IMenu
    {
        public static List<Author> authors = new List<Author>();
        public static List<Book> books = new List<Book>();


        public void showMenu()
        {
            Console.Clear();
            Console.WriteLine("------Author Menu-------");
            Console.WriteLine("------------------------");
            Console.WriteLine("* 1. Add Author        *");
            Console.WriteLine("* 2. Update Author     *");
            Console.WriteLine("* 3. Delete Author     *");
            Console.WriteLine("* 4. Show all          *");
            Console.WriteLine("* 5. Find Author       *");
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
                type =  Convert.ToInt32(Console.ReadLine());


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
                Author.Instance.AddAuthor(authors);
                type = 5;
                Console.ReadKey();
            }
            else if (type == 2)
            {
                Author.Instance.UpdateAuthor(authors);
                type = 5;
                Console.ReadKey();
            }
            else if (type == 3)
            {
                Author.Instance.DeleteAuthor(authors, books);

                type = 5;
                Console.ReadKey();
            }
            else if (type == 4)
            {
                Author.Instance.showAll(authors);
                type = 5;// lecturer menu
                Console.ReadKey();
            }
            else if (type == 5)
            {
                Author.Instance.FindAuthor(authors);
                type = 5;// lecturer menu
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
