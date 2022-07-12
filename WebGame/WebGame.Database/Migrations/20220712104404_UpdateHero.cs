using Microsoft.EntityFrameworkCore.Migrations;

namespace WebGame.Database.Migrations
{
    public partial class UpdateHero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HeroClass",
                table: "Heroes",
                newName: "Specialization");

            migrationBuilder.AddColumn<int>(
                name: "ActionPoints",
                table: "Heroes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "X",
                table: "Heroes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Y",
                table: "Heroes",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionPoints",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "X",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "Y",
                table: "Heroes");

            migrationBuilder.RenameColumn(
                name: "Specialization",
                table: "Heroes",
                newName: "HeroClass");
        }
    }
}
