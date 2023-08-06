using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blasco.Data.Migrations
{
    public partial class SeedRestOfEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Challenges");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Challenges");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Challenges",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "ApplicationUserPPCategories",
                columns: new[] { "ApplicationUserId", "PPCategoryId" },
                values: new object[,]
                {
                    { new Guid("3c09b722-de81-4d10-aa3c-1f7d8ea4bcd7"), 5 },
                    { new Guid("3c09b722-de81-4d10-aa3c-1f7d8ea4bcd7"), 8 },
                    { new Guid("64e3c1da-2969-44cd-ac2b-18b0d5179f78"), 9 },
                    { new Guid("64e3c1da-2969-44cd-ac2b-18b0d5179f78"), 10 },
                    { new Guid("3c09b722-de81-4d10-aa3c-1f7d8ea4bcd7"), 11 },
                    { new Guid("64e3c1da-2969-44cd-ac2b-18b0d5179f78"), 13 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2559fb3c-8a95-4912-b0f6-0f2da973920a"),
                column: "ConcurrencyStamp",
                value: "09efa818-4874-4203-90e3-7e10f26182d2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("38cd07af-3542-4541-8f3c-efbefd3dcaae"),
                column: "ConcurrencyStamp",
                value: "a1fbf371-537d-46d6-b28b-0529fe2d3695");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7c929f80-e14d-4063-8b76-eebc9f2c3744"),
                column: "ConcurrencyStamp",
                value: "267f65d9-492d-48ae-97f0-d98d8a04ae17");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("307309dd-f039-48b2-835d-dca03aac807b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dc2cbc9b-f34d-4bec-9e7d-b8d499abbca2", "AQAAAAEAACcQAAAAELULpm0SLkCFa2/60uNeac0PXvbyokunwayYTcxh4vF44Gujhh8JPEKA5Ii5MeNJqQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3c09b722-de81-4d10-aa3c-1f7d8ea4bcd7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0734ba57-0a04-49f6-b91f-ee079b248463", "AQAAAAEAACcQAAAAEC/Fv0TWiyhWVprvuivJEEB2DMgzO1HUrzO0QWk5QWEciAsx3ysAkBtl6yCfm6GICw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("546424cf-268f-4f68-beba-9b069b886d88"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "22f52826-7aa6-460a-9119-23f5fce62443", "AQAAAAEAACcQAAAAEApMy33fcrSHTajPLqFYAnQmyDvB77FsM0LgTkASOwZLKINoS4n/yJpDGxXCJtRxlA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("64e3c1da-2969-44cd-ac2b-18b0d5179f78"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3df58503-7a2c-47b0-8861-b03f9733558f", "AQAAAAEAACcQAAAAEGJAC53DfNPKkciLKKr+BX4seqdDArO4rB+7XjMdIMFmPJrPkU7VZnx8qcND65yNNg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f564ad91-73fa-4e3c-8965-dee864871429"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1639b434-14a4-43e3-91c0-2449a73285fb", "AQAAAAEAACcQAAAAEO638E6EEHy5Y7uHHboLf2vfHKtdFsnoYiAIAZVl++2Mtab+JlSe/3MhwykMkzaJHQ==" });

            migrationBuilder.InsertData(
                table: "Challenges",
                columns: new[] { "Id", "CategoryId", "CustomerCreatedChallengeId", "Description", "IsActive", "IsOnGoing", "PriceToWin", "Title", "WinnerId" },
                values: new object[,]
                {
                    { new Guid("a84295eb-82fd-4aac-9330-505b88e228ff"), 10, new Guid("546424cf-268f-4f68-beba-9b069b886d88"), "Calling all nature enthusiasts and photography enthusiasts alike! Embark on a visual journey of awe and wonder as we invite you to participate in our thrilling contest, \"Capturing Nature's Wonders: A Photographic Odyssey.\" Immerse yourself in the beauty of the natural world and showcase your talent by capturing the most mesmerizing moments in nature through your lens.", true, true, 200m, "Capturing Nature's Wonders: A Photographic Odyssey", null },
                    { new Guid("bd64aee7-19e4-4fc6-8db7-7388e3cc8191"), 5, new Guid("546424cf-268f-4f68-beba-9b069b886d88"), "Are you a creative mind with a flair for design? Put your artistic prowess to the test and join our exciting contest, \"Architectural Visions: Redesign Our Identity.\"\r\n\r\nAre you up for the challenge? Unleash your creativity and design a new logo that symbolizes the essence of Architecture, evoking elegance, forward-thinking concepts, and a seamless fusion of form and function.", true, true, 200m, "Architectural Visions: Redesign Our Identity", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "City", "CreatorId", "CustomerId", "Description", "IsActive", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("2700b45e-314b-4e66-b607-5f3cb9927852"), 8, "London", new Guid("3c09b722-de81-4d10-aa3c-1f7d8ea4bcd7"), new Guid("307309dd-f039-48b2-835d-dca03aac807b"), "Taking her art from life and nature, she breaks down forms simplifying and playing with the uses of light and shadows. Sometimes staying true to a likeness, which is always the starting point, but sometimes her work will take on a much more abstract nature.", true, 170m, "Ornate vase with intricate floral pattern design" },
                    { new Guid("7cee0b9a-2b1a-49e1-bfa6-f3f3e63626de"), 10, "Buenos Aires", new Guid("64e3c1da-2969-44cd-ac2b-18b0d5179f78"), new Guid("307309dd-f039-48b2-835d-dca03aac807b"), "A group of bees compete for the only female in the group. Climate change, pesticides and ever-dwindling habitat make it difficult for bees around the world to maintain their species.", true, 35m, "Bees" },
                    { new Guid("8eab24f6-7888-4aa6-9ecd-5eae3d3c110e"), 9, null, new Guid("64e3c1da-2969-44cd-ac2b-18b0d5179f78"), null, "Discover the beauty of flowers with this stunning Found a Flower Bouquet in Heavy Textured 3d Abstract Art. The intricate botanical design is both abstract and realistic, capturing the essence of nature in a unique and eye-catching way. Measuring 12x18 inches, it's the perfect size to make a stateme...", true, 120m, "Heavy Textured 3d Abstract Art Painting" },
                    { new Guid("e667cc6a-341f-4320-9fdc-3fdc60cc7fff"), 11, "Madrid", new Guid("3c09b722-de81-4d10-aa3c-1f7d8ea4bcd7"), null, "High-quality Print of a Spaceman dancing music poster flyer design element", true, 25m, "Spaceman" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CategoryId", "ChallengeId", "CreatorId", "Description", "IsActive", "Title" },
                values: new object[] { new Guid("adeacb8d-6173-46ee-9b7b-c5696d55111a"), 13, null, new Guid("64e3c1da-2969-44cd-ac2b-18b0d5179f78"), "Embark on a captivating journey through culture and history with my Oriental Tapestry Project. This creative endeavor weaves together intricate threads of Eastern traditions, vibrant colors, and timeless narratives, crafting a mesmerizing masterpiece that transports viewers to distant lands. Immerse yourself in the rich tapestry of Asia's heritage, where artistry and storytelling intertwine in a captivating display of beauty and meaning.", true, "Oriental Tapestry" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CategoryId", "ChallengeId", "CreatorId", "Description", "IsActive", "Title" },
                values: new object[] { new Guid("5d3533b4-c059-47eb-9333-ae8cc728015d"), 5, new Guid("bd64aee7-19e4-4fc6-8db7-7388e3cc8191"), new Guid("3c09b722-de81-4d10-aa3c-1f7d8ea4bcd7"), "In my design I reimagined the identity by drawing inspiration from the mesmerizing patterns and structural elements of iconic architectural landmarks worldwide. Through a harmonious blend of modern aesthetics and timeless elegance, I created a visually captivating representation that symbolizes our collective journey towards a progressive and interconnected future.", true, "Architecture Brand Identity" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CategoryId", "ChallengeId", "CreatorId", "Description", "IsActive", "Title" },
                values: new object[] { new Guid("65786e09-08fc-4bb3-bf02-665ff651c8e5"), 10, new Guid("a84295eb-82fd-4aac-9330-505b88e228ff"), new Guid("64e3c1da-2969-44cd-ac2b-18b0d5179f78"), "In Collaboration with the Zoo: Graceful Giants Unveiled - A Mesmerizing Giraffe Photoshoot\r\nStep into a world of wonder as our lens captures the mesmerizing charm of giraffes, revealing their elegant grace and captivating allure. Witness these gentle giants in their natural habitat, towering above the savanna, their majestic presence leaving an indelible mark on your heart. ", true, "Giraffe" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CategoryId", "ChallengeId", "CreatorId", "Description", "IsActive", "Title" },
                values: new object[] { new Guid("b10ce869-5388-47c4-88b8-0ebe7da7d7e3"), 10, new Guid("a84295eb-82fd-4aac-9330-505b88e228ff"), new Guid("3c09b722-de81-4d10-aa3c-1f7d8ea4bcd7"), "This endeavor seeks to encapsulate the enchanting allure of open landscapes, translating the serene expanse and delicate details of fields into a breathtaking visual experience. Immerse yourself in the essence of nature's tranquility and embrace the artistry that brings the field's beauty to life in a captivating display of creativity and awe-inspiring imagery.", true, "Fields" });

            migrationBuilder.InsertData(
                table: "Votes",
                columns: new[] { "Id", "ApplicationUserWhoVotedId", "ChallengeId", "ProjectCastOnId" },
                values: new object[] { new Guid("5d6529bb-d319-45b6-b454-3d2c68da4633"), new Guid("3c09b722-de81-4d10-aa3c-1f7d8ea4bcd7"), new Guid("a84295eb-82fd-4aac-9330-505b88e228ff"), new Guid("65786e09-08fc-4bb3-bf02-665ff651c8e5") });

            migrationBuilder.InsertData(
                table: "Votes",
                columns: new[] { "Id", "ApplicationUserWhoVotedId", "ChallengeId", "ProjectCastOnId" },
                values: new object[] { new Guid("953a5321-ee41-4397-9736-3972caa5aca4"), new Guid("64e3c1da-2969-44cd-ac2b-18b0d5179f78"), new Guid("bd64aee7-19e4-4fc6-8db7-7388e3cc8191"), new Guid("5d3533b4-c059-47eb-9333-ae8cc728015d") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationUserPPCategories",
                keyColumns: new[] { "ApplicationUserId", "PPCategoryId" },
                keyValues: new object[] { new Guid("3c09b722-de81-4d10-aa3c-1f7d8ea4bcd7"), 5 });

            migrationBuilder.DeleteData(
                table: "ApplicationUserPPCategories",
                keyColumns: new[] { "ApplicationUserId", "PPCategoryId" },
                keyValues: new object[] { new Guid("3c09b722-de81-4d10-aa3c-1f7d8ea4bcd7"), 8 });

            migrationBuilder.DeleteData(
                table: "ApplicationUserPPCategories",
                keyColumns: new[] { "ApplicationUserId", "PPCategoryId" },
                keyValues: new object[] { new Guid("64e3c1da-2969-44cd-ac2b-18b0d5179f78"), 9 });

            migrationBuilder.DeleteData(
                table: "ApplicationUserPPCategories",
                keyColumns: new[] { "ApplicationUserId", "PPCategoryId" },
                keyValues: new object[] { new Guid("64e3c1da-2969-44cd-ac2b-18b0d5179f78"), 10 });

            migrationBuilder.DeleteData(
                table: "ApplicationUserPPCategories",
                keyColumns: new[] { "ApplicationUserId", "PPCategoryId" },
                keyValues: new object[] { new Guid("3c09b722-de81-4d10-aa3c-1f7d8ea4bcd7"), 11 });

            migrationBuilder.DeleteData(
                table: "ApplicationUserPPCategories",
                keyColumns: new[] { "ApplicationUserId", "PPCategoryId" },
                keyValues: new object[] { new Guid("64e3c1da-2969-44cd-ac2b-18b0d5179f78"), 13 });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2700b45e-314b-4e66-b607-5f3cb9927852"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7cee0b9a-2b1a-49e1-bfa6-f3f3e63626de"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8eab24f6-7888-4aa6-9ecd-5eae3d3c110e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e667cc6a-341f-4320-9fdc-3fdc60cc7fff"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("adeacb8d-6173-46ee-9b7b-c5696d55111a"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("b10ce869-5388-47c4-88b8-0ebe7da7d7e3"));

            migrationBuilder.DeleteData(
                table: "Votes",
                keyColumn: "Id",
                keyValue: new Guid("5d6529bb-d319-45b6-b454-3d2c68da4633"));

            migrationBuilder.DeleteData(
                table: "Votes",
                keyColumn: "Id",
                keyValue: new Guid("953a5321-ee41-4397-9736-3972caa5aca4"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("5d3533b4-c059-47eb-9333-ae8cc728015d"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("65786e09-08fc-4bb3-bf02-665ff651c8e5"));

            migrationBuilder.DeleteData(
                table: "Challenges",
                keyColumn: "Id",
                keyValue: new Guid("a84295eb-82fd-4aac-9330-505b88e228ff"));

            migrationBuilder.DeleteData(
                table: "Challenges",
                keyColumn: "Id",
                keyValue: new Guid("bd64aee7-19e4-4fc6-8db7-7388e3cc8191"));

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Challenges");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Projects",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Challenges",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhotoId",
                table: "Challenges",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2559fb3c-8a95-4912-b0f6-0f2da973920a"),
                column: "ConcurrencyStamp",
                value: "a1d17d8d-53b4-44ca-beb0-df5e4906ad35");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("38cd07af-3542-4541-8f3c-efbefd3dcaae"),
                column: "ConcurrencyStamp",
                value: "efb2097b-b294-4023-bfc1-9ccdf622d8c0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7c929f80-e14d-4063-8b76-eebc9f2c3744"),
                column: "ConcurrencyStamp",
                value: "cb47610d-046e-451a-81cd-485e1cbeb379");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("307309dd-f039-48b2-835d-dca03aac807b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "17d38640-e640-4281-90c6-9b2b9c9ca472", "AQAAAAEAACcQAAAAEJnWxXBO4UKiUVOzAObEzL1SzwcId8IFKE2mpdTk+BtLwBIbidjzIoR8HlQ4DsiRwQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3c09b722-de81-4d10-aa3c-1f7d8ea4bcd7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7b31fcce-f115-4b11-af3d-8aa93e9ebcd2", "AQAAAAEAACcQAAAAEM2VLDpvKEZQDJUZqI4/EoyDWRpp+hfCQnPySkV/TBUIiM6xrxfEO8GXPaRIMYmjBA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("546424cf-268f-4f68-beba-9b069b886d88"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "31324b70-48d8-4ffa-b6e5-1d437407615e", "AQAAAAEAACcQAAAAECDS+V7weHJxSkF0Ud23AH1uyCPv3pKaEfutQV+NvfDtj5N6WamPUdsWFd5IImkR7A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("64e3c1da-2969-44cd-ac2b-18b0d5179f78"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eac2d247-4bf9-49f4-bae1-f0e7ad6bfb24", "AQAAAAEAACcQAAAAECVRJG8Tgn0epEpZccTYLpC4U5J7MRGz3JWL6UpIUbhVzB1uCKYzcpzU8u161/nu7A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f564ad91-73fa-4e3c-8965-dee864871429"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "aff4a8d3-9094-42cd-bbbe-fb1a907c6670", "AQAAAAEAACcQAAAAEH7+RM3EF/rC9GgGZpTyfI9osOG6SmdrWT/t/37xHg3Y5GdywiilW6oYhM89Or5rVg==" });
        }
    }
}
