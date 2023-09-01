using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BasicBudgetR.Server.Infrastructure.Data.Migrations
{
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "MonthBudgets",
                columns: table => new
                {
                    BudgetMonthId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "MonthBudgetHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                    MonthYearId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "MonthBudgetHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "MonthBudgetHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "MonthBudgetHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                    BusinessTransactionActivityId = table.Column<long>(type: "bigint", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "MonthBudgetHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthBudgets", x => x.BudgetMonthId);
                    table.ForeignKey(
                        name: "FK_MonthBudgets_BusinessTransactionActivities_BusinessTransactionActivityId",
                        column: x => x.BusinessTransactionActivityId,
                        principalTable: "BusinessTransactionActivities",
                        principalColumn: "BusinessTransactionActivityId");
                    table.ForeignKey(
                        name: "FK_MonthBudgets_MonthYears_MonthYearId",
                        column: x => x.MonthYearId,
                        principalTable: "MonthYears",
                        principalColumn: "MonthYearId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "MonthBudgetHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

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
                    Balance = table.Column<decimal>(type: "decimal(19,2)", precision: 19, scale: 2, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "AccountHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                    BalanceType = table.Column<int>(type: "int", nullable: false)
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
                    AuthId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "UserHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "AccountTypeId", "Name" },
                values: new object[,]
                {
                    { 1L, "Checking" },
                    { 2L, "Savings" },
                    { 3L, "Credit Card" },
                    { 4L, "Cash" },
                    { 5L, "Investment" },
                    { 6L, "Loan" },
                    { 7L, "Other" }
                });

            migrationBuilder.InsertData(
                table: "BusinessTransactionActivities",
                columns: new[] { "BusinessTransactionActivityId", "CreatedAt", "ProcessName", "UserId" },
                values: new object[] { 1L, new DateTime(2023, 8, 26, 0, 3, 21, 388, DateTimeKind.Utc).AddTicks(973), "Initial Seeding", 1L });

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
                columns: new[] { "UserId", "AuthId", "BtaId", "DisplayName", "HouseholdId" },
                values: new object[] { 1L, null, 1L, "System", null });

            migrationBuilder.InsertData(
                table: "MonthBudgets",
                columns: new[] { "BudgetMonthId", "BusinessTransactionActivityId", "MonthYearId" },
                values: new object[,]
                {
                    { 1L, null, 1L },
                    { 2L, null, 2L },
                    { 3L, null, 3L },
                    { 4L, null, 4L },
                    { 5L, null, 5L },
                    { 6L, null, 6L },
                    { 7L, null, 7L },
                    { 8L, null, 8L },
                    { 9L, null, 9L },
                    { 10L, null, 10L },
                    { 11L, null, 11L },
                    { 12L, null, 12L },
                    { 13L, null, 13L },
                    { 14L, null, 14L },
                    { 15L, null, 15L },
                    { 16L, null, 16L },
                    { 17L, null, 17L },
                    { 18L, null, 18L },
                    { 19L, null, 19L },
                    { 20L, null, 20L },
                    { 21L, null, 21L },
                    { 22L, null, 22L },
                    { 23L, null, 23L },
                    { 24L, null, 24L },
                    { 25L, null, 25L },
                    { 26L, null, 26L },
                    { 27L, null, 27L },
                    { 28L, null, 28L },
                    { 29L, null, 29L },
                    { 30L, null, 30L },
                    { 31L, null, 31L },
                    { 32L, null, 32L },
                    { 33L, null, 33L },
                    { 34L, null, 34L },
                    { 35L, null, 35L },
                    { 36L, null, 36L },
                    { 37L, null, 37L },
                    { 38L, null, 38L },
                    { 39L, null, 39L },
                    { 40L, null, 40L },
                    { 41L, null, 41L },
                    { 42L, null, 42L },
                    { 43L, null, 43L },
                    { 44L, null, 44L },
                    { 45L, null, 45L },
                    { 46L, null, 46L },
                    { 47L, null, 47L },
                    { 48L, null, 48L },
                    { 49L, null, 49L },
                    { 50L, null, 50L },
                    { 51L, null, 51L },
                    { 52L, null, 52L },
                    { 53L, null, 53L },
                    { 54L, null, 54L },
                    { 55L, null, 55L },
                    { 56L, null, 56L },
                    { 57L, null, 57L },
                    { 58L, null, 58L },
                    { 59L, null, 59L },
                    { 60L, null, 60L },
                    { 61L, null, 61L },
                    { 62L, null, 62L },
                    { 63L, null, 63L },
                    { 64L, null, 64L },
                    { 65L, null, 65L },
                    { 66L, null, 66L },
                    { 67L, null, 67L },
                    { 68L, null, 68L },
                    { 69L, null, 69L },
                    { 70L, null, 70L },
                    { 71L, null, 71L },
                    { 72L, null, 72L },
                    { 73L, null, 73L },
                    { 74L, null, 74L },
                    { 75L, null, 75L },
                    { 76L, null, 76L },
                    { 77L, null, 77L },
                    { 78L, null, 78L },
                    { 79L, null, 79L },
                    { 80L, null, 80L },
                    { 81L, null, 81L },
                    { 82L, null, 82L },
                    { 83L, null, 83L },
                    { 84L, null, 84L },
                    { 85L, null, 85L },
                    { 86L, null, 86L },
                    { 87L, null, 87L },
                    { 88L, null, 88L },
                    { 89L, null, 89L },
                    { 90L, null, 90L },
                    { 91L, null, 91L },
                    { 92L, null, 92L },
                    { 93L, null, 93L },
                    { 94L, null, 94L },
                    { 95L, null, 95L },
                    { 96L, null, 96L },
                    { 97L, null, 97L },
                    { 98L, null, 98L },
                    { 99L, null, 99L },
                    { 100L, null, 100L },
                    { 101L, null, 101L },
                    { 102L, null, 102L },
                    { 103L, null, 103L },
                    { 104L, null, 104L },
                    { 105L, null, 105L },
                    { 106L, null, 106L },
                    { 107L, null, 107L },
                    { 108L, null, 108L },
                    { 109L, null, 109L },
                    { 110L, null, 110L },
                    { 111L, null, 111L },
                    { 112L, null, 112L },
                    { 113L, null, 113L },
                    { 114L, null, 114L },
                    { 115L, null, 115L },
                    { 116L, null, 116L },
                    { 117L, null, 117L },
                    { 118L, null, 118L },
                    { 119L, null, 119L },
                    { 120L, null, 120L }
                });

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
                name: "IX_Households_BusinessTransactionActivityId",
                table: "Households",
                column: "BusinessTransactionActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthBudgets_BusinessTransactionActivityId",
                table: "MonthBudgets",
                column: "BusinessTransactionActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthBudgets_MonthYearId",
                table: "MonthBudgets",
                column: "MonthYearId");

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
                name: "MonthBudgets")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "MonthBudgetHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

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
                name: "MonthYears");

            migrationBuilder.DropTable(
                name: "Households")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "HouseholdHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

            migrationBuilder.DropTable(
                name: "BusinessTransactionActivities");
        }
    }
}
