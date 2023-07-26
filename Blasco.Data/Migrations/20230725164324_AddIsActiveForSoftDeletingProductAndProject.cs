using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blasco.Data.Migrations
{
    public partial class AddIsActiveForSoftDeletingProductAndProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "City", "CreatorId", "CustomerId", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("137a2cfe-88c5-4b10-bda9-3c4ce7c82b9b"), 10, "Buenos Aires", new Guid("345de848-8e19-41a4-944d-36c1b4d24b78"), null, "A group of bees compete for the only female in the group. Climate change, pesticides and ever-dwindling habitat make it difficult for bees around the world to maintain their species.", "https://image.geo.de/32808766/t/vQ/v5/w1440/r1.5/-/--karine-aigner--1---wildlife-photographer-of-the-year.jpg", 15m, "Bees" },
                    { new Guid("8b7bb825-da2d-4fd8-86e7-d23de488e65f"), 12, "London", new Guid("345de848-8e19-41a4-944d-36c1b4d24b78"), new Guid("c99c215f-1621-4874-99b4-14fd0c1eaabe"), "Taking her art from life and nature, Helena breaks down forms simplifying and playing with the uses of light and shadows. Sometimes staying true to a likeness, which is always the starting point, but sometimes her work will take on a much more abstract nature. Often she uses her experience as a graphic designer to create works with a digital starting point using flat plains that are then assembled into a 3d structure.", "https://artpark.com.au/wp-content/uploads/2022/12/Tosca-60x52x15cm-600x600.jpg", 17m, "Horse" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CategoryId", "CreatorId", "Description", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { new Guid("9acc2d9c-788b-4647-ae8b-c074ce8ff4c9"), 2, new Guid("345de848-8e19-41a4-944d-36c1b4d24b78"), "Fallingwater is a house designed by the architect Frank Lloyd Wright in 1935 in the Laurel Highlands of southwest Pennsylvania, about 70 miles (110 km) southeast of Pittsburgh in the United States. It is built partly over a waterfall on Bear Run in the Mill Run section of Stewart Township, Fayette County, Pennsylvania.", "https://en.wikipedia.org/wiki/Fallingwater#/media/File:Fallingwater3.jpg", "Fallingwater" },
                    { new Guid("fcc44945-911b-413f-986f-73e84fce4b50"), 4, new Guid("345de848-8e19-41a4-944d-36c1b4d24b78"), "Sarpaneva made his and Finland's largest glass sculpture, Ahtojää (\"Pack Ice,\" renamed from Jäävuori, \"Iceberg\"), for the Finnish pavilion at Expo 67 in Montreal in 1967.", "https://upload.wikimedia.org/wikipedia/commons/3/34/The_Year_Zero_1985_Sarpaneva.jpg", "The Year Zero" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("137a2cfe-88c5-4b10-bda9-3c4ce7c82b9b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8b7bb825-da2d-4fd8-86e7-d23de488e65f"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("9acc2d9c-788b-4647-ae8b-c074ce8ff4c9"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("fcc44945-911b-413f-986f-73e84fce4b50"));

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "City", "CreatedOn", "CreatorId", "CustomerId", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("72cde238-82ef-495c-af66-102b797190fd"), 12, "London", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("345de848-8e19-41a4-944d-36c1b4d24b78"), new Guid("c99c215f-1621-4874-99b4-14fd0c1eaabe"), "Taking her art from life and nature, Helena breaks down forms simplifying and playing with the uses of light and shadows. Sometimes staying true to a likeness, which is always the starting point, but sometimes her work will take on a much more abstract nature. Often she uses her experience as a graphic designer to create works with a digital starting point using flat plains that are then assembled into a 3d structure.", "https://artpark.com.au/wp-content/uploads/2022/12/Tosca-60x52x15cm-600x600.jpg", 17m, "Horse" },
                    { new Guid("bb97de39-48cf-440e-af9a-53fd0c5848ee"), 10, "Buenos Aires", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("345de848-8e19-41a4-944d-36c1b4d24b78"), null, "A group of bees compete for the only female in the group. Climate change, pesticides and ever-dwindling habitat make it difficult for bees around the world to maintain their species.", "https://image.geo.de/32808766/t/vQ/v5/w1440/r1.5/-/--karine-aigner--1---wildlife-photographer-of-the-year.jpg", 15m, "Bees" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "CreatorId", "Description", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { new Guid("4535d70c-a129-4091-ac5d-a265b0f81983"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("345de848-8e19-41a4-944d-36c1b4d24b78"), "Fallingwater is a house designed by the architect Frank Lloyd Wright in 1935 in the Laurel Highlands of southwest Pennsylvania, about 70 miles (110 km) southeast of Pittsburgh in the United States. It is built partly over a waterfall on Bear Run in the Mill Run section of Stewart Township, Fayette County, Pennsylvania.", "https://en.wikipedia.org/wiki/Fallingwater#/media/File:Fallingwater3.jpg", "Fallingwater" },
                    { new Guid("7b668896-4084-4129-9208-3940cf5cb523"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("345de848-8e19-41a4-944d-36c1b4d24b78"), "Sarpaneva made his and Finland's largest glass sculpture, Ahtojää (\"Pack Ice,\" renamed from Jäävuori, \"Iceberg\"), for the Finnish pavilion at Expo 67 in Montreal in 1967.", "https://upload.wikimedia.org/wikipedia/commons/3/34/The_Year_Zero_1985_Sarpaneva.jpg", "The Year Zero" }
                });
        }
    }
}
