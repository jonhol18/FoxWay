using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Jonathan
{
    class Company
    {
        /* Jonathan Holén
                19960718-6377*/
        private readonly string sName;

        public Company(List<EmployeeInfo> EmployeesList, string name)           //Constructor.
        {

            EmployeesList = new List<EmployeeInfo>();
        }

        public void NewEmployees(List<EmployeeInfo> EmployeesList, EmployeeInfo emp)            //Void method adding new employes.
        {
            EmployeesList.Add(emp);
        }
    }
}
