using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blasco.Data.Migrations
{
    public partial class AddedMappingTableForAppUserAndPPCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserProductProjectCategory");

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

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserPPCategories_ApplicationUserId",
                table: "ApplicationUserPPCategories",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserPPCategories");

            migrationBuilder.CreateTable(
                name: "ApplicationUserProductProjectCategory",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    CreatorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserProductProjectCategory", x => new { x.CategoriesId, x.CreatorsId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserProductProjectCategory_AspNetUsers_CreatorsId",
                        column: x => x.CreatorsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserProductProjectCategory_ProductProjectCategories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "ProductProjectCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserProductProjectCategory_CreatorsId",
                table: "ApplicationUserProductProjectCategory",
                column: "CreatorsId");
        }
    }
}
