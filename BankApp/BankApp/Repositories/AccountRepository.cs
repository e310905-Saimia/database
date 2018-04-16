using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankApp.Models;

namespace BankApp.Repositories
{
    class AccountRepository:IAccount
    {
        /// <summary>
        /// 1. etsitään oikea tili, jolle tilitapahtuma kirjataan
        /// 2. tilin saldo (Balance) laitetaan vastaaman oikeaa suoritusta +/- tapahtuma
        /// 3. päivitetään Account:n Balance
        /// 4. Tallennetaan muutokset sekä Transaction että Account tauluihin
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        //public bool AddTransaction(Transaction transaction)
        //{
        //    bool res = false;
        //    using (var context = new BankdbContext())
        //    {
        //        try
        //        {                    
        //            context.Add(transaction);
        //            var account = GetAccountByIban(transaction.Iban);
        //            decimal balanceBeforeTransaction = account.Balance;
        //            var lastTransaction = GetTransactionsOfAccount(transaction.Iban);
        //            int result = DateTime.Compare(transaction.TimeStamp, lastTransaction.TimeStamp);
        //            if (result>0)
        //            {
        //                account.Balance += transaction.Amount;
        //            }
        //            if (account.Balance - transaction.Amount == balanceBeforeTransaction)
        //            {
        //                res = true;
        //            }

        //            //Update Account-table
        //            context.Account.Update(account);

        //            context.SaveChanges();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message} \n");
        //        }
        //        return res;
        //    }                                
        //}
        /// <summary>
        /// 1. etsitään oikea tili, jolle tilitapahtuma kirjataan
        /// 2. tilin saldo (Balance) laitetaan vastaaman oikeaa suoritusta +/- tapahtuma
        /// 3. päivitetään Account:n Balance
        /// 4. Tallennetaan muutokset sekä Transaction että Account tauluihin
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public void AddTransaction(Transaction transaction)
        {            
            using (var context = new BankdbContext())
            {
                try
                {
                    //Lisätään tapahtumatauluun rivi
                    context.Add(transaction);

                    //Etsitään tili, jonka tietoja päivitetään
                    var account = GetAccountByIban(transaction.Iban);
                    //Lasketaan tilille uusi saldoa
                    account.Balance += transaction.Amount;

                    //Update Account-table
                    context.Account.Update(account);
                    //Tallennetaan muutokset tietokantaan
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message} \n");
                }
                
            }
        }

        public Account GetAccountByIban(string iban)
        {
            using (var context = new BankdbContext())
            {
                try
                {
                    var account = context.Account.FirstOrDefault(a => a.Iban == iban);
                    return account;
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message} \nXXX");
                }
            }
        }

        public List<Transaction> GetTransactionsForTimeSpan(DateTime startTime, DateTime endTime)
        {
            throw new NotImplementedException();
        }

        public List<Transaction> GetTransactionsForTimeSpan(string iban)
        {
            throw new NotImplementedException();
        }

        public Transaction GetTransactionsOfAccount(string iban)
        {
            using (var context = new BankdbContext())
            {
                try
                {
                    var transaction = context.Transaction.Last(t => t.Iban == iban);
                    return transaction;
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message} \nXXX");
                }
            }
        }
    }
}
