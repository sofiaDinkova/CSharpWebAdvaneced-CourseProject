using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blasco.Data.Migrations
{
    public partial class SeedProductProjectCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductProjectCategories",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[,]
                {
                    { 1, null, "Animation" },
                    { 2, null, "Architectural plan" },
                    { 3, null, "Furniture" },
                    { 4, null, "Glass sculpture" },
                    { 5, null, "Graphic design" },
                    { 6, null, "Illustration" },
                    { 7, null, "Interior design" },
                    { 8, null, "Metal designs" },
                    { 9, null, "Painting" },
                    { 10, null, "Photograph" },
                    { 11, null, "Print" },
                    { 12, null, "Sculpture" },
                    { 13, null, "Tapestry" },
                    { 14, null, "Video" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductProjectCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductProjectCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductProjectCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductProjectCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductProjectCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductProjectCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductProjectCategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductProjectCategories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductProjectCategories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductProjectCategories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductProjectCategories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductProjectCategories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductProjectCategories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductProjectCategories",
                keyColumn: "Id",
                keyValue: 14);
        }
    }
}
