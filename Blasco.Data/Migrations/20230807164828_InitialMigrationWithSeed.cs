using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blasco.Data.Migrations
{
    public partial class InitialMigrationWithSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductProjectCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProjectCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Pseudonym = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CustomerTypeId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_CustomerTypes_CustomerTypeId",
                        column: x => x.CustomerTypeId,
                        principalTable: "CustomerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserPPCategories",
                columns: table => new
                {
                    PPCategoryId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserPPCategories", x => new { x.PPCategoryId, x.ApplicationUserId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserPPCategories_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicationUserPPCategories_ProductProjectCategories_PPCategoryId",
                        column: x => x.PPCategoryId,
                        principalTable: "ProductProjectCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Challenges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CustomerCreatedChallengeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "DATEADD(month, +2, GETDATE())"),
                    PriceToWin = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsOnGoing = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    WinnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Challenges_AspNetUsers_CustomerCreatedChallengeId",
                        column: x => x.CustomerCreatedChallengeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Challenges_AspNetUsers_WinnerId",
                        column: x => x.WinnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Challenges_ProductProjectCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductProjectCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: true),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_ProductProjectCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductProjectCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChallengeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_Challenges_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_ProductProjectCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductProjectCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectCastOnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChallengeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        name: "FK_Votes_Challenges_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Votes_Projects_ProjectCastOnId",
                        column: x => x.ProjectCastOnId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2559fb3c-8a95-4912-b0f6-0f2da973920a"), "50e16301-5b6f-4a12-98ae-d32b5b40acf6", "Customer", "CUSTOMER" },
                    { new Guid("38cd07af-3542-4541-8f3c-efbefd3dcaae"), "f93a0b33-a592-4b45-98b9-43d5ac310f71", "Creator", "CREATOR" },
                    { new Guid("7c929f80-e14d-4063-8b76-eebc9f2c3744"), "c80b0868-4ec6-4c43-9dfd-f4dfb20cdf70", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CustomerTypeId", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Pseudonym", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("3c09b722-de81-4d10-aa3c-1f7d8ea4bcd7"), 0, "5bb1fb54-3cd7-4dad-b2ed-7417b231a8df", null, "secondCreator@creator.com", false, "Second", true, "Creator", true, null, "SECONDCREATOR@CREATOR.COM", "SECONDCREATOR@CREATOR.COM", "AQAAAAEAACcQAAAAEDU/2Pw3Zooe0Tmv/mjv0uMTmU/KMI5Z/onUwEynaU0Skbf/o0keUhh/HxxFpC4oLQ==", null, false, "secondPseudonym", "ECB32B29-1F5D-4350-B622-B5BB93E44A23", false, "secondCreator@creator.com" },
                    { new Guid("64e3c1da-2969-44cd-ac2b-18b0d5179f78"), 0, "ba8093f2-8f16-4e32-8039-814f76833a96", null, "firstCreator@creator.com", false, "First", true, "Creator", true, null, "FIRSTCREATOR@CREATOR.COM", "FIRSTCREATOR@CREATOR.COM", "AQAAAAEAACcQAAAAEO27GAb5QumhC3KzpknArGqyfkrIdMxDIvYmpL+nl7oBFW5zaLGTk8gn9284OwSGEQ==", null, false, "firstPseudonym", "D7BA4089-38F1-44C2-85A4-FFA63BCDC5ED", false, "firstCreator@creator.com" },
                    { new Guid("92cd8068-4155-48d7-8a6d-1c1ea6e7f2c5"), 0, "84f636e9-e2e3-4ffa-a096-5ab48a882d29", null, "testFifthH@test.com", false, "TestFifthh", true, "Testfifthovv", true, null, "TESTFIFTHH@TEST.COM", "TESTFIFTHH@TEST.COM", "AQAAAAEAACcQAAAAEKgFKaLnFL1nNc7DsPQTIIt0GTyQjIiVm8yZlve/yynAcw7O04qf6f6EQ7k9deImpA==", null, false, "tastFifthh", "FD32941E-175A-4DAA-969F-CE74F3C8FA41", false, "testFifthh@test.com" },
                    { new Guid("f564ad91-73fa-4e3c-8965-dee864871429"), 0, "f416fb8e-cd98-437c-b647-7964543ea40f", null, "admin@blasco.com", false, "Admin", true, "Admin", true, null, "ADMIN@BLASCO.COM", "ADMIN@BLASCO.COM", "AQAAAAEAACcQAAAAEKWDFmfRxoPgMpqANc5iWG1xD1gDLZBTxzmf+0dF9co/1YdejdA98NE6fA73ewEW2g==", null, false, null, "EDBFE8CB-1D4D-4397-8C67-72A91D240BC9", false, "admin@blasco.com" }
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
                table: "ProductProjectCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Animation" },
                    { 2, "Architectural plan" },
                    { 3, "Furniture" },
                    { 4, "Glass sculpture" },
                    { 5, "Graphic design" },
                    { 6, "Illustration" },
                    { 7, "Interior design" },
                    { 8, "Metal designs" },
                    { 9, "Painting" },
                    { 10, "Photograph" },
                    { 11, "Print" },
                    { 12, "Sculpture" },
                    { 13, "Tapestry" },
                    { 14, "Video" }
                });

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
                    { new Guid("307309dd-f039-48b2-835d-dca03aac807b"), 0, "2f78e998-503d-4771-a64c-d66d8179957d", 2, "firstCustomer@customer.com", false, "First", true, "Customer", true, null, "FIRSTCUSTOMER@CUSTOMER.COM", "FIRSTCUSTOMER@CUSTOMER.COM", "AQAAAAEAACcQAAAAENfccAdYoQdoRoax9E8inrbNYsJv1hVYYdH9Z5Uk+nGPsopHW+C4xaLwDnuNgVj5oQ==", null, false, null, "D4168115-B36A-40A9-8752-4693BEB1660C", false, "firstCustomer@customer.com" },
                    { new Guid("546424cf-268f-4f68-beba-9b069b886d88"), 0, "c5dd35f0-e01e-4b8d-8e6a-ed6cf5711430", 1, "secondCustomer@customer.com", false, "Second", true, "Customer", true, null, "SECONDCUSTOMER@CUSTOMER.COM", "SECONDCUSTOMER@CUSTOMER.COM", "AQAAAAEAACcQAAAAELBhHzVP86aB8Gb73r9nsL+tSUTisgp35tT+8tzVT1tPyTBFyKbssjRNmbnaLWztIQ==", null, false, null, "98AE1C08-FF5D-4829-A974-2011EC46F801", false, "secondCustomer@customer.com" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "City", "CreatorId", "CustomerId", "Description", "IsActive", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("8eab24f6-7888-4aa6-9ecd-5eae3d3c110e"), 9, null, new Guid("64e3c1da-2969-44cd-ac2b-18b0d5179f78"), null, "Discover the beauty of flowers with this stunning Found a Flower Bouquet in Heavy Textured 3d Abstract Art. The intricate botanical design is both abstract and realistic, capturing the essence of nature in a unique and eye-catching way. Measuring 12x18 inches, it's the perfect size to make a stateme...", true, 120m, "Heavy Textured 3d Abstract Art Painting" },
                    { new Guid("e667cc6a-341f-4320-9fdc-3fdc60cc7fff"), 11, "Madrid", new Guid("3c09b722-de81-4d10-aa3c-1f7d8ea4bcd7"), null, "High-quality Print of a Spaceman dancing music poster flyer design element", true, 25m, "Spaceman" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CategoryId", "ChallengeId", "CreatorId", "Description", "IsActive", "Title" },
                values: new object[] { new Guid("adeacb8d-6173-46ee-9b7b-c5696d55111a"), 13, null, new Guid("64e3c1da-2969-44cd-ac2b-18b0d5179f78"), "Embark on a captivating journey through culture and history with my Oriental Tapestry Project. This creative endeavor weaves together intricate threads of Eastern traditions, vibrant colors, and timeless narratives, crafting a mesmerizing masterpiece that transports viewers to distant lands. Immerse yourself in the rich tapestry of Asia's heritage, where artistry and storytelling intertwine in a captivating display of beauty and meaning.", true, "Oriental Tapestry" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("2559fb3c-8a95-4912-b0f6-0f2da973920a"), new Guid("307309dd-f039-48b2-835d-dca03aac807b") },
                    { new Guid("2559fb3c-8a95-4912-b0f6-0f2da973920a"), new Guid("546424cf-268f-4f68-beba-9b069b886d88") }
                });

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
                    { new Guid("7cee0b9a-2b1a-49e1-bfa6-f3f3e63626de"), 10, "Buenos Aires", new Guid("64e3c1da-2969-44cd-ac2b-18b0d5179f78"), new Guid("307309dd-f039-48b2-835d-dca03aac807b"), "A group of bees compete for the only female in the group. Climate change, pesticides and ever-dwindling habitat make it difficult for bees around the world to maintain their species.", true, 35m, "Bees" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserPPCategories_ApplicationUserId",
                table: "ApplicationUserPPCategories",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CustomerTypeId",
                table: "AspNetUsers",
                column: "CustomerTypeId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_CategoryId",
                table: "Challenges",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_CustomerCreatedChallengeId",
                table: "Challenges",
                column: "CustomerCreatedChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_WinnerId",
                table: "Challenges",
                column: "WinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatorId",
                table: "Products",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CustomerId",
                table: "Products",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CategoryId",
                table: "Projects",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ChallengeId",
                table: "Projects",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CreatorId",
                table: "Projects",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_ApplicationUserWhoVotedId",
                table: "Votes",
                column: "ApplicationUserWhoVotedId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_ChallengeId",
                table: "Votes",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_ProjectCastOnId",
                table: "Votes",
                column: "ProjectCastOnId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserPPCategories");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Challenges");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ProductProjectCategories");

            migrationBuilder.DropTable(
                name: "CustomerTypes");
        }
    }
}
