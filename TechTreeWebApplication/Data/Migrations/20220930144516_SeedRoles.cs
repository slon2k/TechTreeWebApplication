using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechTreeWebApplication.Data.Migrations
{
    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cd9add9a-4e57-4f22-8db3-d9e0676e3217", "f2f87db4-8608-4d28-a4a7-fe78549ed484", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "df48d5e8-8cd6-4f9e-8be0-657e042a850d", "26cb5bd2-d9b6-4e11-886a-56ccd28d2983", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd9add9a-4e57-4f22-8db3-d9e0676e3217");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df48d5e8-8cd6-4f9e-8be0-657e042a850d");
        }
    }
}
