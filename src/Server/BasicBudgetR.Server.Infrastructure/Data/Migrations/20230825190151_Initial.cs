using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable


namespace BasicBudgetR.Server.Infrastructure.Data.Migrations;

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
                { 3L, "Credit Card" },
                { 4L, "Cash" },
                { 5L, "Investment" },
                { 6L, "Loan" },
                { 7L, "Other" }
            });

        migrationBuilder.InsertData(
            table: "BusinessTransactionActivities",
            columns: new[] { "BusinessTransactionActivityId", "CreatedAt", "ProcessName", "UserId" },
            values: new object[] { 1L, new DateTime(2023, 8, 25, 19, 1, 51, 503, DateTimeKind.Utc).AddTicks(248), "Initial Seeding", 1L });

        migrationBuilder.InsertData(
            table: "Users",
            columns: new[] { "UserId", "AuthId", "BtaId", "DisplayName", "HouseholdId" },
            values: new object[] { 1L, null, 1L, "System", null });

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
            name: "Users")
            .Annotation("SqlServer:IsTemporal", true)
            .Annotation("SqlServer:TemporalHistoryTableName", "UserHistory")
            .Annotation("SqlServer:TemporalHistoryTableSchema", null)
            .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
            .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

        migrationBuilder.DropTable(
            name: "AccountTypes");

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
