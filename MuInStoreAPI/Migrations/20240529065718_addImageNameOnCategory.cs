using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MuInStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class addImageNameOnCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3947b7c-495d-48f2-92c4-8d82be7008e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6efca68-aa5f-4b97-a882-b048e0df4cee");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a760fd51-b597-4c4b-ae20-4903f807bc0d", null, "User", "USER" },
                    { "eea04ce2-2c2e-4bba-a019-9cf8b850a5f3", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CatId",
                keyValue: 1,
                column: "ImageName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CatId",
                keyValue: 2,
                column: "ImageName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CatId",
                keyValue: 3,
                column: "ImageName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CatId",
                keyValue: 4,
                column: "ImageName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CreatAt",
                value: new DateTime(2024, 5, 29, 13, 57, 17, 64, DateTimeKind.Local).AddTicks(6116));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CreatAt",
                value: new DateTime(2024, 5, 29, 13, 57, 17, 64, DateTimeKind.Local).AddTicks(6135));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "CreatAt",
                value: new DateTime(2024, 5, 29, 13, 57, 17, 64, DateTimeKind.Local).AddTicks(6140));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "CreatAt",
                value: new DateTime(2024, 5, 29, 13, 57, 17, 64, DateTimeKind.Local).AddTicks(6143));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a760fd51-b597-4c4b-ae20-4903f807bc0d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eea04ce2-2c2e-4bba-a019-9cf8b850a5f3");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Categories");

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
                column: "CreatAt",
                value: new DateTime(2024, 5, 27, 17, 25, 37, 33, DateTimeKind.Local).AddTicks(1832));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CreatAt",
                value: new DateTime(2024, 5, 27, 17, 25, 37, 33, DateTimeKind.Local).AddTicks(1854));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "CreatAt",
                value: new DateTime(2024, 5, 27, 17, 25, 37, 33, DateTimeKind.Local).AddTicks(1860));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "CreatAt",
                value: new DateTime(2024, 5, 27, 17, 25, 37, 33, DateTimeKind.Local).AddTicks(1865));
        }
    }
}
