using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;
using BankApp.Repositories;

namespace BankApp.Services
{
    /// <summary>
    /// Täällä on palvelut, joita käyttöliittymästä kutsutaan
    /// </summary>
    class BankService:IBankService
    {
        BankRepository bankRepository = new BankRepository();
        public void CreateBank(Bank bank)
        {            
            bankRepository.Create(bank);
        }

        public List<Bank> GetBankCustomers()
        {
            var bankCustomers = bankRepository.GetBankCustomers();
            return bankCustomers;
        }

        public List<Bank> GetTransactionsFromBankCustomersAccounts()
        {
            var bankCustomers = bankRepository.GetTransactionsFromBankCustomersAccounts();
            return bankCustomers;
        }
        public List<Bank> GetBankAccounts()
        {
            var bankAccounts = bankRepository.GetBankAccounts();
            return bankAccounts;
        }

        public List<Bank> GetBanks()
        {
            var banks = bankRepository.GetBanks();
            return banks;
        }

        public Bank FindBankById(long id)
        {
            throw new NotImplementedException();
        }

       
        public void UpdateBank(Bank bank)
        {
            throw new NotImplementedException();
        }

        public void DeleteBank(int id)
        {
            bankRepository.Delete(id);
        }

        //public List<Transaction> AccountTransactions(string iban)
        //{
        //    var accountTransactions = bankRepository.GetBanks();
        //    return accountTransactions;
        //}
    }
}
