using System;
using BankApp.Models;
using BankApp.Services;


namespace BankApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("BankApp v1.1");
                BankService bankService = new BankService();
                var bankCustomers = bankService.GetBankCustomers();
                foreach (var bC in bankCustomers)
                {
                    Console.WriteLine(bC.ToString());
                    foreach (var c in bC.Customer)
                    {
                        Console.WriteLine(c.ToString());
                    }
                }


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
