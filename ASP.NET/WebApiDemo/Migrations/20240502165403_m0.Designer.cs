﻿// <auto-generated />
using System;
using WebApiDemo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace WebApiDemo.Migrations
{
    [DbContext(typeof(CafeDbContext))]
    [Migration("20240502165403_m0")]
    partial class m0
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("Cafe.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("TEXT");

                    b.Property<string>("IdCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IdCode")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birthday = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdCode = "1234567890",
                            Name = "Administartor",
                            Password = "12345"
                        },
                        new
                        {
                            Id = 3,
                            Birthday = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdCode = "1234567892",
                            Name = "Manager",
                            Password = "12345"
                        },
                        new
                        {
                            Id = 4,
                            Birthday = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdCode = "1234567893",
                            Name = "Barmen",
                            Password = "12345"
                        },
                        new
                        {
                            Id = 5,
                            Birthday = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdCode = "1234567894",
                            Name = "Cook",
                            Password = "12345"
                        },
                        new
                        {
                            Id = 2,
                            Birthday = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdCode = "1234567891",
                            Name = "Waiter",
                            Password = "12345"
                        });
                });

            modelBuilder.Entity("Cafe.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Role = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Role = 4,
                            UserId = 3
                        },
                        new
                        {
                            Id = 3,
                            Role = 2,
                            UserId = 2
                        },
                        new
                        {
                            Id = 4,
                            Role = 5,
                            UserId = 5
                        },
                        new
                        {
                            Id = 5,
                            Role = 3,
                            UserId = 4
                        });
                });

            modelBuilder.Entity("Cafe.Models.UserRole", b =>
                {
                    b.HasOne("Cafe.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
