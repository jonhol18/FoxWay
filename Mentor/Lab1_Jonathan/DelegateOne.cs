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
    class DelegateOne
    {
        public delegate void FirstDelegate();

        public void startOne()
        {
            Console.WriteLine("Welcome! Press enter to see info");      //This is what the user sees when he starts the program.
            Console.ReadKey();
        }

    }
}
