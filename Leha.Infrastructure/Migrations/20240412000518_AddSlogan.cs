using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leha.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSlogan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SloganAr",
                table: "Companies",
                type: "Nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SloganEn",
                table: "Companies",
                type: "Nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SloganAr",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "SloganEn",
                table: "Companies");
        }
    }
}
