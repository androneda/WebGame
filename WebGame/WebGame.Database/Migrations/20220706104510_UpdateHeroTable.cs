using Microsoft.EntityFrameworkCore.Migrations;

namespace WebGame.Database.Migrations
{
    public partial class UpdateHeroTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HeroClass",
                table: "Heroes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Heroes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Race",
                table: "Heroes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ShowHelmet",
                table: "Heroes",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeroClass",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "Race",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "ShowHelmet",
                table: "Heroes");
        }
    }
}
