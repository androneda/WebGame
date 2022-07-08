using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebGame.Database.Migrations
{
    public partial class initAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ammunition",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Race = table.Column<string>(type: "text", nullable: true),
                    HeroClass = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ammunition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Race = table.Column<string>(type: "text", nullable: true),
                    HeroClass = table.Column<string>(type: "text", nullable: true),
                    Skills = table.Column<string>(type: "text", nullable: true),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    HeadId = table.Column<Guid>(type: "uuid", nullable: false),
                    BodyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Sex = table.Column<bool>(type: "boolean", nullable: false),
                    WeaponId = table.Column<Guid>(type: "uuid", nullable: false),
                    HelmetId = table.Column<Guid>(type: "uuid", nullable: false),
                    SecondWeaponId = table.Column<Guid>(type: "uuid", nullable: false),
                    ShowHelmet = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ammunition");

            migrationBuilder.DropTable(
                name: "Heroes");
        }
    }
}
