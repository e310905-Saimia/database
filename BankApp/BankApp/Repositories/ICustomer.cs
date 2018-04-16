using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;

namespace BankApp.Repositories
{
    interface ICustomer
    {
        List<Customer> GetCustomerAccounts();
        

    }
}
