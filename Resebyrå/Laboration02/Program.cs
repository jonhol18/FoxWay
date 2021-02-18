using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Laboration02
{   
    class Program
    {
        static void Main(string[] args)
        {
            start:
            Console.Clear();
            Console.WriteLine("Hi!\nWhat to you want to do?\n1. Add new Customer\n2. Update Customer\n3. Show all customer\n4. Make a new booking\n5. Show booking.\n6. Add new destination.");
           
            string val = (Console.ReadLine());
            if (int.TryParse(val,out var ValSiffra))
            {
                  
            }
            else
            {
                Console.WriteLine("Write the number of your selection.");
                goto start;
            } 


            switch (ValSiffra)
            {
                case 1:
                    NewCustomer();
                    break;
                case 2:
                    UpdateCustomer();
                    break;
                case 3:
                    ShowAllCustomer();
                    break;
                case 4:
                    NewBooking();
                    break;
                case 5:
                    ShowBooking();
                    break;
                case 6:
                    AddDestination();
                    break;
            }
            Console.WriteLine("\nTo stop the program. Write 'stop'. \nTo continue press enter.");
           string stop = Console.ReadLine();
           if (stop == "stop")
           {
               
           }
           else
           {
                goto start;
           }
           
        }

        private static void ShowBooking()
        {
            using (Travel_AgencyEntities db = new Travel_AgencyEntities())
            {
                Console.WriteLine("What is your booking id?");
            int bokningsId = int.Parse(Console.ReadLine());

            Bookings visaBookings;

            visaBookings = db.Bookings.Find(bokningsId);

            string Transport = visaBookings.Transportation;
            DateTime depDate = visaBookings.DepartDate;
            var BaraDate = depDate.ToShortDateString();
            DateTime retDate = (DateTime) visaBookings.ReturnDate;
            var baraRet = retDate.ToShortDateString();
            int destId = visaBookings.DestinationId;

                Destination infoDestination;

                infoDestination = db.Destination.Find(destId);
                string land = infoDestination.Country;
                string stad = infoDestination.Town;

                Console.WriteLine("Your trip with the booking id " + bokningsId + " departs on " + BaraDate + " and the return trip is " + baraRet);
                Console.WriteLine("You are traveling to " + land + " and will be in the city known as " + stad);
                
            }

        }

        private static void AddDestination()
        {
            using (Travel_AgencyEntities db = new Travel_AgencyEntities())
            {
                Console.WriteLine("What country?");
                string Land = Console.ReadLine();
                Console.WriteLine("which city?");
                string stad = Console.ReadLine();

                Destination newDestination = new Destination {Country = Land, Town = stad};


                db.Destination.Add(newDestination);
                db.SaveChanges();
            }
        }

        private static void NewBooking()
        {
            using (Travel_AgencyEntities db = new Travel_AgencyEntities())
            {
                Bookings newBookings = new Bookings();

                Console.WriteLine("How do you wanna travel?");
                string Transport = Console.ReadLine();
                Console.WriteLine("Which date?");
                DateTime DepDate = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Return trip?");
                DateTime RetDate = Convert.ToDateTime(Console.ReadLine());
                
                Console.WriteLine("What is your customer ID?");
                int kundId = int.Parse(Console.ReadLine());
                Console.WriteLine("What is the id for the destination?");
                int destId = int.Parse(Console.ReadLine());

                

                newBookings.Transportation = Transport;
                newBookings.DepartDate = DepDate;
                newBookings.ReturnDate = RetDate;
                newBookings.CustomerId = kundId;
                newBookings.DestinationId = destId;

                db.Bookings.Add(newBookings);
                db.SaveChanges();
            }
        }

        private static void UpdateCustomer()
        {
            using (Travel_AgencyEntities db = new Travel_AgencyEntities())
            {
                Console.WriteLine("Write in your first name or ID");
                string customer = Console.ReadLine();
                int customerId = 0;

                Customer changedCustomer;
                if (int.TryParse(customer, out customerId))
                {
                    changedCustomer = db.Customer.Find(customerId);
                }
                else
                {
                    changedCustomer = db.Customer.FirstOrDefault(c => c.FirstName == customer);     //Will grab the first one it finds.
                }
                Console.WriteLine("Firstname?");
                string firstName = Console.ReadLine();
                Console.WriteLine("Lastname?");
                string Lastname = Console.ReadLine();
                Console.WriteLine("age?");
                int iage = int.Parse(Console.ReadLine());

                changedCustomer.FirstName = firstName;
                changedCustomer.LastName = Lastname;
                changedCustomer.Age = iage;

                db.Entry(changedCustomer).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
        }

        private static void NewCustomer()
        {
            using (Travel_AgencyEntities db = new Travel_AgencyEntities())
            {
                Console.WriteLine("First name on customer?");
            string Forename = Console.ReadLine();
            Console.WriteLine("Lastname?");
            string Lastname = Console.ReadLine();
            Console.WriteLine("How old is the customer?");
            int iage = int.Parse(Console.ReadLine());

            Customer newCustomer = new Customer {FirstName = Forename, LastName = Lastname, Age = iage};


            db.Customer.Add(newCustomer);
            db.SaveChanges();

            }
        }

        private static void ShowAllCustomer()
        {
            using (Travel_AgencyEntities db = new Travel_AgencyEntities())
            {
                var ListOfCustomer = db.Customer.ToList();
                foreach (var customer in ListOfCustomer)
                {
                    Console.WriteLine("Customer id is: " + customer.Id + " Name is " + customer.FirstName + " " + customer.LastName + " and the customer is " + customer.Age + " years old.");
                }
            }
        }
    }
}
