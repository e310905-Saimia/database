using System;
using System.Collections.Generic;
using System.Text;
using Task1.Model;

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
            foreach (var phnPhone in person.Phone)
            {
                Console.WriteLine($"\n   {phnPhone.ToString()}");
            }
            Console.WriteLine("\n-------------\n");
            
        }
    }
}
