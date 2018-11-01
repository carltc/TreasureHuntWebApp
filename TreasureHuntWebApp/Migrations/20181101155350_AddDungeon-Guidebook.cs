using Microsoft.EntityFrameworkCore.Migrations;

namespace TreasureHuntWebApp.Migrations
{
    public partial class AddDungeonGuidebook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Guidebook",
                table: "Dungeon",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Guidebook",
                table: "Dungeon");
        }
    }
}
