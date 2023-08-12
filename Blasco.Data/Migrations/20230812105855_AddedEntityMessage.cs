using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blasco.Data.Migrations
{
    public partial class AddedEntityMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("92cd8068-4155-48d7-8a6d-1c1ea6e7f2c5"));

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2559fb3c-8a95-4912-b0f6-0f2da973920a"),
                column: "ConcurrencyStamp",
                value: "0a6ea06b-a7e5-429d-b623-6957f164ee7c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("38cd07af-3542-4541-8f3c-efbefd3dcaae"),
                column: "ConcurrencyStamp",
                value: "1f3c757b-48a3-4b42-81d7-1c8ec2180038");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7c929f80-e14d-4063-8b76-eebc9f2c3744"),
                column: "ConcurrencyStamp",
                value: "8d17515d-6719-4cd7-b74a-05b12c77e079");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("307309dd-f039-48b2-835d-dca03aac807b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d070b5e-0d57-4f50-887d-cd23940f4d3d", "AQAAAAEAACcQAAAAEGThFJrT63K1oz3fpmahrTmtS2Wt32J4aC6QUyEmTObIcc+GxhLrODwVywzGTM9uEQ==", "A30F2B35-81BF-4BC4-B568-466C7B7595B9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3c09b722-de81-4d10-aa3c-1f7d8ea4bcd7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db64719e-524f-49f5-a656-280d3ec87e43", "AQAAAAEAACcQAAAAEKlCCxVNec+RxAW4p9L3Nu18Uh2FE/6Tas3UnDBSwIQKmAXcmK29s92039jFnDB6dg==", "F864D9D1-B3E2-470C-B3A0-EFFA770158D5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("546424cf-268f-4f68-beba-9b069b886d88"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad170965-61ef-4a0e-99dc-73ed9d84c27b", "AQAAAAEAACcQAAAAEGetcD638pPvuHZuTN9SLTdvxgfOJqkZ7ILjQ9gZQeo3BxYGwNPnpWsVPPlbW6J2ww==", "5873FD71-BA17-498C-92E0-C35D6478EBBB" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("64e3c1da-2969-44cd-ac2b-18b0d5179f78"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f653e5b9-e0db-467d-9b5f-195bfc4a12bd", "AQAAAAEAACcQAAAAEHeAcc9f8VInI5wfcEO5UZ3GLQNubbK2+J4/HKcTfvD/GfWiCTpyaJYIxo4vEVu/nQ==", "328B8163-9903-4024-9377-C247CB7F98FA" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f564ad91-73fa-4e3c-8965-dee864871429"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8697ba19-e7ce-437a-9776-8bab419a0138", "AQAAAAEAACcQAAAAELTL5eKKiRe2IvPuYR0SteSDHdm3ubGoPFhvhICdtKpcVtd3Fg41/2csYQGYqCXCZw==", "6E4222F0-0A2A-4F51-AB27-04A009ED90FD" });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverId",
                table: "Messages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2559fb3c-8a95-4912-b0f6-0f2da973920a"),
                column: "ConcurrencyStamp",
                value: "50e16301-5b6f-4a12-98ae-d32b5b40acf6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("38cd07af-3542-4541-8f3c-efbefd3dcaae"),
                column: "ConcurrencyStamp",
                value: "f93a0b33-a592-4b45-98b9-43d5ac310f71");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7c929f80-e14d-4063-8b76-eebc9f2c3744"),
                column: "ConcurrencyStamp",
                value: "c80b0868-4ec6-4c43-9dfd-f4dfb20cdf70");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("307309dd-f039-48b2-835d-dca03aac807b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f78e998-503d-4771-a64c-d66d8179957d", "AQAAAAEAACcQAAAAENfccAdYoQdoRoax9E8inrbNYsJv1hVYYdH9Z5Uk+nGPsopHW+C4xaLwDnuNgVj5oQ==", "D4168115-B36A-40A9-8752-4693BEB1660C" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3c09b722-de81-4d10-aa3c-1f7d8ea4bcd7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5bb1fb54-3cd7-4dad-b2ed-7417b231a8df", "AQAAAAEAACcQAAAAEDU/2Pw3Zooe0Tmv/mjv0uMTmU/KMI5Z/onUwEynaU0Skbf/o0keUhh/HxxFpC4oLQ==", "ECB32B29-1F5D-4350-B622-B5BB93E44A23" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("546424cf-268f-4f68-beba-9b069b886d88"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5dd35f0-e01e-4b8d-8e6a-ed6cf5711430", "AQAAAAEAACcQAAAAELBhHzVP86aB8Gb73r9nsL+tSUTisgp35tT+8tzVT1tPyTBFyKbssjRNmbnaLWztIQ==", "98AE1C08-FF5D-4829-A974-2011EC46F801" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("64e3c1da-2969-44cd-ac2b-18b0d5179f78"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba8093f2-8f16-4e32-8039-814f76833a96", "AQAAAAEAACcQAAAAEO27GAb5QumhC3KzpknArGqyfkrIdMxDIvYmpL+nl7oBFW5zaLGTk8gn9284OwSGEQ==", "D7BA4089-38F1-44C2-85A4-FFA63BCDC5ED" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f564ad91-73fa-4e3c-8965-dee864871429"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f416fb8e-cd98-437c-b647-7964543ea40f", "AQAAAAEAACcQAAAAEKWDFmfRxoPgMpqANc5iWG1xD1gDLZBTxzmf+0dF9co/1YdejdA98NE6fA73ewEW2g==", "EDBFE8CB-1D4D-4397-8C67-72A91D240BC9" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CustomerTypeId", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Pseudonym", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("92cd8068-4155-48d7-8a6d-1c1ea6e7f2c5"), 0, "84f636e9-e2e3-4ffa-a096-5ab48a882d29", null, "testFifthH@test.com", false, "TestFifthh", true, "Testfifthovv", true, null, "TESTFIFTHH@TEST.COM", "TESTFIFTHH@TEST.COM", "AQAAAAEAACcQAAAAEKgFKaLnFL1nNc7DsPQTIIt0GTyQjIiVm8yZlve/yynAcw7O04qf6f6EQ7k9deImpA==", null, false, "tastFifthh", "FD32941E-175A-4DAA-969F-CE74F3C8FA41", false, "testFifthh@test.com" });
        }
    }
}
