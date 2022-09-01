using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebGame.Database.Migrations
{
    public partial class SkillsRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeroClass",
                table: "Ammunition");

            migrationBuilder.DropColumn(
                name: "Race",
                table: "Ammunition");

            migrationBuilder.AddColumn<Guid>(
                name: "RaceId",
                table: "Ammunition",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SpecializationId",
                table: "Ammunition",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RaceId",
                table: "Ammunition");

            migrationBuilder.DropColumn(
                name: "SpecializationId",
                table: "Ammunition");

            migrationBuilder.AddColumn<string>(
                name: "HeroClass",
                table: "Ammunition",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Race",
                table: "Ammunition",
                type: "text",
                nullable: true);
        }
    }
}
