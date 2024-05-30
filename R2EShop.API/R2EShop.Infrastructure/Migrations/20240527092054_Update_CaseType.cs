using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace R2EShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update_CaseType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Device",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "DeviceId",
                table: "CaseType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CaseType_DeviceId",
                table: "CaseType",
                column: "DeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseType_Device_DeviceId",
                table: "CaseType",
                column: "DeviceId",
                principalTable: "Device",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseType_Device_DeviceId",
                table: "CaseType");

            migrationBuilder.DropIndex(
                name: "IX_CaseType_DeviceId",
                table: "CaseType");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "CaseType");
        }
    }
}
