﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MishMashWebApp.Data;

namespace MishMashWebApp.Migrations
{
    [DbContext(typeof(MishMashDbContext))]
    [Migration("20181025175814_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MishMashWebApp.Models.Channel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Channels");
                });

            modelBuilder.Entity("MishMashWebApp.Models.ChannelTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChannelId");

                    b.Property<int>("TagId");

                    b.HasKey("Id");

                    b.HasIndex("ChannelId");

                    b.HasIndex("TagId");

                    b.ToTable("ChannelsTags");
                });

            modelBuilder.Entity("MishMashWebApp.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("MishMashWebApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<int>("Role");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MishMashWebApp.Models.UserChannel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChannelId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ChannelId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersChannels");
                });

            modelBuilder.Entity("MishMashWebApp.Models.ChannelTag", b =>
                {
                    b.HasOne("MishMashWebApp.Models.Channel", "Channel")
                        .WithMany("Tags")
                        .HasForeignKey("ChannelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MishMashWebApp.Models.Tag", "Tag")
                        .WithMany("Channels")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MishMashWebApp.Models.UserChannel", b =>
                {
                    b.HasOne("MishMashWebApp.Models.Channel", "Channel")
                        .WithMany("Followers")
                        .HasForeignKey("ChannelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MishMashWebApp.Models.User", "User")
                        .WithMany("FollowedChannels")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
