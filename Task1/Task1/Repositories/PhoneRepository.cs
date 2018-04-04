using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Task1.Model;

namespace Task1.Repositories
{
    class PhoneRepository
    {
        public void Create(Phone phone)
        {
            using (var context = new PersondbContext())
            {
                try
                {
                    context.Add(phone);
                    context.SaveChanges();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message + ex.LineNumber);
                }
            }
        }

        public List<Phone> Get()
        {
            using (var context = new PersondbContext())
            {
                List<Phone> phones = context.Phone.ToListAsync().Result;
                return phones;
            }
        }

        public Phone GetPhoneById(int id)
        {
            using (var context = new PersondbContext())
            {
                var phone = context.Phone.FirstOrDefault(p => p.Id == id);
                return phone;
            }
        }
    }
}
