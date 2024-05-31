using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace R2EShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update_Category_PhoneCase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryPhoneCase_PhoneCase_ProductsId",
                table: "CategoryPhoneCase");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneCase_Artwork_ArtworkId",
                table: "PhoneCase");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneCase_CaseColor_CaseColorId",
                table: "PhoneCase");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneCase_CaseType_CaseTypeId",
                table: "PhoneCase");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneCase_Device_DeviceId",
                table: "PhoneCase");

            migrationBuilder.DropIndex(
                name: "IX_PhoneCase_CaseColorId",
                table: "PhoneCase");

            migrationBuilder.DropIndex(
                name: "IX_PhoneCase_DeviceId",
                table: "PhoneCase");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "CategoryPhoneCase",
                newName: "PhoneCasesId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryPhoneCase_ProductsId",
                table: "CategoryPhoneCase",
                newName: "IX_CategoryPhoneCase_PhoneCasesId");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeviceId",
                table: "PhoneCase",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CaseTypeId",
                table: "PhoneCase",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CaseColorId",
                table: "PhoneCase",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ArtworkId",
                table: "PhoneCase",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryPhoneCase_PhoneCase_PhoneCasesId",
                table: "CategoryPhoneCase",
                column: "PhoneCasesId",
                principalTable: "PhoneCase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneCase_Artwork_ArtworkId",
                table: "PhoneCase",
                column: "ArtworkId",
                principalTable: "Artwork",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneCase_CaseType_CaseTypeId",
                table: "PhoneCase",
                column: "CaseTypeId",
                principalTable: "CaseType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryPhoneCase_PhoneCase_PhoneCasesId",
                table: "CategoryPhoneCase");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneCase_Artwork_ArtworkId",
                table: "PhoneCase");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneCase_CaseType_CaseTypeId",
                table: "PhoneCase");

            migrationBuilder.RenameColumn(
                name: "PhoneCasesId",
                table: "CategoryPhoneCase",
                newName: "ProductsId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryPhoneCase_PhoneCasesId",
                table: "CategoryPhoneCase",
                newName: "IX_CategoryPhoneCase_ProductsId");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeviceId",
                table: "PhoneCase",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CaseTypeId",
                table: "PhoneCase",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CaseColorId",
                table: "PhoneCase",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ArtworkId",
                table: "PhoneCase",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneCase_CaseColorId",
                table: "PhoneCase",
                column: "CaseColorId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneCase_DeviceId",
                table: "PhoneCase",
                column: "DeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryPhoneCase_PhoneCase_ProductsId",
                table: "CategoryPhoneCase",
                column: "ProductsId",
                principalTable: "PhoneCase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneCase_Artwork_ArtworkId",
                table: "PhoneCase",
                column: "ArtworkId",
                principalTable: "Artwork",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneCase_CaseColor_CaseColorId",
                table: "PhoneCase",
                column: "CaseColorId",
                principalTable: "CaseColor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneCase_CaseType_CaseTypeId",
                table: "PhoneCase",
                column: "CaseTypeId",
                principalTable: "CaseType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneCase_Device_DeviceId",
                table: "PhoneCase",
                column: "DeviceId",
                principalTable: "Device",
                principalColumn: "Id");
        }
    }
}
