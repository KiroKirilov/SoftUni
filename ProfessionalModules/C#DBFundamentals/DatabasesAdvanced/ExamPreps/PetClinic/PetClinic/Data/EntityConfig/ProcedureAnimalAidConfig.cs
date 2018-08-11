using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetClinic.Models;

    public class ProcedureAnimalAidConfig : IEntityTypeConfiguration<ProcedureAnimalAid>
    {
        public void Configure(EntityTypeBuilder<ProcedureAnimalAid> builder)
        {
            builder.HasKey(e => new { e.AnimalAidId, e.ProcedureId });

            builder.HasOne(e => e.AnimalAid)
                .WithMany(x => x.AnimalAidProcedures)
                .HasForeignKey(e => e.AnimalAidId);

            builder.HasOne(e => e.Procedure)
               .WithMany(x => x.ProcedureAnimalAids)
               .HasForeignKey(e => e.ProcedureId);
        }
    }
}
