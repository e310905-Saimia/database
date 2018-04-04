using System;
using System.Collections.Generic;
using Task1.Model;
using Task1.Repositories;
using Task1.View;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Database CRUD operations");
            UIForConsoleApp();


            
            //PersonRepository personRepository = new PersonRepository();

            //Person person = new Person("Anja",43);
            //personRepository.Create(person);


            //// Luodaan person olio ja sille puhelinnumerot ja tallennetaan ne kantaan
            //// kts. https://docs.microsoft.com/en-us/ef/core/saving/related-data

            //Person person = new Person
            //{
            //    Name = "Liisa",
            //    Age = 30,
            //    Phone = new List<Phone>
            //    {
            //        new Phone {Number = "040123123", Type = "WORK"},
            //        new Phone {Number = "050321321", Type = "HOME"}
            //    }
            //};
            //personRepository.Create(person);




            //var newPerson = new Person();
            //newPerson.Name = "Aku Ankka";
            //newPerson.Age = 30;
            //PersonRepository.Update(27, newPerson);

            //var persons = personRepository.GetPersonPhone();
            //foreach (var p in persons)
            //{
            //    Console.WriteLine(p.ToString());
            //}
            //Console.WriteLine("Press <Enter> to Exit");
            //Console.ReadLine();

        }

        public static void UIForConsoleApp()
        {
            ConsoleKeyInfo info;
            PersonRepository personRepository = new PersonRepository();
            
                do
                {
                    Console.Clear();
                    Console.WriteLine("Database coding - CRUD");
                    Console.WriteLine("Press <ESC> to Exit");
                    Console.WriteLine("C) Create");
                    Console.WriteLine("R) Read All");
                    Console.WriteLine("U) Update");
                    Console.WriteLine("D) Delete");
                    Console.WriteLine("-------------");
                    Console.WriteLine("G) Get by ID");
                    Console.WriteLine("A) Update Phone");

                    info = Console.ReadKey();

                    switch (info.Key)
                    {
                        case ConsoleKey.C:
                            ViewPerson.AddPerson();
                            //var person = new Person("Masa", 25);
                            //personRepository.Create(person);
                            break;
                        case ConsoleKey.R:
                            ViewPerson.PrintToScreen(personRepository.Get());
                            Console.WriteLine("Press <Enter> to continue ...");
                            Console.ReadLine();
                            break;
                        case ConsoleKey.U:
                            Person updatePerson = personRepository.GetPersonById(10);
                            updatePerson.Name = "Jouni";
                            updatePerson.Age = 50;
                            personRepository.Update(1, updatePerson);
                            break;
                        case ConsoleKey.D:
                            personRepository.Delete(5);
                            break;
                        case ConsoleKey.G:
                            Console.Write("\nSyötä henkilön <id>, jonka tiedot näytetään: ");
                            int id = int.Parse(Console.ReadLine());
                            ViewPerson.PrintToScreen(personRepository.GetPersonByIdAndPhones(id));
                            Console.WriteLine("Press <Enter> to continue ...");
                            Console.ReadLine();
                            break;
                        case ConsoleKey.A:
                            Console.Write("\nSyötä henkilön <id>, jonka tiedot näytetään: ");
                            id = int.Parse(Console.ReadLine());
                            Person updatePersonAndPhone = personRepository.GetPersonByIdAndPhones(id);
                            ViewPerson.PrintToScreen(personRepository.GetPersonByIdAndPhones(id));
                            Console.Write("Valitse <Id>, jonka haluat muuttaa: ");
                            int phnId = int.Parse(Console.ReadLine());
                            Console.Write("Syötä uusi numero: ");
                            string newNumber = Console.ReadLine();
                            foreach (var phn in updatePersonAndPhone.Phone)
                            {
                                if (phn.Id == phnId)
                                    phn.Number = newNumber;
                            }
                            personRepository.Update(10, updatePersonAndPhone);
                            break;
                        case ConsoleKey.Escape:
                            Console.WriteLine("\nProgram end after 3 sec!");
                            for (int i = 0; i < 3; i++)
                            {
                                Console.Write(".");
                                System.Threading.Thread.Sleep(1000);
                            }
                            break;
                        default:
                            Console.WriteLine("\nWrong KEY - try again!");
                            System.Threading.Thread.Sleep(2000);
                            break;
                    }

                } while (info.Key != ConsoleKey.Escape);
            
            
        }

        }
    }
