using System;
using BankApp.Models;
using BankApp.Repositories;
using BankApp.Services;
using BankApp.Views;



namespace BankApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("BankApp v1.1");
                BankView bankView = new BankView();
                //bankView.DeleteBank();
                //bankView.CreateBankCustomerAccount();
                
                //AccountView accountView = new AccountView();
                //accountView.AddTransaction();
                bankView.PrintAllBanks();
                //AccountRepository accountRepository = new AccountRepository();
                ////var account = accountRepository.GetAccountByIban("FI44 1234");

                //Transaction transaction = new Transaction
                //{
                //    Iban= "FI44 1234",
                //    Amount = -500,
                //    TimeStamp = DateTime.Today
                //};
                //accountRepository.AddTransaction(transaction);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();

        }

        public static void CreateBank()
        {
            BankService bankService = new BankService();
            Bank bank = new Bank();
            bank.Name = "Ankkalinnan pankki";
            bank.Bic = "BICABCDEFG";
            bankService.CreateBank(bank);
        }
    }
}
