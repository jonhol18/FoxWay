using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Jonathan
{
    /* Jonathan Holén
                19960718-6377*/
    public class Programmers: EmployeeInfo
    {
        public string language;
        public ProgramLeader Mentor { get; set; }

        public Programmers(string Name, double eSalary, int salaryId, string language) : base(Name, eSalary,
            salaryId) //Since this is an constructor, it doesn't need a return statement, therefore it also has the same name as the class it is in.
        {
            this.language = language;
            Mentor = null;
        }

        public override void SalaryCalc()
        {
            if (language.ToLower() == "java")       //A simple "if" function to check if the person is coding in java, so they can get an 10% bonus.
            {
                eSalary *= 1.1;
            }
        }

        public string GetLanguage()
        {
            return language;
        }

        public virtual double mentorCalc()      //A method that gets overriden. 
        {
            return eSalary;
        }

    }
}
