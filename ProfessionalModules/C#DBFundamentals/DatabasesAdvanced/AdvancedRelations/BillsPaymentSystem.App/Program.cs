using BillsPaymentSystem.Data;
using BillsPaymentSystem.Data.Models;
using BillsPaymentSystem.Seeder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;

namespace BillsPaymentSystem.App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context=new BillsPaymentSystemContext())
            {
                User user = GetUser(context);
                Console.WriteLine(GetUserInfo(user));
            }
        }

        private static void PayBills(User user, decimal amount)
        {
            decimal bankAccountTotals = user.PaymentMethods.Where(pm => pm.BankAccount != null).Sum(pm => pm.BankAccount.Balance);
            decimal creditCardTotals = user.PaymentMethods.Where(pm => pm.CreditCard != null).Sum(pm => pm.CreditCard.LimitLeft);
            decimal total = bankAccountTotals + creditCardTotals;

            if (total>=amount)
            {
                var bankAccounts = user.PaymentMethods.Where(pm => pm.BankAccount != null).Select(pm => pm.BankAccount).OrderBy(b => b.BankAccountId).ToList();

                foreach (var ba in bankAccounts)
                {
                    if (amount==0)
                    {
                        return;
                    }

                    if (ba.Balance>=amount)
                    {
                        ba.Withdraw(amount);
                        break;
                    }
                    else
                    {
                        amount -= ba.Balance;
                        ba.Withdraw(ba.Balance);
                    }
                }

                var creditCards = user.PaymentMethods.Where(pm => pm.CreditCard != null).Select(pm => pm.CreditCard).OrderBy(c => c.CreditCardId).ToList();

                foreach (var cc in creditCards)
                {
                    if (amount==0)
                    {
                        return;
                    }

                    if (cc.LimitLeft>=amount)
                    {
                        cc.Withdraw(amount);
                        break;
                    }
                    else
                    {
                        amount -= cc.LimitLeft;
                        cc.Withdraw(cc.LimitLeft);
                    }
                }
            }
            else
            {
                Console.WriteLine("Insufficient funds!");
            }
        }

        private static string GetUserInfo(User user)
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"User: {user.FirstName} {user.LastName}");
            output.AppendLine("Bank Accounts:");
            foreach (var ba in user.PaymentMethods
                                    .Where(pm => pm.BankAccount != null)
                                    .Select(pm=>pm.BankAccount))
            {
                output.AppendLine($"-- ID: {ba.BankAccountId}");
                output.AppendLine($"--- Balance: {ba.Balance:f2}");
                output.AppendLine($"--- Bank: {ba.BankName}");
                output.AppendLine($"--- SWIFT: {ba.SwiftCode}");
                                                                                 
            }

            output.AppendLine("Credit cards:");
            foreach (var cc in user.PaymentMethods
                                    .Where(pm => pm.CreditCard != null)
                                    .Select(pm => pm.CreditCard))
            {
                output.AppendLine($"-- ID: {cc.CreditCardId}");
                output.AppendLine($"--- Limit: {cc.Limit:f2}");
                output.AppendLine($"--- Money Owed: {cc.MoneyOwed:f2}");
                output.AppendLine($"--- Limit Left:: {cc.LimitLeft:f2}");
                output.AppendLine($"--- Expiration Date: {cc.ExpirationDate.ToString("yyyy/MM")}");
            }

            return output.ToString();
        }

        private static User GetUser(BillsPaymentSystemContext context)
        {
            User user = null;

            while (true)
            {
                int userId = int.Parse(Console.ReadLine());

                user = context.Users
                .Include(u => u.PaymentMethods)
                .ThenInclude(pm => pm.CreditCard)
                .Include(u => u.PaymentMethods)
                .ThenInclude(pm => pm.BankAccount)
                .FirstOrDefault(u => u.UserId == userId);

                if (user==null)
                {
                    Console.WriteLine($"User with id {userId} not found!");
                    continue;
                }

                break;
            }

            return user;
        }
    }
}
