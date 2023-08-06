using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blasco.Data.Migrations
{
    public partial class AddedToChallengeEndDateCustomerAndVotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ChallengeId",
                table: "Votes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerCreatedChallengeId",
                table: "Challenges",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Challenges",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Votes_ChallengeId",
                table: "Votes",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_CustomerCreatedChallengeId",
                table: "Challenges",
                column: "CustomerCreatedChallengeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Challenges_AspNetUsers_CustomerCreatedChallengeId",
                table: "Challenges",
                column: "CustomerCreatedChallengeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Challenges_ChallengeId",
                table: "Votes",
                column: "ChallengeId",
                principalTable: "Challenges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Challenges_AspNetUsers_CustomerCreatedChallengeId",
                table: "Challenges");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Challenges_ChallengeId",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votes_ChallengeId",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Challenges_CustomerCreatedChallengeId",
                table: "Challenges");

            migrationBuilder.DropColumn(
                name: "ChallengeId",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "CustomerCreatedChallengeId",
                table: "Challenges");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Challenges");
        }
    }
}
