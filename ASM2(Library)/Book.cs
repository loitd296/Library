using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ASM2_Library_
{
    public class Book
    {
        private static Book instance = null;
        private static readonly object padLock = new object();
        private Book() { }
        public static Book Instance
        {
            get
            {
                lock (padLock)
                {
                    if (instance == null)
                    {
                        instance = new Book();
                    }
                    return instance;
                }
            }
        }
        public string id { get; set; }
        public string name { get; set; }

        public Author author1 { get; set; }

        public void AddBook(List<Book> books, List<Author> authors)
        {
            Book book = new Book();
            lbId:
            try
            {
                Console.Write("Enter ID: ");
                book.id = Console.ReadLine();
                if (!Regex.IsMatch(book.id, @"\d"))
                {
                    throw new IdException();
                }
            }
            catch (IdException ex)
            {
                Console.WriteLine(ex.Message);
                goto lbId;
            }
            lbName:
            try
            {
                Console.Write("Enter Name: ");
                book.name = Console.ReadLine();
                if(!Regex.IsMatch(book.name, @"\w{3,}"))
                {
                    throw new NameException();
                }
            }
            catch(NameException ex)
            {
                Console.WriteLine(ex.Message);
                goto lbName;
            }

            Console.WriteLine("Enter Author: ");
            string idAuthor = Console.ReadLine();
            Author objAuthor = authors.Find(x => x.id == idAuthor);
            book.author1 = objAuthor;

            books.Add(book);
            Console.WriteLine("Add successful");

            //Author.ReFreshAuthor(books, authors);
            //Console.Write("Count? (Y/N)");
            //Book book2 = book.getClone();
            //Console.Write("Enter ID: ");
            //book.id = Console.ReadLine();
            //Console.Write("Enter Name: ");
            //book.name = Console.ReadLine();
        }
        public void showAll(List<Book> books, List<Author> authors)
        {
            foreach (Book book in books)
            {
                Console.WriteLine(book.id + " " + book.name + " " + book.author1.name);
            }
        }

        

        public void UpdateBook(List<Book> books, List<Author> authors)
        {
            
            string idBook;
            lbId:
            try
            {
                Console.Write("Enter ID: ");
                idBook = Console.ReadLine();
                if (!Regex.IsMatch(idBook, @"\d"))
                {
                    throw new IdException();
                }
            }
            catch (IdException ex)
            {
                Console.WriteLine(ex.Message);
                goto lbId;

            }

            foreach (Book book in books)
            {
                if ( book.id == idBook)
                {
                    Console.WriteLine("ID: " + book.id);
                    Console.WriteLine("Name: " + book.name);
                
                    Console.WriteLine("Author: " + book.author1.name);
                    Console.Write("> Enter the name: ");
                    string strName;
                    lbName:
                    try 
                    {
                        strName = Console.ReadLine();
                        if (!Regex.IsMatch(strName, @"\w{3,}"))
                        {
                            throw new NameException();
                        }
                    }
                    catch(NameException ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto lbName;
                    }
                    if (strName.Length >= 2)
                    {
                        book.name = strName;
                    }
                    Console.WriteLine("Name: " + book.name);
                    Console.WriteLine("Update successful");

                    break;
                  
                }
            }
        }
        public void DeleteBook(List<Book> books)
        {
            string idBook;
            lbId:
            try
            {
                Console.Write("Enter ID: ");
                idBook = Console.ReadLine();
                if (!Regex.IsMatch(idBook, @"\d"))
                {
                    throw new IdException();
                }
            }
            catch (IdException ex)
            {
                Console.WriteLine(ex.Message);
                goto lbId;

            }
            

            foreach (Book book in books)
            {
                if (book.id == idBook)
                {
                    books.Remove(book);
                    Book.Instance.ReFreshBook(books,AuthorMenu.authors);
                    break;
                    
                }

            }
            Console.WriteLine("Delete Successful");


        }
        public void FindBook(List<Book> books, List<Author> authors)
        {
            //Console.Write("Enter ID: ");
            //int idLec = Convert.ToInt32(Console.ReadLine());

            //Lecturer lect = lecturers.Find(x => x.id == idLec);

            Console.Write("Enter Name to search: ");
            string nameBook = Console.ReadLine();
            List<Book> book = books.Where(x => x.name.Contains(nameBook)).ToList();
            Book.Instance.showAll(book, authors);
        }
        public void ReFreshBook(List<Book> books, List<Author> authors)
        {
            foreach (Author author in authors)
            {
                books.Where(x => x.author1.id == author.id).ToList();
            }

        }
        public void refreshBook()
        {
            BookMenu.books = BookMenu.books.Where(x => AuthorMenu.authors.Contains(x.author1)).ToList();
        }


    }
}
