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
            ReadByCity();
            for (int i = 0; i < 100; i++)
            {
                ReadById(i*2);
            }
            

            
        }

        static void ReadByCity()
        {
            var persons = _personRepository.ReadByCity("Juuka");

            foreach (var p in persons)
            {
                
                Console.WriteLine($"{p.Id} {p.FirstName} {p.LastName} {p.City}");
            }
            Console.WriteLine("------------------------------");
        }

        static void ReadById(long id)
        {
            var person = _personRepository.ReadById(id);

            if (person==null)
                Console.WriteLine($"Asiakasta numerolla {id} ei löydy!");
            else
                Console.WriteLine($"{person.Id} {person.FirstName} {person.LastName} {person.City}");
        }
    }
}
