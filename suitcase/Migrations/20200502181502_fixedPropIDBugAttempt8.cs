using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace suitcase.Migrations
{
    public partial class fixedPropIDBugAttempt8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActProp_Props_PropsId",
                table: "ActProp");

            migrationBuilder.DropIndex(
                name: "IX_ActProp_PropsId",
                table: "ActProp");

            migrationBuilder.DropColumn(
                name: "PropsId",
                table: "ActProp");

            migrationBuilder.AddForeignKey(
                name: "FK_ActProp_Props_PropId",
                table: "ActProp",
                column: "PropId",
                principalTable: "Props",
                principalColumn: "PropId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActProp_Props_PropId",
                table: "ActProp");

            migrationBuilder.AddColumn<Guid>(
                name: "PropsId",
                table: "ActProp",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActProp_PropsId",
                table: "ActProp",
                column: "PropsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActProp_Props_PropsId",
                table: "ActProp",
                column: "PropsId",
                principalTable: "Props",
                principalColumn: "PropId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
