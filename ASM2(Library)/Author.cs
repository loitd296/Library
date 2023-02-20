using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ASM2_Library_
{
    public class Author
    {
        private static Author instance = null;
        private static readonly object padLock = new object();
        //public static readonly Author author = new Author();
        private Author() { }
        public static Author Instance
        {
            get
            {
                lock (padLock)
                {
                    if (instance == null)
                    {
                        instance = new Author();
                    }
                    return instance;
                }
            }
        }
        public string id { get; set; }
        public string name { get; set; }

        List<Book> books = new List<Book>();

        public void AddAuthor(List<Author> authors)
        {
            bool flag = true;
            do
            {
                Author author = new Author();
                lbId:
                try { 
                Console.Write("Enter ID: ");
                author.id = Console.ReadLine();
                    if(!Regex.IsMatch(author.id, @"\d")){
                        throw new IdException();
                    }
                }
                catch(IdException ex) 
                {
                    Console.WriteLine(ex.Message);
                    goto lbId;
                }
            lbName:
                try
                {
                    Console.Write("Enter Name: ");
                    author.name = Console.ReadLine();
                    if (!Regex.IsMatch(author.name, @"\w{3,}"))
                    {
                        throw new NameAuthorException();
                    }
                }
                catch (NameAuthorException ex)
                {
                    Console.WriteLine(ex);
                    goto lbName;
                }
                authors.Add(author);
                Console.WriteLine("Add successful");
                Console.Write("Continue: (Y/N) ");
                flag = Console.ReadLine().ToLower().Equals("y") ? true : false;

            } while (flag);

        }
        public void showAll(List<Author> authors)
        {
            foreach (Author author in authors)
            {
                Console.WriteLine(author.id + " " + author.name);
            }
        }
        public void UpdateAuthor(List<Author> authors)
        {
            string idCou;
            lbId:
            try
            {
                Console.Write("Enter ID: ");
                idCou = Console.ReadLine();
                if (!Regex.IsMatch(idCou, @"\d"))
                {
                    throw new IdException();
                }
            }
            catch (IdException ex)
            {
                Console.WriteLine(ex.Message);
                goto lbId;

            }


            foreach (Author author in authors)
            {
                if (author.id == idCou)
                {
                    Console.WriteLine("ID: " + author.id);
                    Console.WriteLine("Name: " + author.name);
                    Console.Write("> Enter Name:");
                    string strName;
                    lbName:
                    try
                    {
                        strName = Console.ReadLine();
                        if (!Regex.IsMatch(strName, @"\w{3,}"))
                        {
                            throw new NameException();
                        }


                    }catch (NameException ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto lbName;
                    }
                    if (strName.Length >= 2)
                    {
                        author.name = strName;
                    }
                    Console.WriteLine("Name: " + author.name);
                    Console.WriteLine("Update successful");

                    break;
                }
            }
        }
        public void DeleteAuthor(List<Author> authors, List<Book> books)
        {
            Console.Write("Enter ID: ");
            string idAuthor;
            lbId:
            try
            {
                Console.Write("Enter ID: ");
                idAuthor = Console.ReadLine();
                if (!Regex.IsMatch(idAuthor, @"\d"))
                {
                    throw new IdException();
                }
            }
            catch (IdException ex)
            {
                Console.WriteLine(ex.Message);
                goto lbId;

            }

            foreach (Author author in authors)
            {
                if (author.id == idAuthor)
                {
                    authors.Remove(author);
                    Book.Instance.refreshBook();
                    break;
                }
            }
            Console.WriteLine("Delete Successful");

            //foreach (Book book in books)
            //{
            //    if (book.author.id == idAuthor)
            //    {
            //        books.Remove(book);

            //        break;
            //        Console.WriteLine("Delete Successful");

            //    }
            //}
        }
        public void FindAuthor(List<Author> authors)
        {
            //Console.Write("Enter ID: ");
            //int idLec = Convert.ToInt32(Console.ReadLine());

            //Lecturer lect = lecturers.Find(x => x.id == idLec);

            Console.Write("Enter Name to search: ");
            string nameLec = Console.ReadLine();

            List<Author> lect = authors.Where(x => x.name.Contains(nameLec)).ToList();

            Author.Instance.showAll(lect);
        }

        public void ReFreshAuthor(List<Book> books, List<Author> authors)
        {
            foreach (Author author in authors)
            {
                books.Where(x => x.author1.id == author.id).ToList();
            }

        }
        public void AuthorBook(List<Author> authors)
        {
            Console.Write("Enter id: ");
            string idAu = Console.ReadLine();
            Author author = authors.Find(x => x.id == idAu);

            foreach (Book book in author.books)
            {
                Console.WriteLine(book.id + "-" + book.name);
            }

        }
       
    }
}

