using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MuInStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddImageonProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b63f565-e507-4352-b28f-9d81f8b29e60");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7edce45-80c8-4420-a660-6a069189dfdb");

            migrationBuilder.AddColumn<string>(
                name: "ProductImage",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7970d324-59ae-4803-9c45-e8f94cd1cc9d", null, "User", "USER" },
                    { "8cee4214-5371-40a5-9b5f-bc9e1769a2c1", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "CreatAt", "ProductImage" },
                values: new object[] { new DateTime(2024, 5, 17, 17, 31, 40, 129, DateTimeKind.Local).AddTicks(8606), "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "CreatAt", "ProductImage" },
                values: new object[] { new DateTime(2024, 5, 17, 17, 31, 40, 129, DateTimeKind.Local).AddTicks(8634), "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "CreatAt", "ProductImage" },
                values: new object[] { new DateTime(2024, 5, 17, 17, 31, 40, 129, DateTimeKind.Local).AddTicks(8641), "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "CreatAt", "ProductImage" },
                values: new object[] { new DateTime(2024, 5, 17, 17, 31, 40, 129, DateTimeKind.Local).AddTicks(8645), "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7970d324-59ae-4803-9c45-e8f94cd1cc9d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8cee4214-5371-40a5-9b5f-bc9e1769a2c1");

            migrationBuilder.DropColumn(
                name: "ProductImage",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5b63f565-e507-4352-b28f-9d81f8b29e60", null, "Admin", "ADMIN" },
                    { "e7edce45-80c8-4420-a660-6a069189dfdb", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CreatAt",
                value: new DateTime(2024, 5, 17, 13, 54, 0, 568, DateTimeKind.Local).AddTicks(3390));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CreatAt",
                value: new DateTime(2024, 5, 17, 13, 54, 0, 568, DateTimeKind.Local).AddTicks(3420));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "CreatAt",
                value: new DateTime(2024, 5, 17, 13, 54, 0, 568, DateTimeKind.Local).AddTicks(3474));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "CreatAt",
                value: new DateTime(2024, 5, 17, 13, 54, 0, 568, DateTimeKind.Local).AddTicks(3480));
        }
    }
}
