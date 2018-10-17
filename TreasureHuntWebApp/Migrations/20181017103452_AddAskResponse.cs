using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TreasureHuntWebApp.Migrations
{
    public partial class AddAskResponse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnswerIndex",
                table: "Question",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClueIndex",
                table: "Question",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AskResponse",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Question = table.Column<string>(nullable: true),
                    Response = table.Column<string>(nullable: true),
                    AskDate = table.Column<DateTime>(nullable: false),
                    AskType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AskResponse", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AskResponse");

            migrationBuilder.DropColumn(
                name: "AnswerIndex",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "ClueIndex",
                table: "Question");
        }
    }
}
