using System;
using Lab8.AccountType;

namespace Lab8.BankAccount
{
    public class BankAccount
    {
        private static int nextAccount = 1;
        private readonly int accountNumber;
        private decimal balance;
        private readonly AccountT accountType;

        public BankAccount(AccountT accountType)
        {
            this.accountNumber = nextAccount++;
            this.accountType = accountType;
            this.balance = 0;
        }

        public int GetAccountNumber()
        {
            return accountNumber;
        }

        public decimal GetBalance()
        {
            return balance;
        }

        public AccountT GetAccountType()
        {
            return accountType;
        }

        public void Replenishment(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"внесено: {amount}. текущий баланс: {balance}");
            }
            else
            {
                Console.WriteLine("сумма пополнения должна быть > 0");
            }
        }

        public void Take0ff(decimal amount)
        {
            if (amount > balance)
            {
                Console.WriteLine("недостаточно средств");
            }
            else
            {
                balance -= amount;
                Console.WriteLine($"снято: {amount}. остаток: {balance}");
            }
        }

        public void Info()
        {
            Console.WriteLine($"номер счета: {accountNumber}, тип счета: {accountType}, баланс: {balance}");
        }

        public void Transaction(BankAccount transAccount, decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Сумма перевода должна быть больше 0.");
                return;
            }

            if (amount > this.balance)
            {
                Console.WriteLine("Недостаточно средств для перевода.");
                return;
            }

            this.Take0ff(amount);
            transAccount.Replenishment(amount);
            Console.WriteLine($"Переведено {amount} с счета {this.accountNumber} на счет {transAccount.accountNumber}.");
        }
    }
}
