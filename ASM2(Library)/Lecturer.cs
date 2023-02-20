using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ASM2_Library_
{
    public sealed class Lecturer : Person
    {
        public string dept { get; set; }
        private static Lecturer instance = null;
        private static readonly object padLock = new object();
        private Lecturer() { }
        public static Lecturer Instance
        {
            get 
            {
                lock (padLock)
                {
                    if (instance == null)
                    { 
                        instance = new Lecturer();
                    }
                    return instance;
                }
            }
        }

        public void AddLecturer(List<Lecturer> lecturers)
        {
            Lecturer lecturer = new Lecturer();
            lbId:
            try
            {
                Console.Write("Enter ID: ");
                lecturer.id = Console.ReadLine();
                if (!Regex.IsMatch(lecturer.id, @"\d"))

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
                lecturer.name = Console.ReadLine();
                if (!Regex.IsMatch(lecturer.name, @"\w{3,}"))
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
                lecturer.dob = Console.ReadLine();
                if (!Regex.IsMatch(lecturer.dob, @"^[0-3][0-9]/[01][0-9]/(19|20)[0-9]{2}$"))
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
                lecturer.phone = Console.ReadLine();
                if (!Regex.IsMatch(lecturer.phone, @"\d{10,}"))
                {
                    throw new PhoneException();
                }
            }
            catch (PhoneException ex)
            {
                Console.WriteLine(ex.Message);
                goto lbPhone;
            }
            lbAddress:
            try
            {
                Console.Write("Enter Address: ");
                lecturer.address = Console.ReadLine();
                if (!Regex.IsMatch(lecturer.address, @"\w{5,}"))
                {
                    throw new AddressException();
                }
            }
            catch (AddressException ex)
            {
                Console.WriteLine(ex.Message);
                goto lbAddress;
            }
            lbDebt:
            try
            {
                Console.Write("Enter Dept: ");
                lecturer.dept = Console.ReadLine();
                if (!Regex.IsMatch(lecturer.dept, @"\w{3,}"))
                {
                    throw new GroupException();
                }
            }
            catch (GroupException ex)
            {
                Console.WriteLine("The debt must be more than 5 character:");
                goto lbDebt;
            }

           
            lecturers.Add(lecturer);
            Console.WriteLine("Add successful");

        }
        public void showAll(List<Lecturer> lecturers)
        {
            foreach (Lecturer lecturer in lecturers)
            {
                Console.WriteLine(lecturer.id + " - " + lecturer.name + " - " + 
                    lecturer.dob +  " - " + lecturer.phone + " - " + lecturer.address + " - " + lecturer.dept);
            }
        }

        public void UpdateLecturer(List<Lecturer> lecturers)
        {
            string idLec;

            lbId:
            try
            {
                Console.Write("Enter ID: ");
                idLec = Console.ReadLine();
                if (!Regex.IsMatch(idLec, @"\d"))
                {
                    throw new IdException();
                }
            }
            catch (IdException ex)
            {
                Console.WriteLine(ex.Message);
                goto lbId;

            }

            foreach (Lecturer lecturer in lecturers)
            {
                if (lecturer.id == idLec)
                {
                    Console.WriteLine("ID: " + lecturer.id);
                    Console.WriteLine("Name: " + lecturer.name);
                    Console.WriteLine("Date of Birth: " + lecturer.dob);
                    Console.WriteLine("Phone: " + lecturer.phone);
                    Console.WriteLine("Address: " + lecturer.address);
                    Console.WriteLine("Dept: " + lecturer.dept);
                    Console.Write(">Enter Name: ");
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
                        lecturer.name = strName;
                    }
                    Console.WriteLine("Name: " + lecturer.name);
                    Console.Write("> Enter Date: ");


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
                        lecturer.dob = strDob;
                    }
                    Console.WriteLine("Date of Birth: " + lecturer.dob);
                    Console.Write(">Enter Phone: ");
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
                    if (strPhone.Length >= 10 )
                    {
                        lecturer.phone = strPhone;
                    }
                    Console.WriteLine("Phone: " + lecturer.phone);
                    Console.Write("> Enter Address");
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
                        lecturer.address = strAddress;
                    }
                    Console.WriteLine("Address: " + lecturer.address);
                    Console.Write(">Enter Debt: ");
                    lbDebt:
                    string strDebt;
                    try
                    {
                        strDebt = Console.ReadLine();
                        if (!Regex.IsMatch(strDebt, @"\w{5,}"))
                        {
                            throw new DebtException();
                        }
                    }
                    catch (DebtException ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto lbDebt;
                    }
                    if (strDebt.Length >= 3)
                    {
                        lecturer.dept = strDebt;
                    }
                    Console.WriteLine("Dept: " + lecturer.dept);
                    Console.Write("> ");
                    Console.WriteLine("Update successful");

                    break;
                }
            }
        }

        

        public void DeleteLecturer(List<Lecturer> lecturers)
        {
            string idLec ;
            lbId:
            try
            {
                Console.Write("Enter ID: ");
                idLec = Console.ReadLine();
                if (!Regex.IsMatch(idLec, @"\d"))
                {
                    throw new IdException();
                }
            }
            catch (IdException ex)
            {
                Console.WriteLine(ex.Message);
                goto lbId;

            }

            foreach (Lecturer lecturer in lecturers)
            {
                if (lecturer.id == idLec)
                {
                    lecturers.Remove(lecturer);
                    break;
                }
            }
            Console.WriteLine("Delete successful");

        }
        public void FindLecturer(List<Lecturer> lecturers)
        {
            //Console.Write("Enter ID: ");
            //int idLec = Convert.ToInt32(Console.ReadLine());  

            //Lecturer lect = lecturers.Find(x => x.id == idLec);

            Console.Write("Enter Name to search: ");
            string nameLec = Console.ReadLine();

            List<Lecturer> lect = lecturers.Where(x => x.name.Contains(nameLec)).ToList();

            Lecturer.Instance.showAll(lect);

        }
        public List<Lecturer> searchLecByName(List<Lecturer> lecturers)
        {
            lbName:
            string nameLec;
            try
            {
                Console.Write("Enter Name to search: ");
                nameLec = Console.ReadLine();
                if (!Regex.IsMatch(nameLec, @"^[a-zA-Z]+$"))
                {
                    throw new IdException();
                }
            }
            catch (IdException ex)
            {
                Console.WriteLine("Name must be character");
                goto lbName;

            }

            List<Lecturer> lect = lecturers.Where(x => x.name.Contains(nameLec)).ToList();
            return lect;
        }
        public Lecturer searchLecByID(List<Lecturer> lecturers)
        {
            string idLec;
            lbId:
            try
            {
                Console.Write("Enter ID: ");
                idLec = Console.ReadLine();
                if (!Regex.IsMatch(idLec, @"\d"))
                {
                    throw new IdException();
                }
            }
            catch (IdException ex)
            {
                Console.WriteLine(ex.Message);
                goto lbId;

            }

            Lecturer lect = lecturers.Find(x => x.id == idLec);
            return lect;
        }
        public static void Show(Lecturer lect)
        {
            Console.WriteLine(lect.id + " - " + lect.name + " - " + lect.dob + " - " + lect.address 
                + " - " + lect.phone + " - " + lect.dept);
           
        }

    }
}
