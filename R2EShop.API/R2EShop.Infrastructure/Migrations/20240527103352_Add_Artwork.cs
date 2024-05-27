using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace R2EShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Artwork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseType_Device_DeviceId",
                table: "CaseType");

            migrationBuilder.AddColumn<Guid>(
                name: "ArtworkId",
                table: "PhoneCase",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DeviceId",
                table: "CaseType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Artwork",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArtworkName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artwork", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhoneCase_ArtworkId",
                table: "PhoneCase",
                column: "ArtworkId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseType_Device_DeviceId",
                table: "CaseType",
                column: "DeviceId",
                principalTable: "Device",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneCase_Artwork_ArtworkId",
                table: "PhoneCase",
                column: "ArtworkId",
                principalTable: "Artwork",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseType_Device_DeviceId",
                table: "CaseType");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneCase_Artwork_ArtworkId",
                table: "PhoneCase");

            migrationBuilder.DropTable(
                name: "Artwork");

            migrationBuilder.DropIndex(
                name: "IX_PhoneCase_ArtworkId",
                table: "PhoneCase");

            migrationBuilder.DropColumn(
                name: "ArtworkId",
                table: "PhoneCase");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeviceId",
                table: "CaseType",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseType_Device_DeviceId",
                table: "CaseType",
                column: "DeviceId",
                principalTable: "Device",
                principalColumn: "Id");
        }
    }
}
