using BillsPaymentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillsPaymentSystem.Seeder.Seeders
{
    public class PaymentMethodSeeder
    {
        public static PaymentMethod[] GetPaymentMethods()
        {
            PaymentMethod[] paymentMethods = new PaymentMethod[]
            {
                new PaymentMethod() { UserId=1,CreditCardId=1,Type=PaymentMethodType.CreditCard},
                new PaymentMethod() {UserId=2, BankAccountId=2,Type=PaymentMethodType.BankAccount},
                new PaymentMethod() { UserId=3,CreditCardId=3,Type=PaymentMethodType.CreditCard},
                new PaymentMethod() {UserId=4, BankAccountId=4,Type=PaymentMethodType.BankAccount},
                new PaymentMethod() { UserId=5,CreditCardId=5,Type=PaymentMethodType.CreditCard},
                new PaymentMethod() {UserId=6, BankAccountId=6,Type=PaymentMethodType.BankAccount},
                new PaymentMethod() { UserId=7,CreditCardId=7,Type=PaymentMethodType.CreditCard},
                new PaymentMethod() {UserId=8, BankAccountId=8,Type=PaymentMethodType.BankAccount}
            };

            return paymentMethods;
        }
    }
}
