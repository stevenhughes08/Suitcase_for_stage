using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace suitcase.Migrations
{
    public partial class fixedPropIDBugAttempt2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActProp_Props_PropId",
                table: "ActProp");

            migrationBuilder.AddColumn<Guid>(
                name: "Props.Id",
                table: "ActProp",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActProp_Props.Id",
                table: "ActProp",
                column: "Props.Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActProp_Props_Props.Id",
                table: "ActProp",
                column: "Props.Id",
                principalTable: "Props",
                principalColumn: "PropId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActProp_Props_Props.Id",
                table: "ActProp");

            migrationBuilder.DropIndex(
                name: "IX_ActProp_Props.Id",
                table: "ActProp");

            migrationBuilder.DropColumn(
                name: "Props.Id",
                table: "ActProp");

            migrationBuilder.AddForeignKey(
                name: "FK_ActProp_Props_PropId",
                table: "ActProp",
                column: "PropId",
                principalTable: "Props",
                principalColumn: "PropId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
