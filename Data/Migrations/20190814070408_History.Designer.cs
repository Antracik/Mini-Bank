﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(BankContext))]
    [Migration("20190814070408_History")]
    partial class History
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Entities.AccountDbRepoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountStatusId")
                        .HasColumnName("StatusId");

                    b.Property<decimal>("Balance")
                        .HasColumnType("money");

                    b.Property<int>("CreatedById");

                    b.Property<int>("CurrencyId")
                        .HasColumnName("CurrencyId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateEdited");

                    b.Property<int?>("EditedById");

                    b.Property<string>("IBAN")
                        .IsRequired();

                    b.Property<int>("WalletId");

                    b.HasKey("Id");

                    b.HasIndex("AccountStatusId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("EditedById");

                    b.HasIndex("WalletId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("Data.Entities.CountryDbRepoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("Data.Entities.CurrencyDbRepoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("Data.Entities.RegistrantDbRepoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<int>("Country")
                        .HasColumnName("CountryId");

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateEdited");

                    b.Property<int?>("EditedById");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("Country");

                    b.HasIndex("CreatedById");

                    b.HasIndex("EditedById");

                    b.HasIndex("UserId");

                    b.ToTable("Registrant");
                });

            modelBuilder.Entity("Data.Entities.StatusDbRepoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Data.Entities.UserDbRepoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateEdited");

                    b.Property<int?>("EditedById");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("EditedById");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Data.Entities.WalletDbRepoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateEdited");

                    b.Property<int?>("EditedById");

                    b.Property<bool>("IsVerified");

                    b.Property<int>("Number");

                    b.Property<int>("RegistrantId");

                    b.Property<int>("WalletStatusId")
                        .HasColumnName("WalletStatusId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("EditedById");

                    b.HasIndex("RegistrantId");

                    b.HasIndex("WalletStatusId");

                    b.ToTable("Wallet");
                });

            modelBuilder.Entity("Data.Entities.AccountDbRepoModel", b =>
                {
                    b.HasOne("Data.Entities.StatusDbRepoModel", "Status")
                        .WithMany()
                        .HasForeignKey("AccountStatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Entities.UserDbRepoModel", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Entities.CurrencyDbRepoModel", "CurrencyRelation")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Entities.UserDbRepoModel", "EditedByUser")
                        .WithMany()
                        .HasForeignKey("EditedById");

                    b.HasOne("Data.Entities.WalletDbRepoModel", "Wallet")
                        .WithMany("Accounts")
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Entities.RegistrantDbRepoModel", b =>
                {
                    b.HasOne("Data.Entities.CountryDbRepoModel", "CountryRelation")
                        .WithMany()
                        .HasForeignKey("Country")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Entities.UserDbRepoModel", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Entities.UserDbRepoModel", "EditedByUser")
                        .WithMany()
                        .HasForeignKey("EditedById");

                    b.HasOne("Data.Entities.UserDbRepoModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Entities.UserDbRepoModel", b =>
                {
                    b.HasOne("Data.Entities.UserDbRepoModel", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Entities.UserDbRepoModel", "EditedByUser")
                        .WithMany()
                        .HasForeignKey("EditedById");
                });

            modelBuilder.Entity("Data.Entities.WalletDbRepoModel", b =>
                {
                    b.HasOne("Data.Entities.UserDbRepoModel", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Entities.UserDbRepoModel", "EditedByUser")
                        .WithMany()
                        .HasForeignKey("EditedById");

                    b.HasOne("Data.Entities.RegistrantDbRepoModel", "Registrant")
                        .WithMany()
                        .HasForeignKey("RegistrantId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Entities.StatusDbRepoModel", "Status")
                        .WithMany()
                        .HasForeignKey("WalletStatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
