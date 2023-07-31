using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blasco.Data.Migrations
{
    public partial class AddedChallengeAndVoteEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "ChallengeId",
                table: "Projects",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Challenges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    IsOnGoing = table.Column<bool>(type: "bit", nullable: false),
                    WinnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Challenges_AspNetUsers_WinnerId",
                        column: x => x.WinnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectCastOnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserWhoVotedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Votes_AspNetUsers_ApplicationUserWhoVotedId",
                        column: x => x.ApplicationUserWhoVotedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Votes_Projects_ProjectCastOnId",
                        column: x => x.ProjectCastOnId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "City", "CreatorId", "CustomerId", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("137ab52f-7bdc-4d35-94c6-0211c869b925"), 10, "Buenos Aires", new Guid("0c13dba1-b072-4e26-9cc5-f93eb50adf00"), null, "A group of bees compete for the only female in the group. Climate change, pesticides and ever-dwindling habitat make it difficult for bees around the world to maintain their species.", "https://image.geo.de/32808766/t/vQ/v5/w1440/r1.5/-/--karine-aigner--1---wildlife-photographer-of-the-year.jpg", 15m, "Bees" },
                    { new Guid("49a0fc25-bfe0-4d38-9ca5-10d8daf261d8"), 11, "Paris", new Guid("635e95ca-66d3-424b-a63b-6c17b36bbb42"), null, "High-quality Print of a girl with a sword and dog", "https://global-uploads.webflow.com/5e3ce2ec7f6e53c045fe7cfa/603debbc0b31de538d79fa5e_discovery.png", 23m, "Girl with a sword and dog" },
                    { new Guid("66cbc9b1-a959-4036-aff9-6a3769880bdf"), 13, "Madrid", new Guid("7cd705c4-c50a-45a2-ad5b-4fe7fdf3b009"), null, "Beautiful sunrise over mountains", "https://reviewed-com-res.cloudinary.com/image/fetch/s--bELGdL_2--/b_white,c_limit,cs_srgb,f_auto,fl_progressive.strip_profile,g_center,q_auto,w_972/https://reviewed-production.s3.amazonaws.com/1655235044230/341DA4D2-A0C7-4E24-AC12-04BD64CDC6E1_1_201_a.jpeg", 23m, "Sunrise" },
                    { new Guid("aa9c794f-5230-4ec8-bdf4-5850d8c3de4f"), 12, "London", new Guid("635e95ca-66d3-424b-a63b-6c17b36bbb42"), new Guid("650511f1-b82c-4d3b-85f5-d769c096aa97"), "Taking her art from life and nature, Helena breaks down forms simplifying and playing with the uses of light and shadows. Sometimes staying true to a likeness, which is always the starting point, but sometimes her work will take on a much more abstract nature. Often she uses her experience as a graphic designer to create works with a digital starting point using flat plains that are then assembled into a 3d structure.", "https://artpark.com.au/wp-content/uploads/2022/12/Tosca-60x52x15cm-600x600.jpg", 17m, "Horse" },
                    { new Guid("d15de9ac-301f-4ffc-b64d-4bdf45d0eba3"), 7, "Madrid", new Guid("7cd705c4-c50a-45a2-ad5b-4fe7fdf3b009"), null, "Discover the beauty of flowers with this stunning Found a Flower Bouquet in Heavy Textured 3d Abstract Art. The intricate botanical design is both abstract and realistic, capturing the essence of nature in a unique and eye-catching way. Measuring 12x18 inches, it's the perfect size to make a stateme...", "https://images.saatchiart.com/saatchi/1883590/art/10134163/9196933-ZIJATGTD-6.jpg", 23m, "Heavy Textured 3d Abstract Art Painting" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CategoryId", "ChallengeId", "CreatorId", "Description", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { new Guid("378b1b7a-4a49-4fea-8159-2301941b5724"), 4, null, new Guid("635e95ca-66d3-424b-a63b-6c17b36bbb42"), "Sarpaneva made his and Finland's largest glass sculpture, Ahtojää (\"Pack Ice,\" renamed from Jäävuori, \"Iceberg\"), for the Finnish pavilion at Expo 67 in Montreal in 1967.", "https://upload.wikimedia.org/wikipedia/commons/3/34/The_Year_Zero_1985_Sarpaneva.jpg", "The Year Zero" },
                    { new Guid("489268b7-ee80-4fd1-8813-ba748e17f4cd"), 2, null, new Guid("635e95ca-66d3-424b-a63b-6c17b36bbb42"), "Fallingwater is a house designed by the architect Frank Lloyd Wright in 1935 in the Laurel Highlands of southwest Pennsylvania, about 70 miles (110 km) southeast of Pittsburgh in the United States. It is built partly over a waterfall on Bear Run in the Mill Run section of Stewart Township, Fayette County, Pennsylvania.", "https://en.wikipedia.org/wiki/Fallingwater#/media/File:Fallingwater3.jpg", "Fallingwater" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ChallengeId",
                table: "Projects",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_WinnerId",
                table: "Challenges",
                column: "WinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_ApplicationUserWhoVotedId",
                table: "Votes",
                column: "ApplicationUserWhoVotedId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_ProjectCastOnId",
                table: "Votes",
                column: "ProjectCastOnId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Challenges_ChallengeId",
                table: "Projects",
                column: "ChallengeId",
                principalTable: "Challenges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Challenges_ChallengeId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "Challenges");

            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ChallengeId",
                table: "Projects");

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

            migrationBuilder.DropColumn(
                name: "ChallengeId",
                table: "Projects");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "City", "CreatedOn", "CreatorId", "CustomerId", "Description", "ImageUrl", "IsActive", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("3628f457-5d3e-4400-a8ee-dd13f501170d"), 7, "Madrid", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7cd705c4-c50a-45a2-ad5b-4fe7fdf3b009"), null, "Discover the beauty of flowers with this stunning Found a Flower Bouquet in Heavy Textured 3d Abstract Art. The intricate botanical design is both abstract and realistic, capturing the essence of nature in a unique and eye-catching way. Measuring 12x18 inches, it's the perfect size to make a stateme...", "https://images.saatchiart.com/saatchi/1883590/art/10134163/9196933-ZIJATGTD-6.jpg", false, 23m, "Heavy Textured 3d Abstract Art Painting" },
                    { new Guid("4095acbe-7e5e-4e5f-8a4f-06b59c659372"), 13, "Madrid", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7cd705c4-c50a-45a2-ad5b-4fe7fdf3b009"), null, "Beautiful sunrise over mountains", "https://reviewed-com-res.cloudinary.com/image/fetch/s--bELGdL_2--/b_white,c_limit,cs_srgb,f_auto,fl_progressive.strip_profile,g_center,q_auto,w_972/https://reviewed-production.s3.amazonaws.com/1655235044230/341DA4D2-A0C7-4E24-AC12-04BD64CDC6E1_1_201_a.jpeg", false, 23m, "Sunrise" },
                    { new Guid("579784ba-89df-4070-a2ac-8c4ca442e1b4"), 12, "London", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("635e95ca-66d3-424b-a63b-6c17b36bbb42"), new Guid("650511f1-b82c-4d3b-85f5-d769c096aa97"), "Taking her art from life and nature, Helena breaks down forms simplifying and playing with the uses of light and shadows. Sometimes staying true to a likeness, which is always the starting point, but sometimes her work will take on a much more abstract nature. Often she uses her experience as a graphic designer to create works with a digital starting point using flat plains that are then assembled into a 3d structure.", "https://artpark.com.au/wp-content/uploads/2022/12/Tosca-60x52x15cm-600x600.jpg", false, 17m, "Horse" },
                    { new Guid("ba56fd54-12a3-4ea8-bbc5-b8c8d2efa504"), 11, "Paris", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("635e95ca-66d3-424b-a63b-6c17b36bbb42"), null, "High-quality Print of a girl with a sword and dog", "https://global-uploads.webflow.com/5e3ce2ec7f6e53c045fe7cfa/603debbc0b31de538d79fa5e_discovery.png", false, 23m, "Girl with a sword and dog" },
                    { new Guid("dac5ee23-b72f-4f94-818f-249a03bd71c1"), 10, "Buenos Aires", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0c13dba1-b072-4e26-9cc5-f93eb50adf00"), null, "A group of bees compete for the only female in the group. Climate change, pesticides and ever-dwindling habitat make it difficult for bees around the world to maintain their species.", "https://image.geo.de/32808766/t/vQ/v5/w1440/r1.5/-/--karine-aigner--1---wildlife-photographer-of-the-year.jpg", false, 15m, "Bees" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "CreatorId", "Description", "ImageUrl", "IsActive", "Title" },
                values: new object[,]
                {
                    { new Guid("e3fc0ada-0f70-4513-a623-cfa810cea722"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("635e95ca-66d3-424b-a63b-6c17b36bbb42"), "Sarpaneva made his and Finland's largest glass sculpture, Ahtojää (\"Pack Ice,\" renamed from Jäävuori, \"Iceberg\"), for the Finnish pavilion at Expo 67 in Montreal in 1967.", "https://upload.wikimedia.org/wikipedia/commons/3/34/The_Year_Zero_1985_Sarpaneva.jpg", false, "The Year Zero" },
                    { new Guid("edddcd68-84e5-4064-8aac-27bffe7af98e"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("635e95ca-66d3-424b-a63b-6c17b36bbb42"), "Fallingwater is a house designed by the architect Frank Lloyd Wright in 1935 in the Laurel Highlands of southwest Pennsylvania, about 70 miles (110 km) southeast of Pittsburgh in the United States. It is built partly over a waterfall on Bear Run in the Mill Run section of Stewart Township, Fayette County, Pennsylvania.", "https://en.wikipedia.org/wiki/Fallingwater#/media/File:Fallingwater3.jpg", false, "Fallingwater" }
                });
        }
    }
}
