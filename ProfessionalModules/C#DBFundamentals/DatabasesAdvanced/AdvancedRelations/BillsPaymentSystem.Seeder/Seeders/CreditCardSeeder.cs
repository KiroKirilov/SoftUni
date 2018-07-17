using BillsPaymentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillsPaymentSystem.Seeder.Seeders
{
    public class CreditCardSeeder
    {
        public static CreditCard[] GetCreditCards()
        {
            CreditCard[] creditCards = new CreditCard[]
            {
            new CreditCard(){ Limit=3330m, MoneyOwed=0m, ExpirationDate=DateTime.Now.AddMonths(10) },
            new CreditCard(){ Limit=10000m, MoneyOwed=0m, ExpirationDate=DateTime.Now.AddMonths(-10) },
            new CreditCard(){ Limit=50000m, MoneyOwed=0m, ExpirationDate=DateTime.Now.AddMonths(100) },
            new CreditCard(){ Limit=1000m, MoneyOwed=0m, ExpirationDate=DateTime.Now.AddMonths(12) },
            new CreditCard(){ Limit=1200m, MoneyOwed=0m, ExpirationDate=DateTime.Now.AddMonths(24) },
            new CreditCard(){ Limit=900m, MoneyOwed=0m, ExpirationDate=DateTime.Now.AddMonths(123) },
            new CreditCard(){ Limit=15000m, MoneyOwed=0m, ExpirationDate=DateTime.Now.AddMonths(-120) },
            new CreditCard(){ Limit=100000m, MoneyOwed=0m, ExpirationDate=DateTime.Now.AddMonths(-123) },
            new CreditCard(){ Limit=123456m, MoneyOwed=0m, ExpirationDate=DateTime.Now.AddMonths(140) },
            new CreditCard(){ Limit=10000m, MoneyOwed=0m, ExpirationDate=DateTime.Now.AddMonths(-140) }
            };

            return creditCards;
        }
    }
}
