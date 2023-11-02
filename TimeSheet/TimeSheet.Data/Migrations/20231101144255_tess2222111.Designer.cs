﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimeSheet.Data.Data;

#nullable disable

namespace TimeSheet.Data.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20231101144255_tess2222111")]
    partial class tess2222111
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TimeSheet.Data.Models.CategoryEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TimeSheet.Data.Models.ClientEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CountryId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("TimeSheet.Data.Models.CountryEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("TimeSheet.Data.Models.ProjectEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LeadId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("LeadId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("TimeSheet.Data.Models.UserEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TimeSheet.Data.Models.WorkHourEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float>("OverTime")
                        .HasColumnType("float");

                    b.Property<string>("ProjectId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<float>("Time")
                        .HasColumnType("float");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("WorkHours");
                });

            modelBuilder.Entity("TimeSheet.Data.Models.ClientEntity", b =>
                {
                    b.HasOne("TimeSheet.Data.Models.CountryEntity", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("TimeSheet.Data.Models.ProjectEntity", b =>
                {
                    b.HasOne("TimeSheet.Data.Models.ClientEntity", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimeSheet.Data.Models.UserEntity", "Lead")
                        .WithMany()
                        .HasForeignKey("LeadId");

                    b.Navigation("Client");

                    b.Navigation("Lead");
                });

            modelBuilder.Entity("TimeSheet.Data.Models.WorkHourEntity", b =>
                {
                    b.HasOne("TimeSheet.Data.Models.CategoryEntity", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimeSheet.Data.Models.ProjectEntity", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimeSheet.Data.Models.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Project");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
