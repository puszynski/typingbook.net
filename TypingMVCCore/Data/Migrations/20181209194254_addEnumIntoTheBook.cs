using Microsoft.EntityFrameworkCore.Migrations;

namespace TypingMVCCore.Data.Migrations
{
    public partial class addEnumIntoTheBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookGenre",
                table: "Book",
                type: "nvarchar(24)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookGenre",
                table: "Book");
        }
    }
}
