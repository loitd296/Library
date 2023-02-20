using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ASM2_Library_
{
    public class BookMenu : IMenu
    {
        public static List<Book> books = new List<Book>();
        public static List<Author> authors = new List<Author>();
        public void showMenu()
        {
            Console.Clear();
            Console.WriteLine("------Book Menu-------");
            Console.WriteLine("-------------------------");
            Console.WriteLine("* 1. Add Book        *");
            Console.WriteLine("* 2. Update Book     *");
            Console.WriteLine("* 3. Delete Book      *");
            Console.WriteLine("* 4. Show all           *");
            Console.WriteLine("* 5. Find Book       *");
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

            if (type == 1)
            {
                Book.Instance.AddBook(books, AuthorMenu.authors);
                type = 4;
                Console.ReadKey();
            }
            else if (type == 2)
            {
                Book.Instance.UpdateBook(books, AuthorMenu.authors);
                type = 4;
                Console.ReadKey();
            }
            else if (type == 3)
            {
                Book.Instance.DeleteBook(books);
                type = 4;
                Console.ReadKey();
            }
            else if (type == 4)
            {
                Book.Instance.showAll(books, AuthorMenu.authors);
                type = 4;// lecturer menu
                Console.ReadKey();
            }
            else if (type == 5)
            {
                Book.Instance.FindBook(books, authors);
                type = 4;// lecturer menu
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
