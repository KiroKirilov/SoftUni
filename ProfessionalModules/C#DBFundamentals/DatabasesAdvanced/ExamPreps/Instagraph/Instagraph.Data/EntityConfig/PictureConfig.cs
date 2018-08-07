using System;
using System.Collections.Generic;
using System.Text;

namespace Instagraph.Data.EntityConfig
{
    using Instagraph.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PictureConfig : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Path)
                .IsRequired();

            builder.Property(e => e.Size)
                .IsRequired();
        }
    }
}
