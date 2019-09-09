﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mini_Bank.Migrations
{
    [DbContext(typeof(BankContext))]
    partial class BankContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Entities.AccountEntityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountStatusId")
                        .HasColumnName("StatusId");

                    b.Property<decimal>("Balance")
                        .HasColumnType("money");

                    b.Property<int?>("CreatedById");

                    b.Property<int>("CurrencyId")
                        .HasColumnName("CurrencyId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateEdited");

                    b.Property<int?>("EditedById");

                    b.Property<string>("IBAN")
                        .IsRequired();

                    b.Property<int>("WalletId")
                        .HasColumnName("WalletId");

                    b.HasKey("Id");

                    b.HasIndex("AccountStatusId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("EditedById");

                    b.HasIndex("WalletId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("Data.Entities.CountryEntityModel", b =>
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

            modelBuilder.Entity("Data.Entities.CurrencyEntityModel", b =>
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

            modelBuilder.Entity("Data.Entities.CurrencyExchangeEntityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FromCurrencyId");

                    b.Property<double>("Rate");

                    b.Property<int>("ToCurrencyId");

                    b.HasKey("Id");

                    b.HasIndex("FromCurrencyId");

                    b.HasIndex("ToCurrencyId");

                    b.ToTable("CurrencyExchange");
                });

            modelBuilder.Entity("Data.Entities.FileDescriptorEntityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateEdited");

                    b.Property<int?>("EditedById");

                    b.Property<string>("FileContentType");

                    b.Property<string>("FileExtension");

                    b.Property<int>("FileId");

                    b.Property<string>("FileName");

                    b.Property<string>("UniqueFileName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("EditedById");

                    b.HasIndex("FileId")
                        .IsUnique();

                    b.ToTable("FileDescriptor");
                });

            modelBuilder.Entity("Data.Entities.FileEntityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Data");

                    b.HasKey("Id");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("Data.Entities.RegistrantEntityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<int>("Country")
                        .HasColumnName("CountryId");

                    b.Property<int?>("CreatedById");

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

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Registrant");
                });

            modelBuilder.Entity("Data.Entities.RoleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Data.Entities.StatusEntityModel", b =>
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

            modelBuilder.Entity("Data.Entities.TransactionEntityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId");

                    b.Property<decimal>("Amount");

                    b.Property<int?>("CreatedById");

                    b.Property<int>("CurrencyId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateEdited");

                    b.Property<int?>("EditedById");

                    b.Property<string>("ToIBAN");

                    b.Property<int>("TransactionTypeId");

                    b.Property<string>("UniqueTransactionIdentifier");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("EditedById");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Data.Entities.TransactionTypeEntityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TransactionType");
                });

            modelBuilder.Entity("Data.Entities.UserEntityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<int?>("CreatedById");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateEdited");

                    b.Property<int?>("EditedById");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("EditedById");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Data.Entities.WalletEntityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedById");

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Data.Entities.AccountEntityModel", b =>
                {
                    b.HasOne("Data.Entities.StatusEntityModel", "Status")
                        .WithMany()
                        .HasForeignKey("AccountStatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Entities.UserEntityModel", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Data.Entities.CurrencyEntityModel", "CurrencyRelation")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Entities.UserEntityModel", "EditedByUser")
                        .WithMany()
                        .HasForeignKey("EditedById");

                    b.HasOne("Data.Entities.WalletEntityModel", "Wallet")
                        .WithMany("Accounts")
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Data.Entities.CurrencyExchangeEntityModel", b =>
                {
                    b.HasOne("Data.Entities.CurrencyEntityModel", "FromCurrency")
                        .WithMany()
                        .HasForeignKey("FromCurrencyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Data.Entities.CurrencyEntityModel", "ToCurrency")
                        .WithMany()
                        .HasForeignKey("ToCurrencyId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Data.Entities.FileDescriptorEntityModel", b =>
                {
                    b.HasOne("Data.Entities.UserEntityModel", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Data.Entities.UserEntityModel", "EditedByUser")
                        .WithMany()
                        .HasForeignKey("EditedById");

                    b.HasOne("Data.Entities.FileEntityModel", "File")
                        .WithOne("Descriptor")
                        .HasForeignKey("Data.Entities.FileDescriptorEntityModel", "FileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Entities.RegistrantEntityModel", b =>
                {
                    b.HasOne("Data.Entities.CountryEntityModel", "CountryRelation")
                        .WithMany()
                        .HasForeignKey("Country")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Entities.UserEntityModel", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Data.Entities.UserEntityModel", "EditedByUser")
                        .WithMany()
                        .HasForeignKey("EditedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Data.Entities.UserEntityModel", "User")
                        .WithOne("Registrant")
                        .HasForeignKey("Data.Entities.RegistrantEntityModel", "UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Data.Entities.TransactionEntityModel", b =>
                {
                    b.HasOne("Data.Entities.AccountEntityModel", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Entities.UserEntityModel", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Data.Entities.CurrencyEntityModel", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Data.Entities.UserEntityModel", "EditedByUser")
                        .WithMany()
                        .HasForeignKey("EditedById");

                    b.HasOne("Data.Entities.TransactionTypeEntityModel", "TransactionType")
                        .WithMany()
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Entities.UserEntityModel", b =>
                {
                    b.HasOne("Data.Entities.UserEntityModel", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Data.Entities.UserEntityModel", "EditedByUser")
                        .WithMany()
                        .HasForeignKey("EditedById")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Data.Entities.WalletEntityModel", b =>
                {
                    b.HasOne("Data.Entities.UserEntityModel", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Data.Entities.UserEntityModel", "EditedByUser")
                        .WithMany()
                        .HasForeignKey("EditedById");

                    b.HasOne("Data.Entities.RegistrantEntityModel", "Registrant")
                        .WithMany("Wallets")
                        .HasForeignKey("RegistrantId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Data.Entities.StatusEntityModel", "Status")
                        .WithMany()
                        .HasForeignKey("WalletStatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Data.Entities.RoleModel")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Data.Entities.UserEntityModel")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Data.Entities.UserEntityModel")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Data.Entities.RoleModel")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Entities.UserEntityModel")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Data.Entities.UserEntityModel")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
