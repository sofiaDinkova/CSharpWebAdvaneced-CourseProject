using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blasco.Data.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 25, 12, 7, 1, 213, DateTimeKind.Utc).AddTicks(7848),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 24, 11, 28, 41, 477, DateTimeKind.Utc).AddTicks(3273));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 25, 12, 7, 1, 212, DateTimeKind.Utc).AddTicks(9782),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 24, 11, 28, 41, 476, DateTimeKind.Utc).AddTicks(8871));

            migrationBuilder.InsertData(
                table: "ProductProjectCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Animation" },
                    { 2, "Architectural plan" },
                    { 3, "Furniture" },
                    { 4, "Glass sculpture" },
                    { 5, "Graphic design" },
                    { 6, "Illustration" },
                    { 7, "Interior design" },
                    { 8, "Metal designs" },
                    { 9, "Painting" },
                    { 10, "Photograph" },
                    { 11, "Print" },
                    { 12, "Sculpture" },
                    { 13, "Tapestry" },
                    { 14, "Video" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "City", "CreatorId", "CustomerId", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("2e533a0d-271c-442e-9257-16311d122026"), 10, "Buenos Aires", new Guid("345de848-8e19-41a4-944d-36c1b4d24b78"), null, "A group of bees compete for the only female in the group. Climate change, pesticides and ever-dwindling habitat make it difficult for bees around the world to maintain their species.", "https://image.geo.de/32808766/t/vQ/v5/w1440/r1.5/-/--karine-aigner--1---wildlife-photographer-of-the-year.jpg", 15m, "Bees" },
                    { new Guid("8b2e0273-6356-43cd-8eb9-4923dc5f7cc7"), 12, "London", new Guid("345de848-8e19-41a4-944d-36c1b4d24b78"), new Guid("c99c215f-1621-4874-99b4-14fd0c1eaabe"), "Taking her art from life and nature, Helena breaks down forms simplifying and playing with the uses of light and shadows. Sometimes staying true to a likeness, which is always the starting point, but sometimes her work will take on a much more abstract nature. Often she uses her experience as a graphic designer to create works with a digital starting point using flat plains that are then assembled into a 3d structure.", "https://artpark.com.au/wp-content/uploads/2022/12/Tosca-60x52x15cm-600x600.jpg", 17m, "Horse" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CategoryId", "CreatorId", "Description", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { new Guid("af4b27d8-e225-4104-9a23-e4d8292e6091"), 2, new Guid("345de848-8e19-41a4-944d-36c1b4d24b78"), "Fallingwater is a house designed by the architect Frank Lloyd Wright in 1935 in the Laurel Highlands of southwest Pennsylvania, about 70 miles (110 km) southeast of Pittsburgh in the United States. It is built partly over a waterfall on Bear Run in the Mill Run section of Stewart Township, Fayette County, Pennsylvania.", "https://en.wikipedia.org/wiki/Fallingwater#/media/File:Fallingwater3.jpg", "Fallingwater" },
                    { new Guid("b3364445-34a8-4e7a-9866-e745c62ff0ff"), 2, new Guid("345de848-8e19-41a4-944d-36c1b4d24b78"), "Sarpaneva made his and Finland's largest glass sculpture, Ahtojää (\"Pack Ice,\" renamed from Jäävuori, \"Iceberg\"), for the Finnish pavilion at Expo 67 in Montreal in 1967.", "https://upload.wikimedia.org/wikipedia/commons/3/34/The_Year_Zero_1985_Sarpaneva.jpg", "The Year Zero" }
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
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductProjectCategories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductProjectCategories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2e533a0d-271c-442e-9257-16311d122026"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8b2e0273-6356-43cd-8eb9-4923dc5f7cc7"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("af4b27d8-e225-4104-9a23-e4d8292e6091"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("b3364445-34a8-4e7a-9866-e745c62ff0ff"));

            migrationBuilder.DeleteData(
                table: "ProductProjectCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductProjectCategories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductProjectCategories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 24, 11, 28, 41, 477, DateTimeKind.Utc).AddTicks(3273),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 25, 12, 7, 1, 213, DateTimeKind.Utc).AddTicks(7848));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 24, 11, 28, 41, 476, DateTimeKind.Utc).AddTicks(8871),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 25, 12, 7, 1, 212, DateTimeKind.Utc).AddTicks(9782));
        }
    }
}
