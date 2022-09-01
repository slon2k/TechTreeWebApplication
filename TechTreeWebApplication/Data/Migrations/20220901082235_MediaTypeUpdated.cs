using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechTreeWebApplication.Data.Migrations
{
    public partial class MediaTypeUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MediaType",
                columns: new[] { "Id", "Thumbnail", "Title" },
                values: new object[] { 1, "/images/ArticleImage.jpeg", "Article" });

            migrationBuilder.InsertData(
                table: "MediaType",
                columns: new[] { "Id", "Thumbnail", "Title" },
                values: new object[] { 2, "/images/VideoImage.jpeg", "Video" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MediaType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MediaType",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
