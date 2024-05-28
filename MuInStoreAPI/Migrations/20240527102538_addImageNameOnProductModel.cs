using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MuInStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class addImageNameOnProductModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7970d324-59ae-4803-9c45-e8f94cd1cc9d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8cee4214-5371-40a5-9b5f-bc9e1769a2c1");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c3947b7c-495d-48f2-92c4-8d82be7008e2", null, "User", "USER" },
                    { "f6efca68-aa5f-4b97-a882-b048e0df4cee", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "CreatAt", "ImageName" },
                values: new object[] { new DateTime(2024, 5, 27, 17, 25, 37, 33, DateTimeKind.Local).AddTicks(1832), "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "CreatAt", "ImageName" },
                values: new object[] { new DateTime(2024, 5, 27, 17, 25, 37, 33, DateTimeKind.Local).AddTicks(1854), "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "CreatAt", "ImageName" },
                values: new object[] { new DateTime(2024, 5, 27, 17, 25, 37, 33, DateTimeKind.Local).AddTicks(1860), "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "CreatAt", "ImageName" },
                values: new object[] { new DateTime(2024, 5, 27, 17, 25, 37, 33, DateTimeKind.Local).AddTicks(1865), "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3947b7c-495d-48f2-92c4-8d82be7008e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6efca68-aa5f-4b97-a882-b048e0df4cee");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Products");

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
                column: "CreatAt",
                value: new DateTime(2024, 5, 17, 17, 31, 40, 129, DateTimeKind.Local).AddTicks(8606));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CreatAt",
                value: new DateTime(2024, 5, 17, 17, 31, 40, 129, DateTimeKind.Local).AddTicks(8634));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "CreatAt",
                value: new DateTime(2024, 5, 17, 17, 31, 40, 129, DateTimeKind.Local).AddTicks(8641));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "CreatAt",
                value: new DateTime(2024, 5, 17, 17, 31, 40, 129, DateTimeKind.Local).AddTicks(8645));
        }
    }
}
