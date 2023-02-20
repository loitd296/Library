using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ASM2_Library_
{
    public class LecturerMenu : IMenu
    {
        public static List<Lecturer> lecturers = new List<Lecturer>();
        public void showMenu()
        {
            Console.Clear();
            Console.WriteLine("------Lecturer Menu------");
            Console.WriteLine("-------------------------");
            Console.WriteLine("* 1. Add Lecturer        *");
            Console.WriteLine("* 2. Update Lecturer     *");
            Console.WriteLine("* 3. Delete Lecturer     *");
            Console.WriteLine("* 4. Show all            *");
            Console.WriteLine("* 5. Find Lecturer       *");
            Console.WriteLine("* 6. Search Lecturer by ID*");
            Console.WriteLine("* 7. Search Lecturer by Name*");
            Console.WriteLine("* 8. Exit                *");
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
                Lecturer.Instance.AddLecturer(lecturers);
                type = 2;
                Console.ReadKey();
            }
            else if (type == 2)
            {
                Lecturer.Instance.UpdateLecturer(lecturers);
                type = 2;
                Console.ReadKey();
            }
            else if (type == 3)
            {
                Lecturer.Instance.DeleteLecturer(lecturers);
                type = 2;
                Console.ReadKey();
            }
            else if (type == 4)
            {
                Lecturer.Instance.showAll(lecturers);
                type = 2;// lecturer menu
                Console.ReadKey();
            }
            else if (type == 5)
            {
                Lecturer.Instance.FindLecturer(lecturers);
                type = 2;// lecturer menu
                Console.ReadKey();
            }
            else if (type == 6)
            {
                SearchLecturerControl slc = new SearchLecturerControl();
                SearchCommandLID sci = new SearchCommandLID();
                slc.setCommand(sci);
                slc.run(lecturers);
                type = 2;// lecturer menu
                Console.ReadKey();
            }
            else if (type == 7)
            {
                SearchLecturerControl slc = new SearchLecturerControl();
                SearchCommandName scn = new SearchCommandName();
                slc.setCommand(scn);
                slc.run(lecturers);
                type = 2;// lecturer menu
                Console.ReadKey();
            }
            else if (type == 8)
            {
                type = 10;
            }

            return type;
        }
    }
}

