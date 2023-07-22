using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.advancedCS.LINQ
{
    public class Operations
    {
        public bool QuerySyntaxType { get; set; }

        public Operations(bool syntax) 
        { 
            this.QuerySyntaxType = syntax;
        }

        // Method to fetch customers whose balance is less than 1000
        public List<string> FetchCustomer(List<Accounts> accList)
        {
            if(this.QuerySyntaxType)
            {
                return (from account in accList
                        where account.Balance < 1000
                        select account.CustomerName)
                .ToList();
            }
            return accList
                .Where(account => account.Balance < 1000)
                .Select(account => account.CustomerName)
                .ToList();
        }

        // Method to fetch customer names in descending order of their reward points
        public List<string> FetchCustomerInOrder(List<Accounts> accList)
        {

            if(this.QuerySyntaxType)
            {
                return (from account in accList
                        orderby account.RewardPoints descending
                        select account.CustomerName)
                .ToList();
            }
            return accList
                .OrderByDescending(account => account.RewardPoints)
                .Select(account => account.CustomerName)
                .ToList();
        }

        // Method to fetch the account number of the customer with a specific name
        public string FetchAccountNumber(List<Accounts> accList, string customerName)
        {
            if(this.QuerySyntaxType)
            {
                return (from account in accList
                        where string.Equals(account.CustomerName, customerName, StringComparison.OrdinalIgnoreCase)
                        select account.AccountNumber)
                .FirstOrDefault();
            }
            return accList
                .Where(account => account.CustomerName.Equals(customerName, StringComparison.OrdinalIgnoreCase))
                .Select(account => account.AccountNumber)
                .FirstOrDefault();
        }

        // Method to fetch the total balance for each customer
        public Dictionary<string, int> FetchSumOfBalance(List<Accounts> accList)
        {
            if(this.QuerySyntaxType)
            {
                return (from account in accList
                        group account by account.CustomerName into g
                        select new { CustomerName = g.Key, TotalBalance = g.Sum(a => a.Balance) })
                .ToDictionary(a => a.CustomerName, a => a.TotalBalance);
            }
            return accList
                .GroupBy(account => account.CustomerName)
                .ToDictionary(group => group.Key, group => group.Sum(account => account.Balance));
        }

        // Method to fetch the total number of accounts of a specific type
        public int FetchNoOfAccount(List<Accounts> accList, string accountType)
        {
            if(this.QuerySyntaxType)
            {
                return (from account in accList
                        where string.Equals(account.AccountType, accountType, StringComparison.OrdinalIgnoreCase)
                        select account)
                .Count();
            }
            return accList
                .Count(account => account.AccountType.Equals(accountType, StringComparison.OrdinalIgnoreCase));
        }
    }
}
