using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.Data.EnityConfig
{
    using FastFood.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasOne(e => e.Position)
                .WithMany(x => x.Employees)
                .HasForeignKey(e => e.PositionId);


        }
    }
}
