using System;
using Task1.Model;
using Task1.Repositories;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Database CRUD operations");
            //Person person = new Person("Anja",43);
            //PersonRepository.Create(person);

            var persons = PersonRepository.Get();
            foreach (var p in persons)
            {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine("Press <Enter> to Exit");
            Console.ReadLine();

        }
    }
}
