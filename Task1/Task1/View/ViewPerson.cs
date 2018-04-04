using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using Task1.Model;
using Task1.Repositories;

namespace Task1.View
{
    class ViewPerson
    {       
        /// <summary>
        /// Print data to screen from list
        /// </summary>
        /// <param name="persons"></param>
        public static void PrintToScreen(List<Person> persons)
        {
            Console.WriteLine("Id, Name, Age\n" +
                              "-------------------\n");
            foreach (var p in persons)
            {
                Console.WriteLine(p.ShowData());
            }
        }

        /// <summary>
        /// Print only one record 
        /// </summary>
        /// <param name="person"></param>
        public static void PrintToScreen(Person person)
        {
            Console.WriteLine($"{person.Name}, {person.Age}");
            if (person.Phone.Count == 0)
                Console.WriteLine("Ei puhelinta!");
            else
                Console.WriteLine("Id\tTyyppi\t\tNumero");
            foreach (var phnPhone in person.Phone)
            {
                Console.WriteLine($"{phnPhone.ToString()}");
            }
            Console.WriteLine("\n-------------\n");
            
        }

        public static void AddPerson()
        {
            Console.Write("Type name: ");
            string name = Console.ReadLine();
            Console.Write("Type age: ");
            short age = short.Parse(Console.ReadLine());

            List<Phone> phones = new List<Phone>();
            string addAnother = "Y";
            Console.WriteLine("Add phones");
            do
            {
                Console.Write("Type phonenumber: ");
                string phoneNumber = Console.ReadLine();
                Console.Write("Phone type <Home/Work>: ");
                string phoneType = Console.ReadLine();
                
                var addPhone = new Phone(phoneType,phoneNumber);
                phones.Add(addPhone);

                Console.Write("Add another phone <Y/N>: ");
                addAnother = Console.ReadLine();

            } while(addAnother.ToUpper() != "N");

            var addPerson = new Person(name, age, phones);
            PersonRepository personRepository = new PersonRepository();
            personRepository.Create(addPerson);
        }
    }
}
