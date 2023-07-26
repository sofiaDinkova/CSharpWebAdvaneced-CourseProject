using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blasco.Data.Migrations
{
    public partial class FixedCreatedOn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 25, 12, 7, 1, 213, DateTimeKind.Utc).AddTicks(7848));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 25, 12, 7, 1, 212, DateTimeKind.Utc).AddTicks(9782));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "City", "CreatorId", "CustomerId", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("72cde238-82ef-495c-af66-102b797190fd"), 12, "London", new Guid("345de848-8e19-41a4-944d-36c1b4d24b78"), new Guid("c99c215f-1621-4874-99b4-14fd0c1eaabe"), "Taking her art from life and nature, Helena breaks down forms simplifying and playing with the uses of light and shadows. Sometimes staying true to a likeness, which is always the starting point, but sometimes her work will take on a much more abstract nature. Often she uses her experience as a graphic designer to create works with a digital starting point using flat plains that are then assembled into a 3d structure.", "https://artpark.com.au/wp-content/uploads/2022/12/Tosca-60x52x15cm-600x600.jpg", 17m, "Horse" },
                    { new Guid("bb97de39-48cf-440e-af9a-53fd0c5848ee"), 10, "Buenos Aires", new Guid("345de848-8e19-41a4-944d-36c1b4d24b78"), null, "A group of bees compete for the only female in the group. Climate change, pesticides and ever-dwindling habitat make it difficult for bees around the world to maintain their species.", "https://image.geo.de/32808766/t/vQ/v5/w1440/r1.5/-/--karine-aigner--1---wildlife-photographer-of-the-year.jpg", 15m, "Bees" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CategoryId", "CreatorId", "Description", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { new Guid("4535d70c-a129-4091-ac5d-a265b0f81983"), 2, new Guid("345de848-8e19-41a4-944d-36c1b4d24b78"), "Fallingwater is a house designed by the architect Frank Lloyd Wright in 1935 in the Laurel Highlands of southwest Pennsylvania, about 70 miles (110 km) southeast of Pittsburgh in the United States. It is built partly over a waterfall on Bear Run in the Mill Run section of Stewart Township, Fayette County, Pennsylvania.", "https://en.wikipedia.org/wiki/Fallingwater#/media/File:Fallingwater3.jpg", "Fallingwater" },
                    { new Guid("7b668896-4084-4129-9208-3940cf5cb523"), 4, new Guid("345de848-8e19-41a4-944d-36c1b4d24b78"), "Sarpaneva made his and Finland's largest glass sculpture, Ahtojää (\"Pack Ice,\" renamed from Jäävuori, \"Iceberg\"), for the Finnish pavilion at Expo 67 in Montreal in 1967.", "https://upload.wikimedia.org/wikipedia/commons/3/34/The_Year_Zero_1985_Sarpaneva.jpg", "The Year Zero" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("72cde238-82ef-495c-af66-102b797190fd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bb97de39-48cf-440e-af9a-53fd0c5848ee"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("4535d70c-a129-4091-ac5d-a265b0f81983"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("7b668896-4084-4129-9208-3940cf5cb523"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 25, 12, 7, 1, 213, DateTimeKind.Utc).AddTicks(7848),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 25, 12, 7, 1, 212, DateTimeKind.Utc).AddTicks(9782),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "City", "CreatedOn", "CreatorId", "CustomerId", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("2e533a0d-271c-442e-9257-16311d122026"), 10, "Buenos Aires", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("345de848-8e19-41a4-944d-36c1b4d24b78"), null, "A group of bees compete for the only female in the group. Climate change, pesticides and ever-dwindling habitat make it difficult for bees around the world to maintain their species.", "https://image.geo.de/32808766/t/vQ/v5/w1440/r1.5/-/--karine-aigner--1---wildlife-photographer-of-the-year.jpg", 15m, "Bees" },
                    { new Guid("8b2e0273-6356-43cd-8eb9-4923dc5f7cc7"), 12, "London", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("345de848-8e19-41a4-944d-36c1b4d24b78"), new Guid("c99c215f-1621-4874-99b4-14fd0c1eaabe"), "Taking her art from life and nature, Helena breaks down forms simplifying and playing with the uses of light and shadows. Sometimes staying true to a likeness, which is always the starting point, but sometimes her work will take on a much more abstract nature. Often she uses her experience as a graphic designer to create works with a digital starting point using flat plains that are then assembled into a 3d structure.", "https://artpark.com.au/wp-content/uploads/2022/12/Tosca-60x52x15cm-600x600.jpg", 17m, "Horse" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "CreatorId", "Description", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { new Guid("af4b27d8-e225-4104-9a23-e4d8292e6091"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("345de848-8e19-41a4-944d-36c1b4d24b78"), "Fallingwater is a house designed by the architect Frank Lloyd Wright in 1935 in the Laurel Highlands of southwest Pennsylvania, about 70 miles (110 km) southeast of Pittsburgh in the United States. It is built partly over a waterfall on Bear Run in the Mill Run section of Stewart Township, Fayette County, Pennsylvania.", "https://en.wikipedia.org/wiki/Fallingwater#/media/File:Fallingwater3.jpg", "Fallingwater" },
                    { new Guid("b3364445-34a8-4e7a-9866-e745c62ff0ff"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("345de848-8e19-41a4-944d-36c1b4d24b78"), "Sarpaneva made his and Finland's largest glass sculpture, Ahtojää (\"Pack Ice,\" renamed from Jäävuori, \"Iceberg\"), for the Finnish pavilion at Expo 67 in Montreal in 1967.", "https://upload.wikimedia.org/wikipedia/commons/3/34/The_Year_Zero_1985_Sarpaneva.jpg", "The Year Zero" }
                });
        }
    }
}
