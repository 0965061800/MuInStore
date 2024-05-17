using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MuInStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeaddressinOrderModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d18a50d-0524-466a-89c7-6f429b4ae1ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c16c96c6-00ed-4139-bbfb-2c1b187be118");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c01694f1-b1d1-4911-b0c0-a7ace2f80cca", null, "User", "USER" },
                    { "e81cdf0c-6d71-43f6-9dcf-75a9a3410224", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CreatAt",
                value: new DateTime(2024, 5, 16, 14, 0, 8, 952, DateTimeKind.Local).AddTicks(4542));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CreatAt",
                value: new DateTime(2024, 5, 16, 14, 0, 8, 952, DateTimeKind.Local).AddTicks(4572));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "CreatAt",
                value: new DateTime(2024, 5, 16, 14, 0, 8, 952, DateTimeKind.Local).AddTicks(4579));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "CreatAt",
                value: new DateTime(2024, 5, 16, 14, 0, 8, 952, DateTimeKind.Local).AddTicks(4582));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c01694f1-b1d1-4911-b0c0-a7ace2f80cca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e81cdf0c-6d71-43f6-9dcf-75a9a3410224");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4d18a50d-0524-466a-89c7-6f429b4ae1ac", null, "User", "USER" },
                    { "c16c96c6-00ed-4139-bbfb-2c1b187be118", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CreatAt",
                value: new DateTime(2024, 5, 15, 12, 43, 50, 541, DateTimeKind.Local).AddTicks(6455));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CreatAt",
                value: new DateTime(2024, 5, 15, 12, 43, 50, 541, DateTimeKind.Local).AddTicks(6473));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "CreatAt",
                value: new DateTime(2024, 5, 15, 12, 43, 50, 541, DateTimeKind.Local).AddTicks(6478));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "CreatAt",
                value: new DateTime(2024, 5, 15, 12, 43, 50, 541, DateTimeKind.Local).AddTicks(6481));
        }
    }
}
