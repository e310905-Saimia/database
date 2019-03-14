using System;
using System.Collections.Generic;
using System.Text;
using PersonExample.Models;
using PersonExample.Repositories;

namespace PersonExample.Views
{
    class UIModel
    {
        private static readonly PersonRepository _personRepository = new PersonRepository();

        public void UpdatePerson()
        {
            Person updatePerson = _personRepository.ReadById(5002);
            updatePerson.FirstName = "James 123";
            updatePerson.DateOfBirth = new DateTime(1961, 1, 31);
            updatePerson.EyeColor = "Blue";
            _personRepository.Update(5002, updatePerson);
         }

        public void DeletePerson(int id)
        {
            ReadById(id);
            _personRepository.Delete(id);
            ReadById(id);
        }


        public void CreatePerson()
        {
            Person person = new Person();
            person.FirstName = "James";
            person.LastName = "Bond";
            person.City = "London";
            person.ShoeSize = 42;
            person.DateOfBirth = new DateTime(2019, 02, 15);

            _personRepository.Create(person);

        }

        public void ReadByCity()
        {

            var persons = _personRepository.ReadByCity("London");

            foreach (var p in persons)
            {
                Console.WriteLine($"{p.Id} {p.FirstName} {p.LastName} {p.City}");
            }
            Console.WriteLine("------------------------------");
        }

        public void ReadById(long id)
        {
            var person = _personRepository.ReadById(id);

            if (person == null)
                Console.WriteLine($"Asiakasta numerolla {id} ei löydy!");
            else
                Console.WriteLine($"{person.Id} {person.FirstName} {person.LastName} {person.City}");
        }
    }
}
