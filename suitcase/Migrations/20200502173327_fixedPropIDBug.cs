using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace suitcase.Migrations
{
    public partial class fixedPropIDBug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActProp_Props_PropId",
                table: "ActProp");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Props",
                table: "Props");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Props");

            migrationBuilder.AddColumn<Guid>(
                name: "PropId1",
                table: "Props",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Props",
                table: "Props",
                column: "PropId");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Props",
                table: "Props");

            migrationBuilder.DropColumn(
                name: "PropId1",
                table: "Props");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Props",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Props",
                table: "Props",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActProp_Props_PropId",
                table: "ActProp",
                column: "PropId",
                principalTable: "Props",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
