using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreDemo.Migrations
{
    /// <inheritdoc />
    public partial class m4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WaiterId",
                table: "UserRoles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_WaiterId",
                table: "UserRoles",
                column: "WaiterId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Waiters_WaiterId",
                table: "UserRoles",
                column: "WaiterId",
                principalTable: "Waiters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Waiters_WaiterId",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_WaiterId",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "WaiterId",
                table: "UserRoles");
        }
    }
}
