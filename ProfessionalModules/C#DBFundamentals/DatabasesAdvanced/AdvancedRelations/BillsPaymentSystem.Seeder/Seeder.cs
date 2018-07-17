using BillsPaymentSystem.Data;
using BillsPaymentSystem.Seeder.Seeders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BillsPaymentSystem.Seeder
{
    public class Seeder
    {
        public static void Seed(BillsPaymentSystemContext context)
        {
            InsertUsers(context);
            InsertCreditCard(context);
            InsertBankAccounts(context);
            InsertPaymentMethods(context);
        }

        private static void InsertCreditCard(BillsPaymentSystemContext context)
        {
            var creditCards = CreditCardSeeder.GetCreditCards();

            foreach (var card in creditCards)
            {
                if (IsValid(card))
                {
                    context.CreditCards.Add(card);
                }
            }

            context.SaveChanges();
        }

        private static void InsertBankAccounts(BillsPaymentSystemContext context)
        {
            var bankAccounts = BankAccountSeeder.GetBankAccounts();

            foreach (var account in bankAccounts)
            {
                if (IsValid(account))
                {
                    context.BankAccounts.Add(account);
                }
            }

            context.SaveChanges();
        }

        private static void InsertPaymentMethods(BillsPaymentSystemContext context)
        {
            var paymentMethods = PaymentMethodSeeder.GetPaymentMethods();

            foreach (var method in paymentMethods)
            {
                if (IsValid(method))
                {
                    context.PaymentMethods.Add(method);
                }
            }

            context.SaveChanges();
        }

        private static void InsertUsers(BillsPaymentSystemContext context)
        {
            var users = UserSeeder.GetUsers();

            foreach (var user in users)
            {
                if (IsValid(user))
                {
                    context.Users.Add(user);
                }
            }

            context.SaveChanges();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var result = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, result, true);
        }
    }
}
