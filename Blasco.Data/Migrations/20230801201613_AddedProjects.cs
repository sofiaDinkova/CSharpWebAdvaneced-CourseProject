using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blasco.Data.Migrations
{
    public partial class AddedProjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Challenges",
                keyColumn: "Id",
                keyValue: new Guid("a1d2afca-1d02-4823-ae42-93c9f3c50d44"));

            migrationBuilder.DeleteData(
                table: "Challenges",
                keyColumn: "Id",
                keyValue: new Guid("f9dde318-3a7e-4227-8097-44f816827da6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("001ffeea-0b2f-4751-8a1f-976121b2e91c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1aae51ac-e5c9-4396-af09-771b656b584f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("38ae8c76-2eef-45b9-9fdb-afb3afb49cdb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7e2fff18-acb5-4a7c-9506-2d3a7a348ece"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8f6b3a86-ab14-431c-9927-dfcf18a7ef1c"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("0643e2bc-6269-45b8-b820-a01824d9b45f"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("2fc47a9c-a5f5-429c-ba2d-c8fac8ccb437"));

            migrationBuilder.InsertData(
                table: "Challenges",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsOnGoing", "PriceToWin", "Title", "WinnerId" },
                values: new object[,]
                {
                    { new Guid("1f99bcae-b8e9-4419-86b5-946cc9986094"), 10, "Calling all nature enthusiasts and photography enthusiasts alike! Embark on a visual journey of awe and wonder as we invite you to participate in our thrilling contest, \"Capturing Nature's Wonders: A Photographic Odyssey.\" Immerse yourself in the beauty of the natural world and showcase your talent by capturing the most mesmerizing moments in nature through your lens.", "https://media.cnn.com/api/v1/images/stellar/prod/230706090105-02-monaco-foundation-environmental-photography-awards.jpg?c=original&q=h_618,c_fill", true, 200m, "Capturing Nature's Wonders: A Photographic Odyssey", null },
                    { new Guid("c90d9b5b-b70b-459c-8840-b454667d67ca"), 5, "Are you a creative mind with a flair for design? Put your artistic prowess to the test and join our exciting contest, \"Architectural Visions: Redesign Our Identity.\"\r\n\r\nAre you up for the challenge? Unleash your creativity and design a new logo that symbolizes the essence of Architecture, evoking elegance, forward-thinking concepts, and a seamless fusion of form and function.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQt_6cdJdGcppF55kqefSCDtaPuH9CFyZx1ktsjy1AX5GhsO4hGDYnZXtExPtahHlQkpdg&usqp=CAU", true, 200m, "Architectural Visions: Redesign Our Identity", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "City", "CreatorId", "CustomerId", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("0c9c87ad-8b28-48f9-ad57-53079c092035"), 12, "London", new Guid("635e95ca-66d3-424b-a63b-6c17b36bbb42"), new Guid("650511f1-b82c-4d3b-85f5-d769c096aa97"), "Taking her art from life and nature, Helena breaks down forms simplifying and playing with the uses of light and shadows. Sometimes staying true to a likeness, which is always the starting point, but sometimes her work will take on a much more abstract nature. Often she uses her experience as a graphic designer to create works with a digital starting point using flat plains that are then assembled into a 3d structure.", "https://artpark.com.au/wp-content/uploads/2022/12/Tosca-60x52x15cm-600x600.jpg", 17m, "Horse" },
                    { new Guid("7873d198-3850-44ec-9552-466e9bfd291f"), 7, "Madrid", new Guid("7cd705c4-c50a-45a2-ad5b-4fe7fdf3b009"), null, "Discover the beauty of flowers with this stunning Found a Flower Bouquet in Heavy Textured 3d Abstract Art. The intricate botanical design is both abstract and realistic, capturing the essence of nature in a unique and eye-catching way. Measuring 12x18 inches, it's the perfect size to make a stateme...", "https://images.saatchiart.com/saatchi/1883590/art/10134163/9196933-ZIJATGTD-6.jpg", 23m, "Heavy Textured 3d Abstract Art Painting" },
                    { new Guid("84f63997-e74f-48e1-ad30-e2f263e02832"), 11, "Paris", new Guid("635e95ca-66d3-424b-a63b-6c17b36bbb42"), null, "High-quality Print of a girl with a sword and dog", "https://global-uploads.webflow.com/5e3ce2ec7f6e53c045fe7cfa/603debbc0b31de538d79fa5e_discovery.png", 23m, "Girl with a sword and dog" },
                    { new Guid("a872566c-e10c-42bc-b50d-a7b6fe20bee8"), 13, "Madrid", new Guid("7cd705c4-c50a-45a2-ad5b-4fe7fdf3b009"), null, "Beautiful sunrise over mountains", "https://reviewed-com-res.cloudinary.com/image/fetch/s--bELGdL_2--/b_white,c_limit,cs_srgb,f_auto,fl_progressive.strip_profile,g_center,q_auto,w_972/https://reviewed-production.s3.amazonaws.com/1655235044230/341DA4D2-A0C7-4E24-AC12-04BD64CDC6E1_1_201_a.jpeg", 23m, "Sunrise" },
                    { new Guid("cc38d3a2-5681-4424-9aee-062ce60ae511"), 10, "Buenos Aires", new Guid("0c13dba1-b072-4e26-9cc5-f93eb50adf00"), null, "A group of bees compete for the only female in the group. Climate change, pesticides and ever-dwindling habitat make it difficult for bees around the world to maintain their species.", "https://image.geo.de/32808766/t/vQ/v5/w1440/r1.5/-/--karine-aigner--1---wildlife-photographer-of-the-year.jpg", 15m, "Bees" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CategoryId", "ChallengeId", "CreatorId", "Description", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { new Guid("385f1ebd-dd63-47a9-9a46-39f27599cae7"), 4, null, new Guid("635e95ca-66d3-424b-a63b-6c17b36bbb42"), "Sarpaneva made his and Finland's largest glass sculpture, Ahtojää (\"Pack Ice,\" renamed from Jäävuori, \"Iceberg\"), for the Finnish pavilion at Expo 67 in Montreal in 1967.", "https://upload.wikimedia.org/wikipedia/commons/3/34/The_Year_Zero_1985_Sarpaneva.jpg", "The Year Zero" },
                    { new Guid("48d79e5e-9979-4e5c-9ab4-d050c774aa2a"), 2, null, new Guid("635e95ca-66d3-424b-a63b-6c17b36bbb42"), "Fallingwater is a house designed by the architect Frank Lloyd Wright in 1935 in the Laurel Highlands of southwest Pennsylvania, about 70 miles (110 km) southeast of Pittsburgh in the United States. It is built partly over a waterfall on Bear Run in the Mill Run section of Stewart Township, Fayette County, Pennsylvania.", "https://en.wikipedia.org/wiki/Fallingwater#/media/File:Fallingwater3.jpg", "Fallingwater" },
                    { new Guid("96f91254-5a50-45d3-a4f0-5f44b83c810b"), 10, new Guid("1f99bcae-b8e9-4419-86b5-946cc9986094"), new Guid("635e95ca-66d3-424b-a63b-6c17b36bbb42"), "In Collaboration with the Zoo: Graceful Giants Unveiled - A Mesmerizing Giraffe Photoshoot\r\nStep into a world of wonder as our lens captures the mesmerizing charm of giraffes, revealing their elegant grace and captivating allure. Witness these gentle giants in their natural habitat, towering above the savanna, their majestic presence leaving an indelible mark on your heart. ", "https://static.photocrowd.com/upl/YJ/cms.z47KexT7uDpD2YJWlvXw-collection_cover.jpeg", "Giraffe" },
                    { new Guid("a5d01ff6-a784-4e05-902e-696ee0d6ca62"), 5, new Guid("c90d9b5b-b70b-459c-8840-b454667d67ca"), new Guid("635e95ca-66d3-424b-a63b-6c17b36bbb42"), "In my design I reimagined the identity by drawing inspiration from the mesmerizing patterns and structural elements of iconic architectural landmarks worldwide. Through a harmonious blend of modern aesthetics and timeless elegance, I created a visually captivating representation that symbolizes our collective journey towards a progressive and interconnected future.", "https://weandthecolor.com/wp-content/uploads/2013/03/Architecture-Brand-Identity-University-Project-by-Matt-Purcell.jpg", "Architecture Brand Identity" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Challenges",
                keyColumn: "Id",
                keyValue: new Guid("1f99bcae-b8e9-4419-86b5-946cc9986094"));

            migrationBuilder.DeleteData(
                table: "Challenges",
                keyColumn: "Id",
                keyValue: new Guid("c90d9b5b-b70b-459c-8840-b454667d67ca"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0c9c87ad-8b28-48f9-ad57-53079c092035"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7873d198-3850-44ec-9552-466e9bfd291f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("84f63997-e74f-48e1-ad30-e2f263e02832"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a872566c-e10c-42bc-b50d-a7b6fe20bee8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cc38d3a2-5681-4424-9aee-062ce60ae511"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("385f1ebd-dd63-47a9-9a46-39f27599cae7"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("48d79e5e-9979-4e5c-9ab4-d050c774aa2a"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("96f91254-5a50-45d3-a4f0-5f44b83c810b"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("a5d01ff6-a784-4e05-902e-696ee0d6ca62"));

            migrationBuilder.InsertData(
                table: "Challenges",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "ImageUrl", "IsOnGoing", "PriceToWin", "Title", "WinnerId" },
                values: new object[,]
                {
                    { new Guid("a1d2afca-1d02-4823-ae42-93c9f3c50d44"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Are you a creative mind with a flair for design? Put your artistic prowess to the test and join our exciting contest, \"Architectural Visions: Redesign Our Identity.\"\r\n\r\nAre you up for the challenge? Unleash your creativity and design a new logo that symbolizes the essence of Architecture, evoking elegance, forward-thinking concepts, and a seamless fusion of form and function.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQt_6cdJdGcppF55kqefSCDtaPuH9CFyZx1ktsjy1AX5GhsO4hGDYnZXtExPtahHlQkpdg&usqp=CAU", true, 200m, "Architectural Visions: Redesign Our Identity", null },
                    { new Guid("f9dde318-3a7e-4227-8097-44f816827da6"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Calling all nature enthusiasts and photography enthusiasts alike! Embark on a visual journey of awe and wonder as we invite you to participate in our thrilling contest, \"Capturing Nature's Wonders: A Photographic Odyssey.\" Immerse yourself in the beauty of the natural world and showcase your talent by capturing the most mesmerizing moments in nature through your lens.", "https://media.cnn.com/api/v1/images/stellar/prod/230706090105-02-monaco-foundation-environmental-photography-awards.jpg?c=original&q=h_618,c_fill", true, 200m, "Capturing Nature's Wonders: A Photographic Odyssey", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "City", "CreatedOn", "CreatorId", "CustomerId", "Description", "ImageUrl", "IsActive", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("001ffeea-0b2f-4751-8a1f-976121b2e91c"), 13, "Madrid", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7cd705c4-c50a-45a2-ad5b-4fe7fdf3b009"), null, "Beautiful sunrise over mountains", "https://reviewed-com-res.cloudinary.com/image/fetch/s--bELGdL_2--/b_white,c_limit,cs_srgb,f_auto,fl_progressive.strip_profile,g_center,q_auto,w_972/https://reviewed-production.s3.amazonaws.com/1655235044230/341DA4D2-A0C7-4E24-AC12-04BD64CDC6E1_1_201_a.jpeg", false, 23m, "Sunrise" },
                    { new Guid("1aae51ac-e5c9-4396-af09-771b656b584f"), 11, "Paris", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("635e95ca-66d3-424b-a63b-6c17b36bbb42"), null, "High-quality Print of a girl with a sword and dog", "https://global-uploads.webflow.com/5e3ce2ec7f6e53c045fe7cfa/603debbc0b31de538d79fa5e_discovery.png", false, 23m, "Girl with a sword and dog" },
                    { new Guid("38ae8c76-2eef-45b9-9fdb-afb3afb49cdb"), 7, "Madrid", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7cd705c4-c50a-45a2-ad5b-4fe7fdf3b009"), null, "Discover the beauty of flowers with this stunning Found a Flower Bouquet in Heavy Textured 3d Abstract Art. The intricate botanical design is both abstract and realistic, capturing the essence of nature in a unique and eye-catching way. Measuring 12x18 inches, it's the perfect size to make a stateme...", "https://images.saatchiart.com/saatchi/1883590/art/10134163/9196933-ZIJATGTD-6.jpg", false, 23m, "Heavy Textured 3d Abstract Art Painting" },
                    { new Guid("7e2fff18-acb5-4a7c-9506-2d3a7a348ece"), 12, "London", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("635e95ca-66d3-424b-a63b-6c17b36bbb42"), new Guid("650511f1-b82c-4d3b-85f5-d769c096aa97"), "Taking her art from life and nature, Helena breaks down forms simplifying and playing with the uses of light and shadows. Sometimes staying true to a likeness, which is always the starting point, but sometimes her work will take on a much more abstract nature. Often she uses her experience as a graphic designer to create works with a digital starting point using flat plains that are then assembled into a 3d structure.", "https://artpark.com.au/wp-content/uploads/2022/12/Tosca-60x52x15cm-600x600.jpg", false, 17m, "Horse" },
                    { new Guid("8f6b3a86-ab14-431c-9927-dfcf18a7ef1c"), 10, "Buenos Aires", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0c13dba1-b072-4e26-9cc5-f93eb50adf00"), null, "A group of bees compete for the only female in the group. Climate change, pesticides and ever-dwindling habitat make it difficult for bees around the world to maintain their species.", "https://image.geo.de/32808766/t/vQ/v5/w1440/r1.5/-/--karine-aigner--1---wildlife-photographer-of-the-year.jpg", false, 15m, "Bees" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CategoryId", "ChallengeId", "CreatedOn", "CreatorId", "Description", "ImageUrl", "IsActive", "Title" },
                values: new object[,]
                {
                    { new Guid("0643e2bc-6269-45b8-b820-a01824d9b45f"), 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("635e95ca-66d3-424b-a63b-6c17b36bbb42"), "Sarpaneva made his and Finland's largest glass sculpture, Ahtojää (\"Pack Ice,\" renamed from Jäävuori, \"Iceberg\"), for the Finnish pavilion at Expo 67 in Montreal in 1967.", "https://upload.wikimedia.org/wikipedia/commons/3/34/The_Year_Zero_1985_Sarpaneva.jpg", false, "The Year Zero" },
                    { new Guid("2fc47a9c-a5f5-429c-ba2d-c8fac8ccb437"), 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("635e95ca-66d3-424b-a63b-6c17b36bbb42"), "Fallingwater is a house designed by the architect Frank Lloyd Wright in 1935 in the Laurel Highlands of southwest Pennsylvania, about 70 miles (110 km) southeast of Pittsburgh in the United States. It is built partly over a waterfall on Bear Run in the Mill Run section of Stewart Township, Fayette County, Pennsylvania.", "https://en.wikipedia.org/wiki/Fallingwater#/media/File:Fallingwater3.jpg", false, "Fallingwater" }
                });
        }
    }
}
