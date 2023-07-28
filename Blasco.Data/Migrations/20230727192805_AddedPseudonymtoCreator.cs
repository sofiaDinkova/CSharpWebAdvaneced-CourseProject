using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blasco.Data.Migrations
{
    public partial class AddedPseudonymtoCreator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d1e4dda7-c237-4d62-baa0-8ae661919584"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("de296de3-4962-44a5-b505-49fc62bd6dd2"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("3c447653-65ad-4a82-a0bb-7896aa450205"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("d83c56de-b816-41ef-b11b-4a2b0e9fb2c6"));

            migrationBuilder.AddColumn<string>(
                name: "Pseudonym",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Pseudonym");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "City", "CreatorId", "CustomerId", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("4d4c87f9-088d-42be-a256-f1ceea011909"), 12, "London", new Guid("345de848-8e19-41a4-944d-36c1b4d24b78"), new Guid("c99c215f-1621-4874-99b4-14fd0c1eaabe"), "Taking her art from life and nature, Helena breaks down forms simplifying and playing with the uses of light and shadows. Sometimes staying true to a likeness, which is always the starting point, but sometimes her work will take on a much more abstract nature. Often she uses her experience as a graphic designer to create works with a digital starting point using flat plains that are then assembled into a 3d structure.", "https://artpark.com.au/wp-content/uploads/2022/12/Tosca-60x52x15cm-600x600.jpg", 17m, "Horse" },
                    { new Guid("bd7ff9e2-7d14-4d41-89db-cd594405f573"), 10, "Buenos Aires", new Guid("345de848-8e19-41a4-944d-36c1b4d24b78"), null, "A group of bees compete for the only female in the group. Climate change, pesticides and ever-dwindling habitat make it difficult for bees around the world to maintain their species.", "https://image.geo.de/32808766/t/vQ/v5/w1440/r1.5/-/--karine-aigner--1---wildlife-photographer-of-the-year.jpg", 15m, "Bees" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CategoryId", "CreatorId", "Description", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { new Guid("75dc5b88-4ca1-42d4-ae74-53c7ebcc2cd3"), 4, new Guid("345de848-8e19-41a4-944d-36c1b4d24b78"), "Sarpaneva made his and Finland's largest glass sculpture, Ahtojää (\"Pack Ice,\" renamed from Jäävuori, \"Iceberg\"), for the Finnish pavilion at Expo 67 in Montreal in 1967.", "https://upload.wikimedia.org/wikipedia/commons/3/34/The_Year_Zero_1985_Sarpaneva.jpg", "The Year Zero" },
                    { new Guid("c555ed2c-343d-4c6e-924a-f774236da6e5"), 2, new Guid("345de848-8e19-41a4-944d-36c1b4d24b78"), "Fallingwater is a house designed by the architect Frank Lloyd Wright in 1935 in the Laurel Highlands of southwest Pennsylvania, about 70 miles (110 km) southeast of Pittsburgh in the United States. It is built partly over a waterfall on Bear Run in the Mill Run section of Stewart Township, Fayette County, Pennsylvania.", "https://en.wikipedia.org/wiki/Fallingwater#/media/File:Fallingwater3.jpg", "Fallingwater" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4d4c87f9-088d-42be-a256-f1ceea011909"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bd7ff9e2-7d14-4d41-89db-cd594405f573"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("75dc5b88-4ca1-42d4-ae74-53c7ebcc2cd3"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("c555ed2c-343d-4c6e-924a-f774236da6e5"));

            migrationBuilder.DropColumn(
                name: "Pseudonym",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "City", "CreatedOn", "CreatorId", "CustomerId", "Description", "ImageUrl", "IsActive", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("d1e4dda7-c237-4d62-baa0-8ae661919584"), 12, "London", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("345de848-8e19-41a4-944d-36c1b4d24b78"), new Guid("c99c215f-1621-4874-99b4-14fd0c1eaabe"), "Taking her art from life and nature, Helena breaks down forms simplifying and playing with the uses of light and shadows. Sometimes staying true to a likeness, which is always the starting point, but sometimes her work will take on a much more abstract nature. Often she uses her experience as a graphic designer to create works with a digital starting point using flat plains that are then assembled into a 3d structure.", "https://artpark.com.au/wp-content/uploads/2022/12/Tosca-60x52x15cm-600x600.jpg", false, 17m, "Horse" },
                    { new Guid("de296de3-4962-44a5-b505-49fc62bd6dd2"), 10, "Buenos Aires", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("345de848-8e19-41a4-944d-36c1b4d24b78"), null, "A group of bees compete for the only female in the group. Climate change, pesticides and ever-dwindling habitat make it difficult for bees around the world to maintain their species.", "https://image.geo.de/32808766/t/vQ/v5/w1440/r1.5/-/--karine-aigner--1---wildlife-photographer-of-the-year.jpg", false, 15m, "Bees" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "CreatorId", "Description", "ImageUrl", "IsActive", "Title" },
                values: new object[,]
                {
                    { new Guid("3c447653-65ad-4a82-a0bb-7896aa450205"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("345de848-8e19-41a4-944d-36c1b4d24b78"), "Fallingwater is a house designed by the architect Frank Lloyd Wright in 1935 in the Laurel Highlands of southwest Pennsylvania, about 70 miles (110 km) southeast of Pittsburgh in the United States. It is built partly over a waterfall on Bear Run in the Mill Run section of Stewart Township, Fayette County, Pennsylvania.", "https://en.wikipedia.org/wiki/Fallingwater#/media/File:Fallingwater3.jpg", false, "Fallingwater" },
                    { new Guid("d83c56de-b816-41ef-b11b-4a2b0e9fb2c6"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("345de848-8e19-41a4-944d-36c1b4d24b78"), "Sarpaneva made his and Finland's largest glass sculpture, Ahtojää (\"Pack Ice,\" renamed from Jäävuori, \"Iceberg\"), for the Finnish pavilion at Expo 67 in Montreal in 1967.", "https://upload.wikimedia.org/wikipedia/commons/3/34/The_Year_Zero_1985_Sarpaneva.jpg", false, "The Year Zero" }
                });
        }
    }
}
