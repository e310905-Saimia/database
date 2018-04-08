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

        public List<Bank> GetBankAccounts()
        {
            throw new NotImplementedException();
        }

        public List<Bank> GetAllBanks()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
