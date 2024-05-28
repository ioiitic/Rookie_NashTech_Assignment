using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace R2EShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update_Artwork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfBuyers",
                table: "PhoneCase");

            migrationBuilder.AddColumn<bool>(
                name: "IsNew",
                table: "Artwork",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTrending",
                table: "Artwork",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfBuyers",
                table: "Artwork",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsNew",
                table: "Artwork");

            migrationBuilder.DropColumn(
                name: "IsTrending",
                table: "Artwork");

            migrationBuilder.DropColumn(
                name: "NumberOfBuyers",
                table: "Artwork");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfBuyers",
                table: "PhoneCase",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
