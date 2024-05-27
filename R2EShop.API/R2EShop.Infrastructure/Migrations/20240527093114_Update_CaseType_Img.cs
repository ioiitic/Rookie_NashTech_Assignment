using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace R2EShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update_CaseType_Img : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseType_Device_DeviceId",
                table: "CaseType");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Device");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeviceId",
                table: "CaseType",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "CaseType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseType_Device_DeviceId",
                table: "CaseType",
                column: "DeviceId",
                principalTable: "Device",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseType_Device_DeviceId",
                table: "CaseType");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "CaseType");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Device",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeviceId",
                table: "CaseType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseType_Device_DeviceId",
                table: "CaseType",
                column: "DeviceId",
                principalTable: "Device",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
