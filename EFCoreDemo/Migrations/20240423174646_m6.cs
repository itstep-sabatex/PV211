using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreDemo.Migrations
{
    /// <inheritdoc />
    public partial class m6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Waiters_Name",
                table: "Waiters");

            migrationBuilder.CreateIndex(
                name: "IX_Waiters_Name_Id",
                table: "Waiters",
                columns: new[] { "Name", "Id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Waiters_Name_Id",
                table: "Waiters");

            migrationBuilder.CreateIndex(
                name: "IX_Waiters_Name",
                table: "Waiters",
                column: "Name");
        }
    }
}
