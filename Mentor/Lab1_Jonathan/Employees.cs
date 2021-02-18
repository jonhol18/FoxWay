using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Jonathan
{
    /* Jonathan Holén
                19960718-6377*/
    public class EmployeeInfo
    {
        public string Name;
        public double eSalary;
        public int salaryId;

        public EmployeeInfo(string name, double salary, int idSalary)       //Sets and get the name, salary and id of the employee.
        {
            this.Name = name;
            this.eSalary = salary;
            this.salaryId = idSalary;
        }

        public string GetName()         //The method with "Get", get the name, salary, and id for the "program" class in the project.
        {
            return Name;
        }

        public double GetSalary()
        {
            return eSalary;
        }

        public int GetId()
        {
            return salaryId;
        }

        public virtual void SalaryCalc()
        {
            
        }


    }
}
