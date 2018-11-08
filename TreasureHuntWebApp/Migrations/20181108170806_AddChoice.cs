using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TreasureHuntWebApp.Migrations
{
    public partial class AddChoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Choice",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Question = table.Column<string>(nullable: true),
                    Choice1 = table.Column<string>(nullable: true),
                    Result1 = table.Column<string>(nullable: true),
                    Choice2 = table.Column<string>(nullable: true),
                    Result2 = table.Column<string>(nullable: true),
                    Choice3 = table.Column<string>(nullable: true),
                    Result3 = table.Column<string>(nullable: true),
                    CorrectAnswer = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choice", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Choice");
        }
    }
}
