using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasicBudgetR.Server.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIncomes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "Incomes")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "IncomeHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

            migrationBuilder.AlterColumn<long>(
                name: "BusinessTransactionActivityId",
                table: "Incomes",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "IncomeHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

            migrationBuilder.AlterColumn<long>(
                name: "BudgetMonthId",
                table: "Incomes",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "IncomeHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

            migrationBuilder.AlterColumn<long>(
                name: "IncomeId",
                table: "Incomes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "IncomeHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Incomes",
                type: "decimal(19,2)",
                precision: 19,
                scale: 2,
                nullable: false,
                defaultValue: 0m)
                .Annotation("Relational:ColumnOrder", 3)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "IncomeHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Incomes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "IncomeHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

            migrationBuilder.AddColumn<long>(
                name: "HouseholdId",
                table: "Incomes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Relational:ColumnOrder", 1)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "IncomeHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Incomes",
                type: "bit",
                nullable: false,
                defaultValue: false)
                .Annotation("Relational:ColumnOrder", 4)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "IncomeHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Incomes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "IncomeHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Incomes",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 2)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "IncomeHistory")
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

            migrationBuilder.UpdateData(
                table: "BusinessTransactionActivities",
                keyColumn: "BusinessTransactionActivityId",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 11, 23, 16, 3, 788, DateTimeKind.Utc).AddTicks(5005));

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncomeDetails")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "IncomeDetailHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Incomes")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "IncomeHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Incomes")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "IncomeHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

            migrationBuilder.DropColumn(
                name: "HouseholdId",
                table: "Incomes")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "IncomeHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Incomes")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "IncomeHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Incomes")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "IncomeHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Incomes")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "IncomeHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

            migrationBuilder.AlterTable(
                name: "Incomes")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "IncomeHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

            migrationBuilder.AlterColumn<long>(
                name: "BusinessTransactionActivityId",
                table: "Incomes",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "IncomeHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

            migrationBuilder.AlterColumn<long>(
                name: "BudgetMonthId",
                table: "Incomes",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "IncomeHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

            migrationBuilder.AlterColumn<long>(
                name: "IncomeId",
                table: "Incomes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "IncomeHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "ModifiedAt")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "CreatedAt");

            migrationBuilder.UpdateData(
                table: "BusinessTransactionActivities",
                keyColumn: "BusinessTransactionActivityId",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 2, 1, 34, 52, 482, DateTimeKind.Utc).AddTicks(8204));
        }
    }
}
