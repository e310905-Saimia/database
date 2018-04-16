using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;

namespace BankApp.Repositories
{
    interface ITransaction
    {
        List<Transaction> GetAccountsTransactions();
        List<Transaction> GetAccountTransactions(string iban);

    }
}
