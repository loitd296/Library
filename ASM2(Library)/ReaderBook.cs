using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ASM2_Library_
{
    public class ReaderBook
    {


        public string id;
        public string borrowDate;
        private static ReaderBook instance = null;
        private static readonly object padLock = new object();

        List<ReaderBook> readers = new List<ReaderBook>();
        
        private ReaderBook() { }

        public static ReaderBook Instance
        {
            get
            {
                lock (padLock)
                {
                    if (instance == null)
                    {
                        instance = new ReaderBook();
                    }
                    return instance;
                }
            }
        }


        public void AddReaderBook(List<ReaderBook> readers)
        {
            bool flag = true;
            do
            {
                ReaderBook reader = new ReaderBook();

                lbId:
                try
                {
                    Console.Write("Enter ID: ");
                    reader.id = Console.ReadLine();
                    if (!Regex.IsMatch(reader.id, @"\d"))
                    {
                        throw new IdException();
                    }
                }
                catch (IdException ex)
                {
                    Console.WriteLine(ex.Message);
                    goto lbId;
                }
            lbDate:
                try
                {
                    Console.Write("Enter Date of Birth: ");
                    reader.borrowDate = Console.ReadLine();
                    if (!Regex.IsMatch(reader.borrowDate, @"^[0-3][0-9]/[01][0-9]/(19|20)[0-9]{2}$"))
                    {
                        throw new DateException();
                    }
                }
                catch (DateException ex)
                {
                    Console.WriteLine(ex);
                    goto lbDate;
                }
                readers.Add(reader);
                Console.WriteLine("Add successful");


                Console.Write("Continue: (Y/N) ");
                flag = Console.ReadLine().ToLower().Equals("y") ? true : false;

            } while (flag);

        }
        public void showAll(List<ReaderBook> readerBooks)
        {
            foreach (ReaderBook readerBook in readerBooks)
            {
                Console.WriteLine(readerBook.id + " - " + readerBook.borrowDate);
            }
        }
        public void UpdateReaderBook(List<ReaderBook> readerBooks)
        {
            string idReaderBook;
            lbId:
            try
            {
                Console.Write("Enter ID: ");
                idReaderBook = Console.ReadLine();
                if (!Regex.IsMatch(idReaderBook, @"\d"))
                {
                    throw new IdException();
                }
            }
            catch (IdException ex)
            {
                Console.WriteLine(ex.Message);
                goto lbId;

            }

            foreach (ReaderBook readerBook in readerBooks)
            {
                if (readerBook.id == idReaderBook)
                {
                    Console.WriteLine("ID: " + readerBook.id);
                    Console.WriteLine("Borrow Date: " + readerBook.borrowDate);
                   
                    Console.Write("> Enter borrow date: ");
                    string strBorrowDate;
                    lbDate:
                    try
                    {
                        strBorrowDate = Console.ReadLine();
                        if (!Regex.IsMatch(strBorrowDate, @"^[0-3][0-9]/[01][0-9]/(19|20)[0-9]{2}$"))
                        {
                            throw new DateException();
                        }
                    }
                    catch (DateException ex)
                    {
                        Console.WriteLine(ex);
                        goto lbDate;
                    }
                    if (strBorrowDate.Length >= 2)
                    {
                        readerBook.borrowDate = strBorrowDate;
                    }
                    Console.WriteLine("Borrow date: " + readerBook.borrowDate);
                    Console.WriteLine("Update successful");

                    Console.Write(">  ");



                    break;
                }
            }
        }
        public void DeleteReaderBook(List<ReaderBook> readerBooks)
        {
            
            string idReaderBook;
            lbId:
            try
            {
                Console.Write("Enter ID: ");
                idReaderBook = Console.ReadLine();
                if (!Regex.IsMatch(idReaderBook, @"\d"))
                {
                    throw new IdException();
                }
            }
            catch (IdException ex)
            {
                Console.WriteLine(ex.Message);
                goto lbId;

            }

            foreach (ReaderBook readerBook in readerBooks)
            {
                if (readerBook.id == idReaderBook)
                {
                    readerBooks.Remove(readerBook);

                    break;
                }
            }
            Console.WriteLine("Delete Successful");


        }
        public void FindReaderBook(List<ReaderBook> readerBooks)
        {
            //Console.Write("Enter ID: ");
            //int idLec = Convert.ToInt32(Console.ReadLine());

            //Lecturer lect = lecturers.Find(x => x.id == idLec);

            Console.Write("Enter borrow date to search: ");
            string nameReaderBook = Console.ReadLine();

            List<ReaderBook> readerBooks1 = readerBooks.Where(x => x.borrowDate.Contains(nameReaderBook)).ToList();

            ReaderBook.Instance.showAll(readerBooks1);

        }
    }
}
