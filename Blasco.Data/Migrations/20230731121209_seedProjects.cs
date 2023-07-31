using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blasco.Data.Migrations
{
    public partial class seedProjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4ceab04c-b9f5-472c-8a1f-1d902437d800"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4dd89adb-8fc9-4816-9314-5367d2a7a239"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6dd3294f-59de-4abc-9b30-cab2e48ca7e2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("75605076-26f0-435b-8a0b-85171b89d360"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f1d2166c-fc49-4ecc-8dba-11bc1babd6e0"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "City", "CreatorId", "CustomerId", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("3628f457-5d3e-4400-a8ee-dd13f501170d"), 7, "Madrid", new Guid("7cd705c4-c50a-45a2-ad5b-4fe7fdf3b009"), null, "Discover the beauty of flowers with this stunning Found a Flower Bouquet in Heavy Textured 3d Abstract Art. The intricate botanical design is both abstract and realistic, capturing the essence of nature in a unique and eye-catching way. Measuring 12x18 inches, it's the perfect size to make a stateme...", "https://images.saatchiart.com/saatchi/1883590/art/10134163/9196933-ZIJATGTD-6.jpg", 23m, "Heavy Textured 3d Abstract Art Painting" },
                    { new Guid("4095acbe-7e5e-4e5f-8a4f-06b59c659372"), 13, "Madrid", new Guid("7cd705c4-c50a-45a2-ad5b-4fe7fdf3b009"), null, "Beautiful sunrise over mountains", "https://reviewed-com-res.cloudinary.com/image/fetch/s--bELGdL_2--/b_white,c_limit,cs_srgb,f_auto,fl_progressive.strip_profile,g_center,q_auto,w_972/https://reviewed-production.s3.amazonaws.com/1655235044230/341DA4D2-A0C7-4E24-AC12-04BD64CDC6E1_1_201_a.jpeg", 23m, "Sunrise" },
                    { new Guid("579784ba-89df-4070-a2ac-8c4ca442e1b4"), 12, "London", new Guid("635e95ca-66d3-424b-a63b-6c17b36bbb42"), new Guid("650511f1-b82c-4d3b-85f5-d769c096aa97"), "Taking her art from life and nature, Helena breaks down forms simplifying and playing with the uses of light and shadows. Sometimes staying true to a likeness, which is always the starting point, but sometimes her work will take on a much more abstract nature. Often she uses her experience as a graphic designer to create works with a digital starting point using flat plains that are then assembled into a 3d structure.", "https://artpark.com.au/wp-content/uploads/2022/12/Tosca-60x52x15cm-600x600.jpg", 17m, "Horse" },
                    { new Guid("ba56fd54-12a3-4ea8-bbc5-b8c8d2efa504"), 11, "Paris", new Guid("635e95ca-66d3-424b-a63b-6c17b36bbb42"), null, "High-quality Print of a girl with a sword and dog", "https://global-uploads.webflow.com/5e3ce2ec7f6e53c045fe7cfa/603debbc0b31de538d79fa5e_discovery.png", 23m, "Girl with a sword and dog" },
                    { new Guid("dac5ee23-b72f-4f94-818f-249a03bd71c1"), 10, "Buenos Aires", new Guid("0c13dba1-b072-4e26-9cc5-f93eb50adf00"), null, "A group of bees compete for the only female in the group. Climate change, pesticides and ever-dwindling habitat make it difficult for bees around the world to maintain their species.", "https://image.geo.de/32808766/t/vQ/v5/w1440/r1.5/-/--karine-aigner--1---wildlife-photographer-of-the-year.jpg", 15m, "Bees" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CategoryId", "CreatorId", "Description", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { new Guid("e3fc0ada-0f70-4513-a623-cfa810cea722"), 4, new Guid("635e95ca-66d3-424b-a63b-6c17b36bbb42"), "Sarpaneva made his and Finland's largest glass sculpture, Ahtojää (\"Pack Ice,\" renamed from Jäävuori, \"Iceberg\"), for the Finnish pavilion at Expo 67 in Montreal in 1967.", "https://upload.wikimedia.org/wikipedia/commons/3/34/The_Year_Zero_1985_Sarpaneva.jpg", "The Year Zero" },
                    { new Guid("edddcd68-84e5-4064-8aac-27bffe7af98e"), 2, new Guid("635e95ca-66d3-424b-a63b-6c17b36bbb42"), "Fallingwater is a house designed by the architect Frank Lloyd Wright in 1935 in the Laurel Highlands of southwest Pennsylvania, about 70 miles (110 km) southeast of Pittsburgh in the United States. It is built partly over a waterfall on Bear Run in the Mill Run section of Stewart Township, Fayette County, Pennsylvania.", "https://en.wikipedia.org/wiki/Fallingwater#/media/File:Fallingwater3.jpg", "Fallingwater" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3628f457-5d3e-4400-a8ee-dd13f501170d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4095acbe-7e5e-4e5f-8a4f-06b59c659372"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("579784ba-89df-4070-a2ac-8c4ca442e1b4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ba56fd54-12a3-4ea8-bbc5-b8c8d2efa504"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dac5ee23-b72f-4f94-818f-249a03bd71c1"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("e3fc0ada-0f70-4513-a623-cfa810cea722"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("edddcd68-84e5-4064-8aac-27bffe7af98e"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "City", "CreatedOn", "CreatorId", "CustomerId", "Description", "ImageUrl", "IsActive", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("4ceab04c-b9f5-472c-8a1f-1d902437d800"), 10, "Buenos Aires", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0c13dba1-b072-4e26-9cc5-f93eb50adf00"), null, "A group of bees compete for the only female in the group. Climate change, pesticides and ever-dwindling habitat make it difficult for bees around the world to maintain their species.", "https://image.geo.de/32808766/t/vQ/v5/w1440/r1.5/-/--karine-aigner--1---wildlife-photographer-of-the-year.jpg", false, 15m, "Bees" },
                    { new Guid("4dd89adb-8fc9-4816-9314-5367d2a7a239"), 12, "London", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("635e95ca-66d3-424b-a63b-6c17b36bbb42"), new Guid("650511f1-b82c-4d3b-85f5-d769c096aa97"), "Taking her art from life and nature, Helena breaks down forms simplifying and playing with the uses of light and shadows. Sometimes staying true to a likeness, which is always the starting point, but sometimes her work will take on a much more abstract nature. Often she uses her experience as a graphic designer to create works with a digital starting point using flat plains that are then assembled into a 3d structure.", "https://artpark.com.au/wp-content/uploads/2022/12/Tosca-60x52x15cm-600x600.jpg", false, 17m, "Horse" },
                    { new Guid("6dd3294f-59de-4abc-9b30-cab2e48ca7e2"), 7, "Madrid", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7cd705c4-c50a-45a2-ad5b-4fe7fdf3b009"), null, "Discover the beauty of flowers with this stunning Found a Flower Bouquet in Heavy Textured 3d Abstract Art. The intricate botanical design is both abstract and realistic, capturing the essence of nature in a unique and eye-catching way. Measuring 12x18 inches, it's the perfect size to make a stateme...", "https://images.saatchiart.com/saatchi/1883590/art/10134163/9196933-ZIJATGTD-6.jpg", false, 23m, "Heavy Textured 3d Abstract Art Painting" },
                    { new Guid("75605076-26f0-435b-8a0b-85171b89d360"), 13, "Madrid", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7cd705c4-c50a-45a2-ad5b-4fe7fdf3b009"), null, "Beautiful sunrise over mountains", "https://reviewed-com-res.cloudinary.com/image/fetch/s--bELGdL_2--/b_white,c_limit,cs_srgb,f_auto,fl_progressive.strip_profile,g_center,q_auto,w_972/https://reviewed-production.s3.amazonaws.com/1655235044230/341DA4D2-A0C7-4E24-AC12-04BD64CDC6E1_1_201_a.jpeg", false, 23m, "Sunrise" },
                    { new Guid("f1d2166c-fc49-4ecc-8dba-11bc1babd6e0"), 11, "Paris", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("635e95ca-66d3-424b-a63b-6c17b36bbb42"), null, "High-quality Print of a girl with a sword and dog", "https://global-uploads.webflow.com/5e3ce2ec7f6e53c045fe7cfa/603debbc0b31de538d79fa5e_discovery.png", false, 23m, "Girl with a sword and dog" }
                });
        }
    }
}
