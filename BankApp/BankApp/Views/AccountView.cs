using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;
using BankApp.Repositories;

namespace BankApp.Views
{
    class AccountView
    {
        private AccountRepository accountRepository = new AccountRepository();
        public void AddTransaction()
        {
            Transaction transaction = new Transaction
            {
                Amount = -200,
                Iban= "FI4422772000035988",
                TimeStamp = DateTime.Now
            };
            //Console.WriteLine($"Onnistuiko lisääminen: {accountRepository.AddTransaction(transaction)}");


        }
    }
}
