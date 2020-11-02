using Microsoft.EntityFrameworkCore.Migrations;

namespace Cryptocop.Software.API.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "County",
                table: "Addresses");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Addresses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Addresses");

            migrationBuilder.AddColumn<string>(
                name: "County",
                table: "Addresses",
                type: "text",
                nullable: true);
        }
    }
}
