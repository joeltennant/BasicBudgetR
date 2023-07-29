using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable


namespace BasicBudgetR.Server.Infrastructure.Data.Migrations.BudgetRDb;

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
            name: "UserDetails",
            columns: table => new
            {
                UserDetailId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1")
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "UserDetailHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "UserDetailHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "UserDetailHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt"),
                ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                    .Annotation("SqlServer:IsTemporal", true)
                    .Annotation("SqlServer:TemporalHistoryTableName", "UserDetailHistory")
                    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                    .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                    .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UserDetails", x => x.UserDetailId);
            })
            .Annotation("SqlServer:IsTemporal", true)
            .Annotation("SqlServer:TemporalHistoryTableName", "UserDetailHistory")
            .Annotation("SqlServer:TemporalHistoryTableSchema", null)
            .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
            .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

        migrationBuilder.CreateTable(
            name: "BusinessTransactionActivities",
            columns: table => new
            {
                BusinessTransactionActivityId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                ProcessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                UserDetailId = table.Column<long>(type: "bigint", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_BusinessTransactionActivities", x => x.BusinessTransactionActivityId);
                table.ForeignKey(
                    name: "FK_BusinessTransactionActivities_UserDetails_UserDetailId",
                    column: x => x.UserDetailId,
                    principalTable: "UserDetails",
                    principalColumn: "UserDetailId",
                    onDelete: ReferentialAction.Restrict);
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
                UserDetailId = table.Column<long>(type: "bigint", nullable: false)
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
                BusinessTransactionActivityId = table.Column<long>(type: "bigint", nullable: false)
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
                    principalColumn: "BusinessTransactionActivityId",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_Accounts_UserDetails_UserDetailId",
                    column: x => x.UserDetailId,
                    principalTable: "UserDetails",
                    principalColumn: "UserDetailId",
                    onDelete: ReferentialAction.Restrict);
            })
            .Annotation("SqlServer:IsTemporal", true)
            .Annotation("SqlServer:TemporalHistoryTableName", "AccountHistory")
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

        migrationBuilder.CreateIndex(
            name: "IX_Accounts_AccountTypeId",
            table: "Accounts",
            column: "AccountTypeId");

        migrationBuilder.CreateIndex(
            name: "IX_Accounts_BusinessTransactionActivityId",
            table: "Accounts",
            column: "BusinessTransactionActivityId");

        migrationBuilder.CreateIndex(
            name: "IX_Accounts_UserDetailId",
            table: "Accounts",
            column: "UserDetailId");

        migrationBuilder.CreateIndex(
            name: "IX_BusinessTransactionActivities_UserDetailId",
            table: "BusinessTransactionActivities",
            column: "UserDetailId");
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
            name: "AccountTypes");

        migrationBuilder.DropTable(
            name: "BusinessTransactionActivities");

        migrationBuilder.DropTable(
            name: "UserDetails")
            .Annotation("SqlServer:IsTemporal", true)
            .Annotation("SqlServer:TemporalHistoryTableName", "UserDetailHistory")
            .Annotation("SqlServer:TemporalHistoryTableSchema", null)
            .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
            .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");
    }
}
