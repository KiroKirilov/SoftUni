using System;
using System.Collections.Generic;
using System.Text;

namespace BillsPaymentSystem.Data.Models
{
    public class BankAccount
    {
        public int BankAccountId { get; set; }

        public decimal Balance { get; private set; }

        public string BankName { get; set; }

        public string SwiftCode { get; set; }

        public ICollection<PaymentMethod> PaymentMethods { get; set; }

        public void Deposit(decimal amount)
        {
            if (amount>0)
            {
                this.Balance += amount;
            }
        }

        public void Withdraw(decimal amount)
        {
            if (this.Balance-amount >= 0 && amount>0)
            {
                this.Balance -= amount;
            }
        }
    }
}
