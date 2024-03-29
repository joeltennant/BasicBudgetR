﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable


namespace BudgetR.Server.Infrastructure.Data.BudgetR.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "AccountTypes",
            columns: table => new
            {
                AccountTypeId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                BalanceType = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AccountTypes", x => x.AccountTypeId);
            });

        migrationBuilder.CreateTable(
            name: "BusinessTransactionActivities",
            columns: table => new
            {
                BusinessTransactionActivityId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                ProcessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                UserId = table.Column<long>(type: "bigint", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_BusinessTransactionActivities", x => x.BusinessTransactionActivityId);
            });

        migrationBuilder.CreateTable(
            name: "MonthYears",
            columns: table => new
            {
                MonthYearId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Month = table.Column<int>(type: "int", nullable: false),
                Year = table.Column<int>(type: "int", nullable: false),
                IsActive = table.Column<bool>(type: "bit", nullable: false),
                NumberOfDays = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MonthYears", x => x.MonthYearId);
            });

        migrationBuilder.CreateTable(
            name: "TransactionCategories",
            columns: table => new
            {
                TransactionCategoryId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                HouseholdId = table.Column<long>(type: "bigint", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TransactionCategories", x => x.TransactionCategoryId);
            });

        migrationBuilder.CreateTable(
            name: "Households",
            columns: table => new
            {
                HouseholdId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1")
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "HouseholdHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "HouseholdHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "HouseholdHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "HouseholdHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                BusinessTransactionActivityId = table.Column<long>(type: "bigint", nullable: true)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "HouseholdHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Households", x => x.HouseholdId);
                table.ForeignKey(
                    name: "FK_Households_BusinessTransactionActivities_BusinessTransactionActivityId",
                    column: x => x.BusinessTransactionActivityId,
                    principalTable: "BusinessTransactionActivities",
                    principalColumn: "BusinessTransactionActivityId");
            })
            .Annotation("SqlServer:IsTemporal", true)
            .Annotation("SqlServer:TemporalHistoryTableName", "HouseholdHistory")
            .Annotation("SqlServer:TemporalHistoryTableSchema", null)
            .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
            .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

        migrationBuilder.CreateTable(
            name: "TransactionBatches",
            columns: table => new
            {
                TransactionBatchId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                StartedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                RecordCount = table.Column<int>(type: "int", nullable: true),
                Source = table.Column<int>(type: "int", nullable: true),
                BusinessTransactionActivityId = table.Column<long>(type: "bigint", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TransactionBatches", x => x.TransactionBatchId);
                table.ForeignKey(
                    name: "FK_TransactionBatches_BusinessTransactionActivities_BusinessTransactionActivityId",
                    column: x => x.BusinessTransactionActivityId,
                    principalTable: "BusinessTransactionActivities",
                    principalColumn: "BusinessTransactionActivityId");
            });

        migrationBuilder.CreateTable(
            name: "TransactionRules",
            columns: table => new
            {
                TransactionRuleId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                CategoryRuleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CategoryId = table.Column<long>(type: "bigint", nullable: true),
                HasCategory = table.Column<long>(type: "bigint", nullable: true),
                NumericRule = table.Column<long>(type: "bigint", nullable: true),
                StringRule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ComparisonType = table.Column<int>(type: "int", nullable: false),
                RuleLevel = table.Column<int>(type: "int", nullable: false),
                TransactionType = table.Column<int>(type: "int", nullable: true),
                TransactionCategoryId = table.Column<long>(type: "bigint", nullable: true),
                RuleType = table.Column<int>(type: "int", nullable: true),
                BusinessTransactionActivityId = table.Column<long>(type: "bigint", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TransactionRules", x => x.TransactionRuleId);
                table.ForeignKey(
                    name: "FK_TransactionRules_BusinessTransactionActivities_BusinessTransactionActivityId",
                    column: x => x.BusinessTransactionActivityId,
                    principalTable: "BusinessTransactionActivities",
                    principalColumn: "BusinessTransactionActivityId");
                table.ForeignKey(
                    name: "FK_TransactionRules_TransactionCategories_TransactionCategoryId",
                    column: x => x.TransactionCategoryId,
                    principalTable: "TransactionCategories",
                    principalColumn: "TransactionCategoryId");
            });

        migrationBuilder.CreateTable(
            name: "Accounts",
            columns: table => new
            {
                AccountId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1")
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "AccountHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                Name = table.Column<string>(type: "nvarchar(125)", maxLength: 125, nullable: true)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "AccountHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                LongName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "AccountHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                Balance = table.Column<decimal>(type: "decimal(19,2)", precision: 19, scale: 2, nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "AccountHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                AccountTypeId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "AccountHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                HouseholdId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "AccountHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "AccountHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "AccountHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                BusinessTransactionActivityId = table.Column<long>(type: "bigint", nullable: true)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "AccountHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Accounts", x => x.AccountId);
                table.CheckConstraint("CK_Account_Balance", "[Balance] >= 0");
                table.ForeignKey(
                    name: "FK_Accounts_AccountTypes_AccountTypeId",
                    column: x => x.AccountTypeId,
                    principalTable: "AccountTypes",
                    principalColumn: "AccountTypeId",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_Accounts_BusinessTransactionActivities_BusinessTransactionActivityId",
                    column: x => x.BusinessTransactionActivityId,
                    principalTable: "BusinessTransactionActivities",
                    principalColumn: "BusinessTransactionActivityId");
                table.ForeignKey(
                    name: "FK_Accounts_Households_HouseholdId",
                    column: x => x.HouseholdId,
                    principalTable: "Households",
                    principalColumn: "HouseholdId",
                    onDelete: ReferentialAction.Restrict);
            })
            .Annotation("SqlServer:IsTemporal", true)
            .Annotation("SqlServer:TemporalHistoryTableName", "AccountHistory")
            .Annotation("SqlServer:TemporalHistoryTableSchema", null)
            .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
            .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

        migrationBuilder.CreateTable(
            name: "BudgetMonths",
            columns: table => new
            {
                BudgetMonthId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1")
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "BudgetMonthHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                MonthYearId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "BudgetMonthHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                IncomeTotal = table.Column<decimal>(type: "decimal(19,2)", precision: 19, scale: 2, nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "BudgetMonthHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                ExpenseTotal = table.Column<decimal>(type: "decimal(19,2)", precision: 19, scale: 2, nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "BudgetMonthHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                HouseholdId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "BudgetMonthHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "BudgetMonthHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "BudgetMonthHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                BusinessTransactionActivityId = table.Column<long>(type: "bigint", nullable: true)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "BudgetMonthHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_BudgetMonths", x => x.BudgetMonthId);
                table.ForeignKey(
                    name: "FK_BudgetMonths_BusinessTransactionActivities_BusinessTransactionActivityId",
                    column: x => x.BusinessTransactionActivityId,
                    principalTable: "BusinessTransactionActivities",
                    principalColumn: "BusinessTransactionActivityId");
                table.ForeignKey(
                    name: "FK_BudgetMonths_Households_HouseholdId",
                    column: x => x.HouseholdId,
                    principalTable: "Households",
                    principalColumn: "HouseholdId",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_BudgetMonths_MonthYears_MonthYearId",
                    column: x => x.MonthYearId,
                    principalTable: "MonthYears",
                    principalColumn: "MonthYearId",
                    onDelete: ReferentialAction.Restrict);
            })
            .Annotation("SqlServer:IsTemporal", true)
            .Annotation("SqlServer:TemporalHistoryTableName", "BudgetMonthHistory")
            .Annotation("SqlServer:TemporalHistoryTableSchema", null)
            .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
            .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

        migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                UserId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1")
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "UserHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                AuthenticationId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "UserHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "UserHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "UserHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                HouseholdId = table.Column<long>(type: "bigint", nullable: true)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "UserHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                UserType = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "UserHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                IsActive = table.Column<bool>(type: "bit", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "UserHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                BtaId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "UserHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "UserHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "UserHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.UserId);
                table.ForeignKey(
                    name: "FK_Users_Households_HouseholdId",
                    column: x => x.HouseholdId,
                    principalTable: "Households",
                    principalColumn: "HouseholdId");
            })
            .Annotation("SqlServer:IsTemporal", true)
            .Annotation("SqlServer:TemporalHistoryTableName", "UserHistory")
            .Annotation("SqlServer:TemporalHistoryTableSchema", null)
            .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
            .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

        migrationBuilder.CreateTable(
            name: "ProcessedFiles",
            columns: table => new
            {
                ProcessedFileId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                RunOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                TransactionBatchId = table.Column<long>(type: "bigint", nullable: true),
                BusinessTransactionActivityId = table.Column<long>(type: "bigint", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ProcessedFiles", x => x.ProcessedFileId);
                table.ForeignKey(
                    name: "FK_ProcessedFiles_BusinessTransactionActivities_BusinessTransactionActivityId",
                    column: x => x.BusinessTransactionActivityId,
                    principalTable: "BusinessTransactionActivities",
                    principalColumn: "BusinessTransactionActivityId");
                table.ForeignKey(
                    name: "FK_ProcessedFiles_TransactionBatches_TransactionBatchId",
                    column: x => x.TransactionBatchId,
                    principalTable: "TransactionBatches",
                    principalColumn: "TransactionBatchId");
            });

        migrationBuilder.CreateTable(
            name: "Transactions",
            columns: table => new
            {
                TransactionId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                AccountId = table.Column<long>(type: "bigint", nullable: true),
                TransactionType = table.Column<int>(type: "int", nullable: true),
                Amount = table.Column<decimal>(type: "decimal(19,2)", precision: 19, scale: 2, nullable: false),
                TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                TransactionMonth = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                TransactionYear = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                TransactionCategoryId = table.Column<long>(type: "bigint", nullable: true),
                TransactionBatchId = table.Column<long>(type: "bigint", nullable: true),
                HouseholdId = table.Column<long>(type: "bigint", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                table.ForeignKey(
                    name: "FK_Transactions_Households_HouseholdId",
                    column: x => x.HouseholdId,
                    principalTable: "Households",
                    principalColumn: "HouseholdId");
                table.ForeignKey(
                    name: "FK_Transactions_TransactionBatches_TransactionBatchId",
                    column: x => x.TransactionBatchId,
                    principalTable: "TransactionBatches",
                    principalColumn: "TransactionBatchId");
                table.ForeignKey(
                    name: "FK_Transactions_TransactionCategories_TransactionCategoryId",
                    column: x => x.TransactionCategoryId,
                    principalTable: "TransactionCategories",
                    principalColumn: "TransactionCategoryId");
            });

        migrationBuilder.CreateTable(
            name: "Expenses",
            columns: table => new
            {
                ExpenseId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1")
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "ExpenseHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                Name = table.Column<string>(type: "nvarchar(125)", maxLength: 125, nullable: true)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "ExpenseHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                Amount = table.Column<decimal>(type: "decimal(19,2)", precision: 19, scale: 2, nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "ExpenseHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                IsActive = table.Column<bool>(type: "bit", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "ExpenseHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                HouseholdId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "ExpenseHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                BudgetMonthId = table.Column<long>(type: "bigint", nullable: true)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "ExpenseHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "ExpenseHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "ExpenseHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                BusinessTransactionActivityId = table.Column<long>(type: "bigint", nullable: true)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "ExpenseHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Expenses", x => x.ExpenseId);
                table.ForeignKey(
                    name: "FK_Expenses_BudgetMonths_BudgetMonthId",
                    column: x => x.BudgetMonthId,
                    principalTable: "BudgetMonths",
                    principalColumn: "BudgetMonthId");
                table.ForeignKey(
                    name: "FK_Expenses_BusinessTransactionActivities_BusinessTransactionActivityId",
                    column: x => x.BusinessTransactionActivityId,
                    principalTable: "BusinessTransactionActivities",
                    principalColumn: "BusinessTransactionActivityId");
            })
            .Annotation("SqlServer:IsTemporal", true)
            .Annotation("SqlServer:TemporalHistoryTableName", "ExpenseHistory")
            .Annotation("SqlServer:TemporalHistoryTableSchema", null)
            .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
            .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

        migrationBuilder.CreateTable(
            name: "Incomes",
            columns: table => new
            {
                IncomeId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1")
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "IncomeHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                HouseholdId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "IncomeHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "IncomeHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                Amount = table.Column<decimal>(type: "decimal(19,2)", precision: 19, scale: 2, nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "IncomeHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                IsActive = table.Column<bool>(type: "bit", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "IncomeHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                BudgetMonthId = table.Column<long>(type: "bigint", nullable: true)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "IncomeHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "IncomeHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "IncomeHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                BusinessTransactionActivityId = table.Column<long>(type: "bigint", nullable: true)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "IncomeHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Incomes", x => x.IncomeId);
                table.ForeignKey(
                    name: "FK_Incomes_BudgetMonths_BudgetMonthId",
                    column: x => x.BudgetMonthId,
                    principalTable: "BudgetMonths",
                    principalColumn: "BudgetMonthId");
                table.ForeignKey(
                    name: "FK_Incomes_BusinessTransactionActivities_BusinessTransactionActivityId",
                    column: x => x.BusinessTransactionActivityId,
                    principalTable: "BusinessTransactionActivities",
                    principalColumn: "BusinessTransactionActivityId");
            })
            .Annotation("SqlServer:IsTemporal", true)
            .Annotation("SqlServer:TemporalHistoryTableName", "IncomeHistory")
            .Annotation("SqlServer:TemporalHistoryTableSchema", null)
            .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
            .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

        migrationBuilder.CreateTable(
            name: "ExpenseDetails",
            columns: table => new
            {
                ExpenseDetailId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1")
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "ExpenseDetailHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                ExpenseId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "ExpenseDetailHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                BudgetMonthId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "ExpenseDetailHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                IsActive = table.Column<bool>(type: "bit", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "ExpenseDetailHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "ExpenseDetailHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "ExpenseDetailHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                BusinessTransactionActivityId = table.Column<long>(type: "bigint", nullable: true)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "ExpenseDetailHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ExpenseDetails", x => x.ExpenseDetailId);
                table.ForeignKey(
                    name: "FK_ExpenseDetails_BudgetMonths_BudgetMonthId",
                    column: x => x.BudgetMonthId,
                    principalTable: "BudgetMonths",
                    principalColumn: "BudgetMonthId",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_ExpenseDetails_BusinessTransactionActivities_BusinessTransactionActivityId",
                    column: x => x.BusinessTransactionActivityId,
                    principalTable: "BusinessTransactionActivities",
                    principalColumn: "BusinessTransactionActivityId");
                table.ForeignKey(
                    name: "FK_ExpenseDetails_Expenses_ExpenseId",
                    column: x => x.ExpenseId,
                    principalTable: "Expenses",
                    principalColumn: "ExpenseId",
                    onDelete: ReferentialAction.Restrict);
            })
            .Annotation("SqlServer:IsTemporal", true)
            .Annotation("SqlServer:TemporalHistoryTableName", "ExpenseDetailHistory")
            .Annotation("SqlServer:TemporalHistoryTableSchema", null)
            .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
            .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

        migrationBuilder.CreateTable(
            name: "IncomeDetails",
            columns: table => new
            {
                IncomeDetailId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1")
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "IncomeDetailHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                IncomeId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "IncomeDetailHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                BudgetMonthId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "IncomeDetailHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                IsActive = table.Column<bool>(type: "bit", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "IncomeDetailHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "IncomeDetailHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "IncomeDetailHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                BusinessTransactionActivityId = table.Column<long>(type: "bigint", nullable: true)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "IncomeDetailHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_IncomeDetails", x => x.IncomeDetailId);
                table.ForeignKey(
                    name: "FK_IncomeDetails_BudgetMonths_BudgetMonthId",
                    column: x => x.BudgetMonthId,
                    principalTable: "BudgetMonths",
                    principalColumn: "BudgetMonthId",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_IncomeDetails_BusinessTransactionActivities_BusinessTransactionActivityId",
                    column: x => x.BusinessTransactionActivityId,
                    principalTable: "BusinessTransactionActivities",
                    principalColumn: "BusinessTransactionActivityId");
                table.ForeignKey(
                    name: "FK_IncomeDetails_Incomes_IncomeId",
                    column: x => x.IncomeId,
                    principalTable: "Incomes",
                    principalColumn: "IncomeId",
                    onDelete: ReferentialAction.Restrict);
            })
            .Annotation("SqlServer:IsTemporal", true)
            .Annotation("SqlServer:TemporalHistoryTableName", "IncomeDetailHistory")
            .Annotation("SqlServer:TemporalHistoryTableSchema", null)
            .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
            .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

        migrationBuilder.InsertData(
            table: "AccountTypes",
            columns: new[] { "AccountTypeId", "BalanceType", "Name" },
            values: new object[,]
            {
                { 1L, 0, "Checking" },
                { 2L, 0, "Savings" },
                { 3L, 1, "Credit Card" },
                { 4L, 0, "Cash" },
                { 5L, 0, "Investment" },
                { 6L, 1, "Loan" },
                { 7L, 0, "Other" },
                { 8L, 0, "Retirement" }
            });

        migrationBuilder.InsertData(
            table: "BusinessTransactionActivities",
            columns: new[] { "BusinessTransactionActivityId", "CreatedAt", "ProcessName", "UserId" },
            values: new object[] { 1L, new DateTime(2024, 1, 8, 1, 53, 27, 171, DateTimeKind.Utc).AddTicks(665), "Initial Seeding", 1L });

        migrationBuilder.InsertData(
            table: "MonthYears",
            columns: new[] { "MonthYearId", "IsActive", "Month", "NumberOfDays", "Year" },
            values: new object[,]
            {
                { 1L, true, 1, 31, 2023 },
                { 2L, true, 2, 28, 2023 },
                { 3L, true, 3, 31, 2023 },
                { 4L, true, 4, 30, 2023 },
                { 5L, true, 5, 31, 2023 },
                { 6L, true, 6, 30, 2023 },
                { 7L, true, 7, 31, 2023 },
                { 8L, true, 8, 31, 2023 },
                { 9L, true, 9, 30, 2023 },
                { 10L, true, 10, 31, 2023 },
                { 11L, true, 11, 30, 2023 },
                { 12L, true, 12, 31, 2023 },
                { 13L, true, 1, 31, 2024 },
                { 14L, true, 2, 29, 2024 },
                { 15L, true, 3, 31, 2024 },
                { 16L, true, 4, 30, 2024 },
                { 17L, true, 5, 31, 2024 },
                { 18L, true, 6, 30, 2024 },
                { 19L, true, 7, 31, 2024 },
                { 20L, true, 8, 31, 2024 },
                { 21L, true, 9, 30, 2024 },
                { 22L, true, 10, 31, 2024 },
                { 23L, true, 11, 30, 2024 },
                { 24L, true, 12, 31, 2024 },
                { 25L, true, 1, 31, 2025 },
                { 26L, true, 2, 28, 2025 },
                { 27L, true, 3, 31, 2025 },
                { 28L, true, 4, 30, 2025 },
                { 29L, true, 5, 31, 2025 },
                { 30L, true, 6, 30, 2025 },
                { 31L, true, 7, 31, 2025 },
                { 32L, true, 8, 31, 2025 },
                { 33L, true, 9, 30, 2025 },
                { 34L, true, 10, 31, 2025 },
                { 35L, true, 11, 30, 2025 },
                { 36L, true, 12, 31, 2025 },
                { 37L, true, 1, 31, 2026 },
                { 38L, true, 2, 28, 2026 },
                { 39L, true, 3, 31, 2026 },
                { 40L, true, 4, 30, 2026 },
                { 41L, true, 5, 31, 2026 },
                { 42L, true, 6, 30, 2026 },
                { 43L, true, 7, 31, 2026 },
                { 44L, true, 8, 31, 2026 },
                { 45L, true, 9, 30, 2026 },
                { 46L, true, 10, 31, 2026 },
                { 47L, true, 11, 30, 2026 },
                { 48L, true, 12, 31, 2026 },
                { 49L, true, 1, 31, 2027 },
                { 50L, true, 2, 28, 2027 },
                { 51L, true, 3, 31, 2027 },
                { 52L, true, 4, 30, 2027 },
                { 53L, true, 5, 31, 2027 },
                { 54L, true, 6, 30, 2027 },
                { 55L, true, 7, 31, 2027 },
                { 56L, true, 8, 31, 2027 },
                { 57L, true, 9, 30, 2027 },
                { 58L, true, 10, 31, 2027 },
                { 59L, true, 11, 30, 2027 },
                { 60L, true, 12, 31, 2027 },
                { 61L, true, 1, 31, 2028 },
                { 62L, true, 2, 29, 2028 },
                { 63L, true, 3, 31, 2028 },
                { 64L, true, 4, 30, 2028 },
                { 65L, true, 5, 31, 2028 },
                { 66L, true, 6, 30, 2028 },
                { 67L, true, 7, 31, 2028 },
                { 68L, true, 8, 31, 2028 },
                { 69L, true, 9, 30, 2028 },
                { 70L, true, 10, 31, 2028 },
                { 71L, true, 11, 30, 2028 },
                { 72L, true, 12, 31, 2028 },
                { 73L, true, 1, 31, 2029 },
                { 74L, true, 2, 28, 2029 },
                { 75L, true, 3, 31, 2029 },
                { 76L, true, 4, 30, 2029 },
                { 77L, true, 5, 31, 2029 },
                { 78L, true, 6, 30, 2029 },
                { 79L, true, 7, 31, 2029 },
                { 80L, true, 8, 31, 2029 },
                { 81L, true, 9, 30, 2029 },
                { 82L, true, 10, 31, 2029 },
                { 83L, true, 11, 30, 2029 },
                { 84L, true, 12, 31, 2029 },
                { 85L, true, 1, 31, 2030 },
                { 86L, true, 2, 28, 2030 },
                { 87L, true, 3, 31, 2030 },
                { 88L, true, 4, 30, 2030 },
                { 89L, true, 5, 31, 2030 },
                { 90L, true, 6, 30, 2030 },
                { 91L, true, 7, 31, 2030 },
                { 92L, true, 8, 31, 2030 },
                { 93L, true, 9, 30, 2030 },
                { 94L, true, 10, 31, 2030 },
                { 95L, true, 11, 30, 2030 },
                { 96L, true, 12, 31, 2030 },
                { 97L, true, 1, 31, 2031 },
                { 98L, true, 2, 28, 2031 },
                { 99L, true, 3, 31, 2031 },
                { 100L, true, 4, 30, 2031 },
                { 101L, true, 5, 31, 2031 },
                { 102L, true, 6, 30, 2031 },
                { 103L, true, 7, 31, 2031 },
                { 104L, true, 8, 31, 2031 },
                { 105L, true, 9, 30, 2031 },
                { 106L, true, 10, 31, 2031 },
                { 107L, true, 11, 30, 2031 },
                { 108L, true, 12, 31, 2031 },
                { 109L, true, 1, 31, 2032 },
                { 110L, true, 2, 29, 2032 },
                { 111L, true, 3, 31, 2032 },
                { 112L, true, 4, 30, 2032 },
                { 113L, true, 5, 31, 2032 },
                { 114L, true, 6, 30, 2032 },
                { 115L, true, 7, 31, 2032 },
                { 116L, true, 8, 31, 2032 },
                { 117L, true, 9, 30, 2032 },
                { 118L, true, 10, 31, 2032 },
                { 119L, true, 11, 30, 2032 },
                { 120L, true, 12, 31, 2032 }
            });

        migrationBuilder.InsertData(
            table: "Users",
            columns: new[] { "UserId", "AuthenticationId", "BtaId", "FirstName", "HouseholdId", "IsActive", "LastName", "UserType" },
            values: new object[] { 1L, "", 1L, "System", null, false, null, 0 });

        migrationBuilder.CreateIndex(
            name: "IX_Accounts_AccountTypeId",
            table: "Accounts",
            column: "AccountTypeId");

        migrationBuilder.CreateIndex(
            name: "IX_Accounts_BusinessTransactionActivityId",
            table: "Accounts",
            column: "BusinessTransactionActivityId");

        migrationBuilder.CreateIndex(
            name: "IX_Accounts_HouseholdId",
            table: "Accounts",
            column: "HouseholdId");

        migrationBuilder.CreateIndex(
            name: "IX_BudgetMonths_BusinessTransactionActivityId",
            table: "BudgetMonths",
            column: "BusinessTransactionActivityId");

        migrationBuilder.CreateIndex(
            name: "IX_BudgetMonths_HouseholdId",
            table: "BudgetMonths",
            column: "HouseholdId");

        migrationBuilder.CreateIndex(
            name: "IX_BudgetMonths_MonthYearId",
            table: "BudgetMonths",
            column: "MonthYearId");

        migrationBuilder.CreateIndex(
            name: "IX_ExpenseDetails_BudgetMonthId",
            table: "ExpenseDetails",
            column: "BudgetMonthId");

        migrationBuilder.CreateIndex(
            name: "IX_ExpenseDetails_BusinessTransactionActivityId",
            table: "ExpenseDetails",
            column: "BusinessTransactionActivityId");

        migrationBuilder.CreateIndex(
            name: "IX_ExpenseDetails_ExpenseId",
            table: "ExpenseDetails",
            column: "ExpenseId");

        migrationBuilder.CreateIndex(
            name: "IX_Expenses_BudgetMonthId",
            table: "Expenses",
            column: "BudgetMonthId");

        migrationBuilder.CreateIndex(
            name: "IX_Expenses_BusinessTransactionActivityId",
            table: "Expenses",
            column: "BusinessTransactionActivityId");

        migrationBuilder.CreateIndex(
            name: "IX_Households_BusinessTransactionActivityId",
            table: "Households",
            column: "BusinessTransactionActivityId");

        migrationBuilder.CreateIndex(
            name: "IX_IncomeDetails_BudgetMonthId",
            table: "IncomeDetails",
            column: "BudgetMonthId");

        migrationBuilder.CreateIndex(
            name: "IX_IncomeDetails_BusinessTransactionActivityId",
            table: "IncomeDetails",
            column: "BusinessTransactionActivityId");

        migrationBuilder.CreateIndex(
            name: "IX_IncomeDetails_IncomeId",
            table: "IncomeDetails",
            column: "IncomeId");

        migrationBuilder.CreateIndex(
            name: "IX_Incomes_BudgetMonthId",
            table: "Incomes",
            column: "BudgetMonthId");

        migrationBuilder.CreateIndex(
            name: "IX_Incomes_BusinessTransactionActivityId",
            table: "Incomes",
            column: "BusinessTransactionActivityId");

        migrationBuilder.CreateIndex(
            name: "IX_ProcessedFiles_BusinessTransactionActivityId",
            table: "ProcessedFiles",
            column: "BusinessTransactionActivityId");

        migrationBuilder.CreateIndex(
            name: "IX_ProcessedFiles_TransactionBatchId",
            table: "ProcessedFiles",
            column: "TransactionBatchId");

        migrationBuilder.CreateIndex(
            name: "IX_TransactionBatches_BusinessTransactionActivityId",
            table: "TransactionBatches",
            column: "BusinessTransactionActivityId");

        migrationBuilder.CreateIndex(
            name: "IX_TransactionRules_BusinessTransactionActivityId",
            table: "TransactionRules",
            column: "BusinessTransactionActivityId");

        migrationBuilder.CreateIndex(
            name: "IX_TransactionRules_TransactionCategoryId",
            table: "TransactionRules",
            column: "TransactionCategoryId");

        migrationBuilder.CreateIndex(
            name: "IX_Transactions_HouseholdId",
            table: "Transactions",
            column: "HouseholdId");

        migrationBuilder.CreateIndex(
            name: "IX_Transactions_TransactionBatchId",
            table: "Transactions",
            column: "TransactionBatchId");

        migrationBuilder.CreateIndex(
            name: "IX_Transactions_TransactionCategoryId",
            table: "Transactions",
            column: "TransactionCategoryId");

        migrationBuilder.CreateIndex(
            name: "IX_Transactions_TransactionMonth_TransactionYear",
            table: "Transactions",
            columns: new[] { "TransactionMonth", "TransactionYear" });

        migrationBuilder.CreateIndex(
            name: "IX_Users_HouseholdId",
            table: "Users",
            column: "HouseholdId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Accounts")
            .Annotation("SqlServer:IsTemporal", true)
            .Annotation("SqlServer:TemporalHistoryTableName", "AccountHistory")
            .Annotation("SqlServer:TemporalHistoryTableSchema", null)
            .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
            .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

        migrationBuilder.DropTable(
            name: "ExpenseDetails")
            .Annotation("SqlServer:IsTemporal", true)
            .Annotation("SqlServer:TemporalHistoryTableName", "ExpenseDetailHistory")
            .Annotation("SqlServer:TemporalHistoryTableSchema", null)
            .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
            .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

        migrationBuilder.DropTable(
            name: "IncomeDetails")
            .Annotation("SqlServer:IsTemporal", true)
            .Annotation("SqlServer:TemporalHistoryTableName", "IncomeDetailHistory")
            .Annotation("SqlServer:TemporalHistoryTableSchema", null)
            .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
            .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

        migrationBuilder.DropTable(
            name: "ProcessedFiles");

        migrationBuilder.DropTable(
            name: "TransactionRules");

        migrationBuilder.DropTable(
            name: "Transactions");

        migrationBuilder.DropTable(
            name: "Users")
            .Annotation("SqlServer:IsTemporal", true)
            .Annotation("SqlServer:TemporalHistoryTableName", "UserHistory")
            .Annotation("SqlServer:TemporalHistoryTableSchema", null)
            .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
            .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

        migrationBuilder.DropTable(
            name: "AccountTypes");

        migrationBuilder.DropTable(
            name: "Expenses")
            .Annotation("SqlServer:IsTemporal", true)
            .Annotation("SqlServer:TemporalHistoryTableName", "ExpenseHistory")
            .Annotation("SqlServer:TemporalHistoryTableSchema", null)
            .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
            .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

        migrationBuilder.DropTable(
            name: "Incomes")
            .Annotation("SqlServer:IsTemporal", true)
            .Annotation("SqlServer:TemporalHistoryTableName", "IncomeHistory")
            .Annotation("SqlServer:TemporalHistoryTableSchema", null)
            .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
            .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

        migrationBuilder.DropTable(
            name: "TransactionBatches");

        migrationBuilder.DropTable(
            name: "TransactionCategories");

        migrationBuilder.DropTable(
            name: "BudgetMonths")
            .Annotation("SqlServer:IsTemporal", true)
            .Annotation("SqlServer:TemporalHistoryTableName", "BudgetMonthHistory")
            .Annotation("SqlServer:TemporalHistoryTableSchema", null)
            .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
            .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

        migrationBuilder.DropTable(
            name: "Households")
            .Annotation("SqlServer:IsTemporal", true)
            .Annotation("SqlServer:TemporalHistoryTableName", "HouseholdHistory")
            .Annotation("SqlServer:TemporalHistoryTableSchema", null)
            .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
            .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

        migrationBuilder.DropTable(
            name: "MonthYears");

        migrationBuilder.DropTable(
            name: "BusinessTransactionActivities");
    }
}
