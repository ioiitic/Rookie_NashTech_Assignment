using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace R2EShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update_AverageStar_Field : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageStar",
                table: "PhoneCase");

            migrationBuilder.AddColumn<double>(
                name: "AverageStar",
                table: "CaseType",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageStar",
                table: "CaseType");

            migrationBuilder.AddColumn<double>(
                name: "AverageStar",
                table: "PhoneCase",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
