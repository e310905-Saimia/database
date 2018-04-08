using System;
using System.Collections.Generic;
using BankApp.Models;
using System.Data.SqlTypes;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Repositories
{
    /// <summary>
    /// Täällä otetaan yhteys tietokantaan ja suoritetaan tietokannan käpistely
    /// </summary>
    class BankRepository:IBank
    {
        public List<Bank> GetBanks()
        {
            using (var context = new BankdbContext())
            {
                try
                {
                    List<Bank> banks = context.Bank.ToListAsync().Result;
                    return banks;
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message} \n");
                }

            }
        }

        public List<Bank> GetBankCustomers()
        {
            using (var context = new BankdbContext())
            {
                try
                {
                    List<Bank> banks = context.Bank
                        .Include(b => b.Customer)
                        .ToListAsync().Result;
                    return banks;
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message} \n");
                }

            }            
            
           
        }

        public List<Bank> GetBankAccounts()
        {
            throw new NotImplementedException();
        }

        public Bank GetBankById(long id)
        {
            using (var context = new BankdbContext())
            {
                try
                {
                    var bank = context.Bank.FirstOrDefault(b => b.Id == id);
                    return bank;
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message} \nXXX");
                }

            }
        }

        public void Create(Bank bank)
        {
            using (var context = new BankdbContext())
            {
                try
                {
                    context.Add(bank);
                    context.SaveChanges();
                }                
                catch (Exception ex)
                {                    
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message} \nXXX");
                }

            }
                
        }

        public void Update(Bank bank)
        {
            using (var context = new BankdbContext())
            {
                try
                {
                    var updateBank = GetBankById(bank.Id);
                    if (updateBank != null)
                    {
                        updateBank.Name = bank.Name;
                        updateBank.Bic = bank.Bic;                        
                        context.Bank.Update(updateBank);
                    }
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message} \nXXX");
                }

            }
        }

        public void Delete(int id)
        {
            using (var context = new BankdbContext())
            {
                try
                {
                    var delBank = context.Bank.FirstOrDefault(b => b.Id == id);
                    if (delBank != null)
                        context.Bank.Remove(delBank);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message} \nXXX");
                }

            }
        }
    }
}
