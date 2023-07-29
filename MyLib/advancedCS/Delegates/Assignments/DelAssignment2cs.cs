using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.advancedCS.Delegates.Assignments
{
    public delegate void GetBonus(double amount);
    public class BankAccount
    {
        private double balance;
        public double Balance { get { return balance; }
                                set { balance = value; } }

        public void Credit(double amount)
        {
            balance += amount;
        }

        public bool Debit(double amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    public class Employee
    {
        public BankAccount Account { get; set; }

        public int NoOfShares { get; set; }

        public double PensionFundBalance { get; set; }

        public void SetBankAccountCredit(double amount)
        {
            Account.Credit(amount);
        }

        public void SetPensionFundCredit(double amount)
        {
            PensionFundBalance += amount;
        }

        public void SetNumberOfShares(double amount)
        {
            int numberOfSharesToBeIncremented = (int)(amount / 100);
            NoOfShares += numberOfSharesToBeIncremented;
        }

        public void GiveBonus(int bonusOption, double amount)
        {
            GetBonus getBonus;

            switch (bonusOption)
            {
                case 1:
                    getBonus = new GetBonus(Account.Credit);
                    break;
                case 2:
                    getBonus = new GetBonus(SetPensionFundCredit);
                    break;
                case 3:
                    getBonus = new GetBonus(SetNumberOfShares);
                    break;
                default:
                    getBonus = new GetBonus(Account.Credit);
                    break;
            }

            getBonus(amount);
        }
    }

    public class DelAssignment2cs
    {
        public void Main()
        {
            BankAccount bankAccount = new BankAccount();
            Employee employee = new Employee
            {
                Account = bankAccount,
                NoOfShares = 100,
                PensionFundBalance = 5000
            };

            Console.WriteLine("Initial Bank Account Balance: " + bankAccount.Balance);
            Console.WriteLine("Initial Number of Shares: " + employee.NoOfShares);
            Console.WriteLine("Initial Pension Fund Balance: " + employee.PensionFundBalance);

            employee.GiveBonus(1, 2000); // Credit bonus to Bank Account
            employee.GiveBonus(2, 1000); // Credit bonus to Pension Fund
            employee.GiveBonus(3, 500);  // Increment shares
            employee.GiveBonus(4, 300);  // Credit bonus to Bank Account (default)

            Console.WriteLine("Final Bank Account Balance: " + bankAccount.Balance);
            Console.WriteLine("Final Number of Shares: " + employee.NoOfShares);
            Console.WriteLine("Final Pension Fund Balance: " + employee.PensionFundBalance);
        }
    }
}
