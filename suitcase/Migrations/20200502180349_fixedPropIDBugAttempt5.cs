using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace suitcase.Migrations
{
    public partial class fixedPropIDBugAttempt5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActProp_Props_Props.Id",
                table: "ActProp");

            migrationBuilder.DropIndex(
                name: "IX_ActProp_Props.Id",
                table: "ActProp");

            migrationBuilder.DropColumn(
                name: "PropId1",
                table: "Props");

            migrationBuilder.DropColumn(
                name: "Props.Id",
                table: "ActProp");

            migrationBuilder.AddColumn<Guid>(
                name: "PropsId",
                table: "ActProp",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "PropId1",
                table: "Props",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Props.Id",
                table: "ActProp",
                type: "TEXT",
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
    }
}
