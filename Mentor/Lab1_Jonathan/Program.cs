using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Jonathan
{           /* Jonathan Holén
                19960718-6377*/
    class Program
    {
        static void Main(string[] args)
        {
            DelegateOne myDelegate = new DelegateOne();
            DelegateOne.FirstDelegate D1 = myDelegate.startOne;     //This delegate "starts" the project. 
            D1();

            Console.ReadKey();
            Console.Clear();

            List<Programmers> MentorList = new List<Programmers>();

            Programmers p1 = new Programmers("Johan", 30000, 1, "Java");            //This is the programmers at the company, firstname, salary, and programming language.
            Programmers p2 = new Programmers("Lisa", 27000, 2, "C#");
            Programmers p3 = new Programmers("Ida", 32000, 3, "Java");
            Programmers p4 = new Programmers("Tobias", 29000,4,"C++");
            Programmers p5 = new Programmers("Johannes", 28000, 5, "C#");

            ProgramLeader pl1 = new ProgramLeader("Nils", 30000, 17, "Java", MentorList);           //Adds a new mentor.
            ProgramLeader pl2 = new ProgramLeader("Wick", 30000, 16, "Java", MentorList);
            
            MentorList.Add(pl1);
            MentorList.Add(pl2);

            pl1.MentorList.Add(p1); //Here i add which mentee has which mentor. So mentor Pl1 is mentor for P1, So Nils is Mentor for Johan.
            pl2.MentorList.Add(p3);

            List<Programmers> menteeList = new List<Programmers> {p1, p2, p3, p4, p5};      //Here we have all the mentees in the company. 


            List<EmployeeInfo> EmployeesList = new List<EmployeeInfo>();            //Here we also can see everyone at the company.
            Company c1 = new Company(EmployeesList, "Jones Computers");         //Adding everyone as an employe to the company.
            c1.NewEmployees(EmployeesList, p1);
            c1.NewEmployees(EmployeesList, p2);
            c1.NewEmployees(EmployeesList, p3);
            c1.NewEmployees(EmployeesList, p4);
            c1.NewEmployees(EmployeesList, p5);
            c1.NewEmployees(EmployeesList, pl1);
            c1.NewEmployees(EmployeesList, pl2);

            foreach (var t in menteeList)
            {
                t.SalaryCalc();
            }

            foreach (var mentor in MentorList)
            {
                mentor.SalaryCalc();
            }
            Console.WriteLine("Employees");
            foreach (var mentee in menteeList)
            {
                try
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("\nName: " + mentee.GetName() + "\nSalary: " + mentee.GetSalary() + "\nSalaryID: " + mentee.GetId() + "\nProgramming Language: " + mentee.GetLanguage());
                    if (mentee.GetType() != typeof(Programmers)) continue;
                    Programmers ThisProgrammer = (Programmers) mentee;
                    if (ThisProgrammer.Mentor != null)
                    {
                        Console.WriteLine("This progammers mentor is: " + ThisProgrammer.Mentor.Name);
                    }
                }

                catch (Exception e)         //Simple try and catch statement.
                {
                    Console.WriteLine(e.Message + " Something went wrong.");
                    throw;
                }

               
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nThe mentors and meentes is: ");        //Adding a green color to this, just so it's easier to see :)
            Console.ResetColor();
            foreach (var mentor in MentorList)
                
            {
                try
                {
                    Console.WriteLine("\nName: " + mentor.GetName() + "\nSalary: " + mentor.GetSalary() + "\nSalaryID: " + mentor.GetId() + "\nThe mentors language is: " + mentor.GetLanguage());
                    if (mentor.GetType() != typeof(ProgramLeader)) continue;
                    ProgramLeader ProgLead = (ProgramLeader) mentor;
                    Console.WriteLine("This mentors mentee is: " + ProgLead.GetMentees());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "Oops, something went wrong.");
                    throw;
                }
            }

            double totalSalaryCompany = EmployeesList.Sum(TotalSal => TotalSal.GetSalary()); //LINQ expression to calculate the monthly cost for the company.
            Console.WriteLine("\nMonthly cost of the company: " + totalSalaryCompany);
        }
    }
}
