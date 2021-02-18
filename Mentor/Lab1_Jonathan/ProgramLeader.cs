using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Jonathan
{
    /* Jonathan Holén
                19960718-6377*/
    public class ProgramLeader:Programmers
    {
        private string Answer;
        private double total;
        private string ments;
        
        public List<Programmers> MentorList = new List<Programmers>();

        public ProgramLeader(string Name, double eSalary, int salaryId, string langauge, List<Programmers> MentorList) :
            base(Name, eSalary, salaryId, langauge) //the same principles aplies here as in the Programmers class, since it is a constructor it doesn't require a return statement. 
        {
            MentorList = new List<Programmers>();
        }

        public string GetMentors()          //Send the names of the mentors to "Program" class.
        {
            foreach (var mentor in MentorList)
            {
                Answer = mentor.GetName();
            }

            return Answer;
        }

        public string GetMentees()          //Sends/Gets the name for the "program class.
        {
            foreach (var mentee in MentorList)
            {
                ments = mentee.GetName();
            }

            return ments;
        }

        public override void SalaryCalc()       //This is used to calculate the bonus if an employee is an mentor.
        {
            base.SalaryCalc();
            total = MentorList.Count;

            double SalaryBonus = ((eSalary * 0.05) * (total)); // Here we add 5% to the salary if someone is mentor
            eSalary += SalaryBonus;
        }

    }
}
