using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetClinic.Models;

    public class AnimalConfig : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasOne(e => e.Passport)
                .WithOne(x => x.Animal)
                .HasForeignKey<Animal>(e => e.PassportSerialNumber);
        }
    }
}
