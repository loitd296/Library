using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ASM2_Library_
{
    public class Reader : Person
    {
        public string group { get; set; }

        private static Reader instance = null;
        private static readonly object padLock = new object();
        private Reader() { }
        public static Reader Instance
        {
            get
            {
                lock (padLock)
                {
                    if (instance == null)
                    {
                        instance = new Reader();
                    }
                    return instance;
                }
            }
        }

        public void AddReader(List<Reader> readers)
        {
            Reader reader = new Reader();
            lbId:
            try
            {
                Console.Write("Enter ID: ");
                reader.id = Console.ReadLine();
                if (!Regex.IsMatch(reader.id, @"GCC\d{4}"))
                {
                    throw new IdReaderException();
                }
            }catch(IdReaderException ex)
            {
                Console.WriteLine(ex.Message);
                goto lbId;
            }
            lbName:
            try
            {
                Console.Write("Enter Name: ");
                reader.name = Console.ReadLine();
                if (!Regex.IsMatch(reader.name, @"\w{3,}"))
                {
                    throw new NameException();
                }
            }
            catch (NameException ex)
            {
                Console.WriteLine(ex.Message);
                goto lbName;
            }
            lbDate:
            try
            {
                Console.Write("Enter Date of Birth: ");
                reader.dob = Console.ReadLine();
                if (!Regex.IsMatch(reader.dob, @"^[0-3][0-9]/[01][0-9]/(19|20)[0-9]{2}$"))
                {
                    throw new DateException();
                }
            }
            catch (DateException ex)
            {
                Console.WriteLine(ex);
                goto lbDate;
            }
            lbPhone:
            try
            {
                Console.Write("Enter Phone: ");
                reader.phone = Console.ReadLine();
                if (!Regex.IsMatch(reader.phone, @"\d{10,}"))
                {
                    throw new PhoneException();
                }
            }
            catch(PhoneException ex)
            {
                Console.WriteLine(ex.Message);
                goto lbPhone;
            }
            lbAddress:
            try
            {
                Console.Write("Enter Address: ");
                reader.address = Console.ReadLine();
                if (!Regex.IsMatch(reader.address, @"\w{5,}"))
                {
                    throw new AddressException();
                }
            }
            catch(AddressException ex)
            {
                Console.WriteLine(ex.Message);
                goto lbAddress;
            }
           lbGroup:
            try
            {
                Console.Write("Enter Group: ");
                reader.group = Console.ReadLine();
                if (!Regex.IsMatch(reader.group, @"\w{5,}"))
                {
                    throw new GroupException();
                }
            }
            catch(GroupException ex)
            {
                Console.WriteLine(ex.Message);
                goto lbGroup;
            }
            
            readers.Add(reader);
            Console.WriteLine("Add successful");


        }
        public void showAll(List<Reader> readers)
        {
            foreach (Reader reader in readers)
            {
                Console.WriteLine(reader.id + " - " + reader.name + " - " +
                    reader.dob + " - " + reader.phone + " - " + reader.address + " - " + reader.group);
            }
        }

        public void UpdateReader(List<Reader> readers)
        {
            string idRe;
            lbId:
            try
            {
                Console.Write("Enter ID: ");
                idRe = Console.ReadLine();
                if (!Regex.IsMatch(idRe, @"GCC\d{4}"))
                {
                    throw new IdReaderException();
                }
            }
            catch (IdReaderException ex)
            {
                Console.WriteLine(ex.Message);
                goto lbId;

            }

            foreach (Reader reader  in readers)
            {
                if (reader.id == idRe)
                {
                    Console.WriteLine("ID: " + reader.id);
                    Console.WriteLine("Name: " + reader.name);
                    Console.WriteLine("Date of Birth: " + reader.dob);
                    Console.WriteLine("Phone: " + reader.phone);
                    Console.WriteLine("Address: " + reader.address);
                    Console.WriteLine("Group: " + reader.group);
                    Console.Write("> Enter Name: ");
                    lbName:
                    string strName;
                    try
                    {
                        strName = Console.ReadLine();
                        if (!Regex.IsMatch(strName, @"\w{3,}"))
                        {
                            throw new NameException();
                        }
                    }
                    catch (NameException ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto lbName;
                    }

                    if (strName.Length >= 2)
                    {
                        reader.name = strName;
                    }
                    Console.WriteLine("Name: " + reader.name);
                    Console.Write("> Enter birthday: ");

                    lbDate:
                    string strDob;
                    try
                    {
                        strDob = Console.ReadLine();
                        if (!Regex.IsMatch(strDob, @"^[0-3][0-9]/[01][0-9]/(19|20)[0-9]{2}$"))
                        {
                            throw new DateException();
                        }
                    }
                    catch (DateException ex)
                    {
                        Console.WriteLine(ex);
                        goto lbDate;
                    }
                
                    if (strDob.Length >= 2)
                    {
                        reader.dob = strDob;
                    }
                    Console.WriteLine("Date of Birth: " +reader.dob);
                    Console.Write("> Enter Phone:");

                    lbPhone:
                    string strPhone;
                    try
                    {
                        strPhone = Console.ReadLine();
                        if (!Regex.IsMatch(strPhone, @"\d{10,}"))
                        {
                            throw new PhoneException();
                        }
                    }
                    catch (PhoneException ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto lbPhone;
                    }
                
                    if (strPhone.Length >= 10)
                    {
                        reader.phone = strPhone;
                    }
                    Console.WriteLine("Phone: " + reader.phone);
                    Console.Write("> Enter Address: ");
                    lbAddress:
                    string strAddress;
                    try
                    {
                        strAddress = Console.ReadLine();
                        if (!Regex.IsMatch(strAddress, @"\w{5,}"))
                        {
                            throw new AddressException();
                        }
                    }
                    catch (AddressException ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto lbAddress;
                    }
               
                    if (strAddress.Length >= 10)
                    {
                        reader.address = strAddress;

                    }
                    Console.WriteLine("Address: " + reader.address);
                    Console.Write("> Enter Group: ");
                    lbGroup:
                    string strGroup;
                    try
                    {
                        strGroup = Console.ReadLine();
                        if (!Regex.IsMatch(strGroup, @"\w{5,}"))
                        {
                            throw new GroupException();
                        }
                    }
                    catch (GroupException ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto lbGroup;
                    }
            
                    if (strGroup.Length >= 5)
                    {
                        reader.group = strGroup;
                    }
                    Console.WriteLine("Group: " + reader.group);
                    Console.WriteLine("Update successful");
                    Console.Write("> ");

                    break;
                }
            }
        }
        public void DeleteReader(List<Reader> readers)
        {
            string idRe;
            lbId:
            try
            {
                Console.Write("Enter ID: ");
                idRe = Console.ReadLine();
                if (!Regex.IsMatch(idRe, @"GCC\d{4}"))
                {
                    throw new IdReaderException();
                }
            }
            catch (IdReaderException ex)
            {
                Console.WriteLine(ex.Message);
                goto lbId;
            }

            foreach (Reader reader in readers)
            {
                if (reader.id == idRe)
                {
                    readers.Remove(reader);

                    break;
                }
            }
            Console.WriteLine("Delete Successful");

        }
        public void FindReader(List<Reader> readers)
        {
            //Console.Write("Enter ID: ");
            //int idLec = Convert.ToInt32(Console.ReadLine());

            //Lecturer lect = lecturers.Find(x => x.id == idLec);

            Console.Write("Enter Name to search: ");
            string nameLec = Console.ReadLine();

            List<Reader> read = readers.Where(x => x.name.Contains(nameLec)).ToList();

            Reader.Instance.showAll(read);

        }

    }
}
