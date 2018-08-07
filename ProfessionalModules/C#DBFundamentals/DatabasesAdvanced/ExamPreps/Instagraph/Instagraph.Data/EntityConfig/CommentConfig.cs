using System;
using System.Collections.Generic;
using System.Text;

namespace Instagraph.Data.EntityConfig
{
    using Instagraph.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Content)
                .IsRequired()
                .HasMaxLength(250);

            builder.HasOne(e => e.Post)
                .WithMany(x => x.Comments)
                .HasForeignKey(e => e.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.User)
               .WithMany(x => x.Comments)
               .HasForeignKey(e => e.UserId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
