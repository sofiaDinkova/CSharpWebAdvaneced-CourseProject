using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blasco.Data.Migrations
{
    public partial class ChallangeEntityAddedProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("137ab52f-7bdc-4d35-94c6-0211c869b925"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("49a0fc25-bfe0-4d38-9ca5-10d8daf261d8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("66cbc9b1-a959-4036-aff9-6a3769880bdf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("aa9c794f-5230-4ec8-bdf4-5850d8c3de4f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d15de9ac-301f-4ffc-b64d-4bdf45d0eba3"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("378b1b7a-4a49-4fea-8159-2301941b5724"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("489268b7-ee80-4fd1-8813-ba748e17f4cd"));

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Challenges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Challenges",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Challenges",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "City", "CreatorId", "CustomerId", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("2117f723-83db-430e-8270-7b052c847ac1"), 13, "Madrid", new Guid("7cd705c4-c50a-45a2-ad5b-4fe7fdf3b009"), null, "Beautiful sunrise over mountains", "https://reviewed-com-res.cloudinary.com/image/fetch/s--bELGdL_2--/b_white,c_limit,cs_srgb,f_auto,fl_progressive.strip_profile,g_center,q_auto,w_972/https://reviewed-production.s3.amazonaws.com/1655235044230/341DA4D2-A0C7-4E24-AC12-04BD64CDC6E1_1_201_a.jpeg", 23m, "Sunrise" },
                    { new Guid("2c27a77d-8770-47b8-982b-a978ee5fc5a8"), 7, "Madrid", new Guid("7cd705c4-c50a-45a2-ad5b-4fe7fdf3b009"), null, "Discover the beauty of flowers with this stunning Found a Flower Bouquet in Heavy Textured 3d Abstract Art. The intricate botanical design is both abstract and realistic, capturing the essence of nature in a unique and eye-catching way. Measuring 12x18 inches, it's the perfect size to make a stateme...", "https://images.saatchiart.com/saatchi/1883590/art/10134163/9196933-ZIJATGTD-6.jpg", 23m, "Heavy Textured 3d Abstract Art Painting" },
                    { new Guid("64381e85-ad0a-4412-a839-07011a03d937"), 12, "London", new Guid("635e95ca-66d3-424b-a63b-6c17b36bbb42"), new Guid("650511f1-b82c-4d3b-85f5-d769c096aa97"), "Taking her art from life and nature, Helena breaks down forms simplifying and playing with the uses of light and shadows. Sometimes staying true to a likeness, which is always the starting point, but sometimes her work will take on a much more abstract nature. Often she uses her experience as a graphic designer to create works with a digital starting point using flat plains that are then assembled into a 3d structure.", "https://artpark.com.au/wp-content/uploads/2022/12/Tosca-60x52x15cm-600x600.jpg", 17m, "Horse" },
                    { new Guid("8b4e9038-8b48-4d17-bbd7-30b2113d9c96"), 10, "Buenos Aires", new Guid("0c13dba1-b072-4e26-9cc5-f93eb50adf00"), null, "A group of bees compete for the only female in the group. Climate change, pesticides and ever-dwindling habitat make it difficult for bees around the world to maintain their species.", "https://image.geo.de/32808766/t/vQ/v5/w1440/r1.5/-/--karine-aigner--1---wildlife-photographer-of-the-year.jpg", 15m, "Bees" },
                    { new Guid("f202d0b8-763c-41fa-a5b0-825708f29650"), 11, "Paris", new Guid("635e95ca-66d3-424b-a63b-6c17b36bbb42"), null, "High-quality Print of a girl with a sword and dog", "https://global-uploads.webflow.com/5e3ce2ec7f6e53c045fe7cfa/603debbc0b31de538d79fa5e_discovery.png", 23m, "Girl with a sword and dog" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CategoryId", "ChallengeId", "CreatorId", "Description", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { new Guid("31b0dc5e-2d17-4fba-8b7f-a6ccca20f7f2"), 2, null, new Guid("635e95ca-66d3-424b-a63b-6c17b36bbb42"), "Fallingwater is a house designed by the architect Frank Lloyd Wright in 1935 in the Laurel Highlands of southwest Pennsylvania, about 70 miles (110 km) southeast of Pittsburgh in the United States. It is built partly over a waterfall on Bear Run in the Mill Run section of Stewart Township, Fayette County, Pennsylvania.", "https://en.wikipedia.org/wiki/Fallingwater#/media/File:Fallingwater3.jpg", "Fallingwater" },
                    { new Guid("e56c166d-c009-4d4e-8f2d-9c74d7e433a2"), 4, null, new Guid("635e95ca-66d3-424b-a63b-6c17b36bbb42"), "Sarpaneva made his and Finland's largest glass sculpture, Ahtojää (\"Pack Ice,\" renamed from Jäävuori, \"Iceberg\"), for the Finnish pavilion at Expo 67 in Montreal in 1967.", "https://upload.wikimedia.org/wikipedia/commons/3/34/The_Year_Zero_1985_Sarpaneva.jpg", "The Year Zero" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_CategoryId",
                table: "Challenges",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Challenges_ProductProjectCategories_CategoryId",
                table: "Challenges",
                column: "CategoryId",
                principalTable: "ProductProjectCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Challenges_ProductProjectCategories_CategoryId",
                table: "Challenges");

            migrationBuilder.DropIndex(
                name: "IX_Challenges_CategoryId",
                table: "Challenges");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2117f723-83db-430e-8270-7b052c847ac1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2c27a77d-8770-47b8-982b-a978ee5fc5a8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("64381e85-ad0a-4412-a839-07011a03d937"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8b4e9038-8b48-4d17-bbd7-30b2113d9c96"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f202d0b8-763c-41fa-a5b0-825708f29650"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("31b0dc5e-2d17-4fba-8b7f-a6ccca20f7f2"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("e56c166d-c009-4d4e-8f2d-9c74d7e433a2"));

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Challenges");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Challenges");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Challenges");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "City", "CreatedOn", "CreatorId", "CustomerId", "Description", "ImageUrl", "IsActive", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("137ab52f-7bdc-4d35-94c6-0211c869b925"), 10, "Buenos Aires", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0c13dba1-b072-4e26-9cc5-f93eb50adf00"), null, "A group of bees compete for the only female in the group. Climate change, pesticides and ever-dwindling habitat make it difficult for bees around the world to maintain their species.", "https://image.geo.de/32808766/t/vQ/v5/w1440/r1.5/-/--karine-aigner--1---wildlife-photographer-of-the-year.jpg", false, 15m, "Bees" },
                    { new Guid("49a0fc25-bfe0-4d38-9ca5-10d8daf261d8"), 11, "Paris", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("635e95ca-66d3-424b-a63b-6c17b36bbb42"), null, "High-quality Print of a girl with a sword and dog", "https://global-uploads.webflow.com/5e3ce2ec7f6e53c045fe7cfa/603debbc0b31de538d79fa5e_discovery.png", false, 23m, "Girl with a sword and dog" },
                    { new Guid("66cbc9b1-a959-4036-aff9-6a3769880bdf"), 13, "Madrid", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7cd705c4-c50a-45a2-ad5b-4fe7fdf3b009"), null, "Beautiful sunrise over mountains", "https://reviewed-com-res.cloudinary.com/image/fetch/s--bELGdL_2--/b_white,c_limit,cs_srgb,f_auto,fl_progressive.strip_profile,g_center,q_auto,w_972/https://reviewed-production.s3.amazonaws.com/1655235044230/341DA4D2-A0C7-4E24-AC12-04BD64CDC6E1_1_201_a.jpeg", false, 23m, "Sunrise" },
                    { new Guid("aa9c794f-5230-4ec8-bdf4-5850d8c3de4f"), 12, "London", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("635e95ca-66d3-424b-a63b-6c17b36bbb42"), new Guid("650511f1-b82c-4d3b-85f5-d769c096aa97"), "Taking her art from life and nature, Helena breaks down forms simplifying and playing with the uses of light and shadows. Sometimes staying true to a likeness, which is always the starting point, but sometimes her work will take on a much more abstract nature. Often she uses her experience as a graphic designer to create works with a digital starting point using flat plains that are then assembled into a 3d structure.", "https://artpark.com.au/wp-content/uploads/2022/12/Tosca-60x52x15cm-600x600.jpg", false, 17m, "Horse" },
                    { new Guid("d15de9ac-301f-4ffc-b64d-4bdf45d0eba3"), 7, "Madrid", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7cd705c4-c50a-45a2-ad5b-4fe7fdf3b009"), null, "Discover the beauty of flowers with this stunning Found a Flower Bouquet in Heavy Textured 3d Abstract Art. The intricate botanical design is both abstract and realistic, capturing the essence of nature in a unique and eye-catching way. Measuring 12x18 inches, it's the perfect size to make a stateme...", "https://images.saatchiart.com/saatchi/1883590/art/10134163/9196933-ZIJATGTD-6.jpg", false, 23m, "Heavy Textured 3d Abstract Art Painting" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CategoryId", "ChallengeId", "CreatedOn", "CreatorId", "Description", "ImageUrl", "IsActive", "Title" },
                values: new object[,]
                {
                    { new Guid("378b1b7a-4a49-4fea-8159-2301941b5724"), 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("635e95ca-66d3-424b-a63b-6c17b36bbb42"), "Sarpaneva made his and Finland's largest glass sculpture, Ahtojää (\"Pack Ice,\" renamed from Jäävuori, \"Iceberg\"), for the Finnish pavilion at Expo 67 in Montreal in 1967.", "https://upload.wikimedia.org/wikipedia/commons/3/34/The_Year_Zero_1985_Sarpaneva.jpg", false, "The Year Zero" },
                    { new Guid("489268b7-ee80-4fd1-8813-ba748e17f4cd"), 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("635e95ca-66d3-424b-a63b-6c17b36bbb42"), "Fallingwater is a house designed by the architect Frank Lloyd Wright in 1935 in the Laurel Highlands of southwest Pennsylvania, about 70 miles (110 km) southeast of Pittsburgh in the United States. It is built partly over a waterfall on Bear Run in the Mill Run section of Stewart Township, Fayette County, Pennsylvania.", "https://en.wikipedia.org/wiki/Fallingwater#/media/File:Fallingwater3.jpg", false, "Fallingwater" }
                });
        }
    }
}
