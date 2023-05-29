using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasicBudgetR.Server.Infrastructure.Data.Migrations;

/// <inheritdoc />
public partial class AddUserDetail : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "UserDetails",
            columns: table => new
            {
                UserDetailId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UserDetails", x => x.UserDetailId);
                table.ForeignKey(
                    name: "FK_UserDetails_AspNetUsers_UserId",
                    column: x => x.UserId,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_UserDetails_UserId",
            table: "UserDetails",
            column: "UserId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "UserDetails");
    }
}
