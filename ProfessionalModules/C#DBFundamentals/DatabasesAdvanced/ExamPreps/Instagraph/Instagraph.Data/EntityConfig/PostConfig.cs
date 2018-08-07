using System;
using System.Collections.Generic;
using System.Text;

namespace Instagraph.Data.EntityConfig
{
    using Instagraph.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Caption)
                .IsRequired();

            builder.HasOne(e => e.Picture)
                .WithMany(x => x.Posts)
                .HasForeignKey(e => e.PictureId);

            builder.HasOne(e => e.User)
               .WithMany(x => x.Posts)
               .HasForeignKey(e => e.UserId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
