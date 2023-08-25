using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasicBudgetR.Server.Infrastructure.Data.Migrations;

/// <inheritdoc />
public partial class FixAccountTypeSeed : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData(
            table: "AccountTypes",
            columns: new[] { "AccountTypeId", "Name" },
            values: new object[] { 2L, "Savings" });

        migrationBuilder.UpdateData(
            table: "BusinessTransactionActivities",
            keyColumn: "BusinessTransactionActivityId",
            keyValue: 1L,
            column: "CreatedAt",
            value: new DateTime(2023, 8, 25, 19, 6, 51, 95, DateTimeKind.Utc).AddTicks(9614));
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "AccountTypes",
            keyColumn: "AccountTypeId",
            keyValue: 2L);

        migrationBuilder.UpdateData(
            table: "BusinessTransactionActivities",
            keyColumn: "BusinessTransactionActivityId",
            keyValue: 1L,
            column: "CreatedAt",
            value: new DateTime(2023, 8, 25, 19, 1, 51, 503, DateTimeKind.Utc).AddTicks(248));
    }
}
