using System;

namespace Delegate_Event
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // BankAccount classindan bir obyekt yaradiriq
            BankAccount account = new BankAccount()
            {
                Owner = "Mirsaid Seyidli",
                Balance = 4000,
                İban = "AZE123456789",
                BankName = "Kapital Bank"
            };

            // BankAccount classindaki eventa ShowMessage methodunu elave edirik
            account.OnTransaction += ShowMessage;
            account.OnTransaction += SmsNotification;
          
            account.OnTransaction += EmailNotification;

            // Withdraw methodunu cagiririq
            

            account.OnTransaction -= SmsNotification;
            account.OnTransaction -= EmailNotification;

            account.BonusCalculator += CalculateBonus;
            account.Withdraw(500, account.Owner, account.İban, account.BankName);
            //account.Withdraw(2348, account.Owner, account.İban, account.BankName);
        }


        // Bu methoda event cagrilanda gonderilen mesaj gelecek
        static void ShowMessage(string message) => Console.WriteLine(message);
        static void SmsNotification(string message) => Console.WriteLine($"SMS: {message}");
        static void EmailNotification(string message) => Console.WriteLine($"Email: {message}");

        static decimal CalculateBonus(string owner, decimal amount)
        {
            // Bonus hesablamasi ucun sadə bir qayda: əgər məbləğ 1000-dən böyükdürsə, bonus 50-dir
            if (amount > 1000)
                return amount * 0.1m; // Bonus məbləği, məbləğin 10%-i olaraq hesablanır
            else
                return amount * 0.05m; // Bonus məbləği, məbləğin 5%-i olaraq hesablanır
        }
    }
}
