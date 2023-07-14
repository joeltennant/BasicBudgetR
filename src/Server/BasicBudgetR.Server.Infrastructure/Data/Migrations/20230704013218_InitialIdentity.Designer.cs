﻿// <auto-generated />
using System;
using BasicBudgetR.Server.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BasicBudgetR.Server.Infrastructure.Data.Migrations
{
    [DbContext(typeof(BudgetRDbContext))]
    [Migration("20230704013218_InitialIdentity")]
    partial class InitialIdentity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.5.23280.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BasicBudgetR.Server.Domain.Entities.Account", b =>
                {
                    b.Property<long>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("AccountId"));

                    b.Property<int>("AccountType")
                        .HasColumnType("int")
                        .HasColumnOrder(4);

                    b.Property<decimal>("Balance")
                        .HasPrecision(19, 2)
                        .HasColumnType("decimal(19,2)")
                        .HasColumnOrder(2);

                    b.Property<int>("BalanceType")
                        .HasColumnType("int")
                        .HasColumnOrder(3);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<DateTime>("ModifiedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ModifiedAt");

                    b.Property<long>("ModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasMaxLength(125)
                        .HasColumnType("nvarchar(125)")
                        .HasColumnOrder(1);

                    b.Property<long>("UserDetailId")
                        .HasColumnType("bigint");

                    b.HasKey("AccountId");

                    b.HasIndex("UserDetailId");

                    b.ToTable("Accounts", null, t =>
                        {
                            t.HasCheckConstraint("CK_Account_Balance", "[Balance] >= 0");
                        });

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("AccountHistory");
                                ttb
                                    .HasPeriodStart("CreatedAt")
                                    .HasColumnName("CreatedAt");
                                ttb
                                    .HasPeriodEnd("ModifiedAt")
                                    .HasColumnName("ModifiedAt");
                            }));
                });

            modelBuilder.Entity("BasicBudgetR.Server.Domain.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("BasicBudgetR.Server.Domain.Entities.UserDetail", b =>
                {
                    b.Property<long>("UserDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("UserDetailId"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<DateTime>("ModifiedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ModifiedAt");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(1);

                    b.HasKey("UserDetailId");

                    b.HasIndex("UserId");

                    b.ToTable("UserDetails", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("UserDetailHistory");
                                ttb
                                    .HasPeriodStart("CreatedAt")
                                    .HasColumnName("CreatedAt");
                                ttb
                                    .HasPeriodEnd("ModifiedAt")
                                    .HasColumnName("ModifiedAt");
                            }));
                });

            modelBuilder.Entity("BasicBudgetR.Server.Domain.Entities.Account", b =>
                {
                    b.HasOne("BasicBudgetR.Server.Domain.Entities.UserDetail", "UserDetail")
                        .WithMany()
                        .HasForeignKey("UserDetailId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("UserDetail");
                });

            modelBuilder.Entity("BasicBudgetR.Server.Domain.Entities.UserDetail", b =>
                {
                    b.HasOne("BasicBudgetR.Server.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
