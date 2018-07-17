using BillsPaymentSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillsPaymentSystem.Data.Config.EntityConfig
{
    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasIndex(e => new { e.BankAccountId, e.CreditCardId, e.UserId })
                .IsUnique();

            builder.Property(e => e.UserId)
                .IsRequired();

            builder.HasOne(e => e.User)
                .WithMany(u => u.PaymentMethods)
                .HasForeignKey(e => e.UserId);

            builder.HasOne(e => e.CreditCard)
                .WithMany(c => c.PaymentMethods)
                .HasForeignKey(e => e.CreditCardId);

            builder.HasOne(e => e.BankAccount)
                .WithMany(b => b.PaymentMethods)
                .HasForeignKey(e => e.BankAccountId);
        }
    }
}
