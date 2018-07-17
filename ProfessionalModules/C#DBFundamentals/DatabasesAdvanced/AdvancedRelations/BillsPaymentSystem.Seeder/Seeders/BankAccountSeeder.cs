using BillsPaymentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillsPaymentSystem.Seeder.Seeders
{
    public class BankAccountSeeder
    {
        public static BankAccount[] GetBankAccounts()
        {
            BankAccount[] bankAccounts = new BankAccount[]
            {
                new BankAccount() { BankName="First InvestsioiWhatever Bank", SwiftCode="FIB", Balance=10000 },
                new BankAccount() { BankName="Societte Generale Expressbank", SwiftCode="SGB", Balance=100000 },
                new BankAccount() { BankName="DSK Bank", SwiftCode="DSK", Balance=125000 },
                new BankAccount() { BankName="Alianz", SwiftCode="ALZ", Balance=15000 },
                new BankAccount() { BankName="Post Bank", SwiftCode="PST", Balance=5000 },
                new BankAccount() { BankName="Central Cooperative Bank", SwiftCode="CKB", Balance=8000 },
                new BankAccount() { BankName="Raifisen Bank", SwiftCode="RFS", Balance=150000 },
                new BankAccount() { BankName="United Bulgarian Bank", SwiftCode="UBB", Balance=13000 },
                new BankAccount() { BankName="Unicredit Bulbank", SwiftCode="UNI", Balance=18000 },
                new BankAccount() { BankName="Pireus Bank", SwiftCode="PIR", Balance=7500 }

            };

            return bankAccounts;
        }
    }
}
