using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace R2EShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update_Order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_PhoneCase_ProductId",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderItem",
                newName: "PhoneCaseId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItem",
                newName: "IX_OrderItem_PhoneCaseId");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Category",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ParentCategory",
                table: "Category",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Category",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_PhoneCase_PhoneCaseId",
                table: "OrderItem",
                column: "PhoneCaseId",
                principalTable: "PhoneCase",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_PhoneCase_PhoneCaseId",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ParentCategory",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "PhoneCaseId",
                table: "OrderItem",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_PhoneCaseId",
                table: "OrderItem",
                newName: "IX_OrderItem_ProductId");

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_PhoneCase_ProductId",
                table: "OrderItem",
                column: "ProductId",
                principalTable: "PhoneCase",
                principalColumn: "Id");
        }
    }
}
