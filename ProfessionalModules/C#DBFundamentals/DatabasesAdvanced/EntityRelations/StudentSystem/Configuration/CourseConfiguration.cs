using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Configuration
{
    class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.CourseId);

            builder.Property(c => c.Name)
                .HasMaxLength(80)
                .IsUnicode(true)
                .IsRequired(true);

            builder.Property(c => c.Description)
                .IsUnicode(true)
                .IsRequired(false);

            builder.Property(c => c.StartDate)
                .IsRequired(true);

            builder.Property(c => c.EndDate)
                .IsRequired(true);

            builder.Property(c => c.Price)
                .IsRequired(true);
        }
    }
}
