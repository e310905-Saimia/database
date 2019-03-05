using System;
using System.Runtime.InteropServices;
using PersonExample.Repositories;

namespace PersonExample
{
    class Program
    {
        private static readonly PersonRepository _personRepository = new PersonRepository();
        static void Main(string[] args)
        {
            //Testing database Read
            //ReadByCity();
            ReadById();

            
        }

        static void ReadByCity()
        {
            var persons = _personRepository.ReadByCity("Juuka");

            foreach (var p in persons)
            {
                Console.WriteLine($"{p.Id} {p.FirstName} {p.LastName} {p.City}");
            }
        }

        static void ReadById()
        {
            var person = _personRepository.ReadById(1);

            Console.WriteLine($"{person.Id} {person.FirstName} {person.LastName} {person.City}");
        }
    }
}
