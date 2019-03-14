using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using PersonExample.Models;


namespace PersonExample.Repositories
{
    class PersonRepository : IPersonRepository
    {
        private readonly PersontestdbContext _persontestdbContext = new PersontestdbContext();

        public void CreateWithSQL(Person person)
        {
            string sql = $"INSERT INTO PERSON (FirstName, LastName, City, ShoeSize) " +
                         $"VALUES ({person.FirstName},{person.LastName}, {person.City}, {person.ShoeSize})";

            //var conn = new SqlServerConnection();
            //conn.ConnectionString = "Data Source = DKO - S010A - 016\\SQLEXPRESS; Initial Catalog = PersonTestDB; Integrated Security = True");

        }
        public void Create(Person person)
        {

            string sql = $"INSERT INTO PERSON (FirstName, LastName, City, ShoeSize) " +
                         $"VALUES ({person.FirstName},{person.LastName}, {person.City}, {person.ShoeSize})";


            _persontestdbContext.Add(person);
            _persontestdbContext.SaveChanges();

        }

        public List<Person> ReadByCity(string city)
        {
            //var persons = _persontestdbContext.Person.
            //    FromSql($"SELECT * FROM PERSON WHERE CITY = {city}").
            //    ToList();

            var persons = _persontestdbContext.
                Person.
                Where(p => p.City == city).
                ToListAsync().
                Result;
            return persons;
        }

        public Person ReadById(long id)
        {

            // Vaihtoehto A
            //var person = _persontestdbContext.
            //    Person.
            //    FromSql($"SELECT * FROM PERSON WHERE ID = {id}").
            //    FirstOrDefault();

            // Vaihtoehto B
            var person = _persontestdbContext.
                Person.
                FirstOrDefault(p => p.Id == id);

            // Vaihtoehto C
            //var person = _persontestdbContext.Person.Find(id);


            return person;
        }

        public void Update(long id, Person person)
        {
            var isPersonAlive = ReadById(id);
            if (isPersonAlive != null)
            {
                _persontestdbContext.Update(person);
                _persontestdbContext.SaveChanges();
                Console.WriteLine("Tiedot tallennettu onnistuneesti!");
            }
            else
            {
                Console.WriteLine("Tietojen tallennus epäonnistui - henkilöä ei ole olemassa!");
            }
        }

        public void Delete(long id)
        {
            //DELETE * FROM PERSON WHERE ID={id}
            var deletedPerson = ReadById(id);
            if (deletedPerson != null)
            {
                _persontestdbContext.Person.Remove(deletedPerson);
                _persontestdbContext.SaveChanges();
                Console.WriteLine("Tiedot poistettu onnistuneesti!");
            }
            else
            {
                Console.WriteLine("Tiedon poisto EI onnistunut - ID tuntematon");
            }
        }
    }
}
