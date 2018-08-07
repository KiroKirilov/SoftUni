using System;
using System.Collections.Generic;
using System.Text;

namespace Instagraph.Data.EntityConfig
{
    using Instagraph.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserFollowerConfig : IEntityTypeConfiguration<UserFollower>
    {
        public void Configure(EntityTypeBuilder<UserFollower> builder)
        {
            builder.HasKey(e => new { e.FollowerId, e.UserId });

            builder.HasOne(e => e.User)
                .WithMany(x => x.Followers)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Follower)
               .WithMany(x => x.UsersFollowing)
               .HasForeignKey(e => e.FollowerId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
