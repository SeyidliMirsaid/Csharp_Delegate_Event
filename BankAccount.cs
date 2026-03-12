
using System;
using System.Security.Cryptography;

namespace Delegate_Event
{
    public delegate void Notification(string message);
    public delegate decimal CalculateBonus(string owner, decimal amount);
    public class BankAccount
    {

        public decimal Balance;
        public string Owner;
        public string İban;
        public string BankName;

        public BankAccount() { }
        public BankAccount(string owner, decimal initialBalance)
        {
            Balance = initialBalance;
            Owner = owner;
        }

        // Event declaration
        public event Notification OnTransaction;
        public CalculateBonus BonusCalculator;


        // the money has been detucted method
        public void Withdraw(decimal amount, string customer, string customerIban, string bankName)
        {
            Balance -= amount; // Withdraw methodunda balance-den amount cixilir


            OnTransaction?.Invoke($"Customer : {customer} \nIban: {customerIban} \nBank: {bankName} \n" +
                $"${amount} has been deducted. New balance: ${Balance}\n");

            // Bonus eventini cagiririq
            if (BonusCalculator != null)
            {
                decimal bonusAmount = BonusCalculator.Invoke(customer, amount);
                if (bonusAmount > 0)
                {
                    Balance += bonusAmount;
                    Console.WriteLine($"Bonus: +${bonusAmount}");
                    Console.WriteLine($"New balance with bonus: ${Balance}");
                }
            }
        }
    }
}
