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
                values: new object[] { "990fe066-fb1e-404b-8c4c-24a51c79873a", "e781339a-7d04-45ba-b178-8c75dd8ebe91", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a8af697d-6ff3-4f16-bcbe-cf7b62ae6a43", "ecace1ed-f19b-42be-ae68-561c1f68d17b", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "990fe066-fb1e-404b-8c4c-24a51c79873a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8af697d-6ff3-4f16-bcbe-cf7b62ae6a43");
        }
    }
}
