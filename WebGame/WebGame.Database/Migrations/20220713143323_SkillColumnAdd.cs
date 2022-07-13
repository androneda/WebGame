using Microsoft.EntityFrameworkCore.Migrations;

namespace WebGame.Database.Migrations
{
    public partial class SkillColumnAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Skills",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Skills");
        }
    }
}
