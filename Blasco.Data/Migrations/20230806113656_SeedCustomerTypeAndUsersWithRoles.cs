using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blasco.Data.Migrations
{
    public partial class SeedCustomerTypeAndUsersWithRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2559fb3c-8a95-4912-b0f6-0f2da973920a"), "a1d17d8d-53b4-44ca-beb0-df5e4906ad35", "Customer", "CUSTOMER" },
                    { new Guid("38cd07af-3542-4541-8f3c-efbefd3dcaae"), "efb2097b-b294-4023-bfc1-9ccdf622d8c0", "Creator", "CREATOR" },
                    { new Guid("7c929f80-e14d-4063-8b76-eebc9f2c3744"), "cb47610d-046e-451a-81cd-485e1cbeb379", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CustomerTypeId", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Pseudonym", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("3c09b722-de81-4d10-aa3c-1f7d8ea4bcd7"), 0, "7b31fcce-f115-4b11-af3d-8aa93e9ebcd2", null, "secondCreator@creator.com", false, "Second", true, "Creator", true, null, "SECONDCREATOR@CREATOR.COM", "SECONDCREATOR", "AQAAAAEAACcQAAAAEM2VLDpvKEZQDJUZqI4/EoyDWRpp+hfCQnPySkV/TBUIiM6xrxfEO8GXPaRIMYmjBA==", null, false, "secondPseudonym", null, false, "SecondCreator" },
                    { new Guid("64e3c1da-2969-44cd-ac2b-18b0d5179f78"), 0, "eac2d247-4bf9-49f4-bae1-f0e7ad6bfb24", null, "firstCreator@creator.com", false, "First", true, "Creator", true, null, "FIRSTCREATOR@CREATOR.COM", "FIRSTCREATOR", "AQAAAAEAACcQAAAAECVRJG8Tgn0epEpZccTYLpC4U5J7MRGz3JWL6UpIUbhVzB1uCKYzcpzU8u161/nu7A==", null, false, "firstPseudonym", null, false, "FirstCreator" },
                    { new Guid("f564ad91-73fa-4e3c-8965-dee864871429"), 0, "aff4a8d3-9094-42cd-bbbe-fb1a907c6670", null, "admin@blasco.com", false, "Admin", true, "Admin", true, null, "ADMIN@BLASCO.COM", "ADMIN", "AQAAAAEAACcQAAAAEH7+RM3EF/rC9GgGZpTyfI9osOG6SmdrWT/t/37xHg3Y5GdywiilW6oYhM89Or5rVg==", null, false, null, null, false, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "CustomerTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Private Customer" },
                    { 2, "Freelancer" },
                    { 3, "Buisness" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("38cd07af-3542-4541-8f3c-efbefd3dcaae"), new Guid("3c09b722-de81-4d10-aa3c-1f7d8ea4bcd7") },
                    { new Guid("38cd07af-3542-4541-8f3c-efbefd3dcaae"), new Guid("64e3c1da-2969-44cd-ac2b-18b0d5179f78") },
                    { new Guid("7c929f80-e14d-4063-8b76-eebc9f2c3744"), new Guid("f564ad91-73fa-4e3c-8965-dee864871429") }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CustomerTypeId", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Pseudonym", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("307309dd-f039-48b2-835d-dca03aac807b"), 0, "17d38640-e640-4281-90c6-9b2b9c9ca472", 2, "firstCustomer@customer.com", false, "First", true, "Customer", true, null, "FIRSTCUSTOMER@CUSTOMER.COM", "FIRSTCUSTOMER", "AQAAAAEAACcQAAAAEJnWxXBO4UKiUVOzAObEzL1SzwcId8IFKE2mpdTk+BtLwBIbidjzIoR8HlQ4DsiRwQ==", null, false, null, null, false, "FirstCustomer" },
                    { new Guid("546424cf-268f-4f68-beba-9b069b886d88"), 0, "31324b70-48d8-4ffa-b6e5-1d437407615e", 1, "secondCustomer@customer.com", false, "Second", true, "Customer", true, null, "SECONDCUSTOMER@CUSTOMER.COM", "SECONDCUSTOMER", "AQAAAAEAACcQAAAAECDS+V7weHJxSkF0Ud23AH1uyCPv3pKaEfutQV+NvfDtj5N6WamPUdsWFd5IImkR7A==", null, false, null, null, false, "SecondCustomer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("2559fb3c-8a95-4912-b0f6-0f2da973920a"), new Guid("307309dd-f039-48b2-835d-dca03aac807b") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("2559fb3c-8a95-4912-b0f6-0f2da973920a"), new Guid("546424cf-268f-4f68-beba-9b069b886d88") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2559fb3c-8a95-4912-b0f6-0f2da973920a"), new Guid("307309dd-f039-48b2-835d-dca03aac807b") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("38cd07af-3542-4541-8f3c-efbefd3dcaae"), new Guid("3c09b722-de81-4d10-aa3c-1f7d8ea4bcd7") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2559fb3c-8a95-4912-b0f6-0f2da973920a"), new Guid("546424cf-268f-4f68-beba-9b069b886d88") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("38cd07af-3542-4541-8f3c-efbefd3dcaae"), new Guid("64e3c1da-2969-44cd-ac2b-18b0d5179f78") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7c929f80-e14d-4063-8b76-eebc9f2c3744"), new Guid("f564ad91-73fa-4e3c-8965-dee864871429") });

            migrationBuilder.DeleteData(
                table: "CustomerTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2559fb3c-8a95-4912-b0f6-0f2da973920a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("38cd07af-3542-4541-8f3c-efbefd3dcaae"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7c929f80-e14d-4063-8b76-eebc9f2c3744"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("307309dd-f039-48b2-835d-dca03aac807b"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3c09b722-de81-4d10-aa3c-1f7d8ea4bcd7"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("546424cf-268f-4f68-beba-9b069b886d88"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("64e3c1da-2969-44cd-ac2b-18b0d5179f78"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f564ad91-73fa-4e3c-8965-dee864871429"));

            migrationBuilder.DeleteData(
                table: "CustomerTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CustomerTypes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
