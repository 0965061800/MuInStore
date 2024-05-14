using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MuInStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddProductPriceCreateAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac3c9cf4-c0e6-4c50-bf14-07bc6e5ce6df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c185f673-0fe5-4698-ac39-a29868fe0b4e");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "ProductPrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3bcdc33f-8b9d-4aee-a302-b3b4c6439bd7", null, "User", "USER" },
                    { "de10f6b9-ee82-48b7-939d-a622d9a4c9b1", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "CreatAt", "ProductPrice" },
                values: new object[] { new DateTime(2024, 5, 14, 11, 0, 31, 195, DateTimeKind.Local).AddTicks(4351), 12000000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "CreatAt", "ProductPrice" },
                values: new object[] { new DateTime(2024, 5, 14, 11, 0, 31, 195, DateTimeKind.Local).AddTicks(4369), 18000000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "CreatAt", "ProductPrice" },
                values: new object[] { new DateTime(2024, 5, 14, 11, 0, 31, 195, DateTimeKind.Local).AddTicks(4374), 8200000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "CreatAt", "ProductPrice" },
                values: new object[] { new DateTime(2024, 5, 14, 11, 0, 31, 195, DateTimeKind.Local).AddTicks(4377), 82000000m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bcdc33f-8b9d-4aee-a302-b3b4c6439bd7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de10f6b9-ee82-48b7-939d-a622d9a4c9b1");

            migrationBuilder.DropColumn(
                name: "CreatAt",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductPrice",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ac3c9cf4-c0e6-4c50-bf14-07bc6e5ce6df", null, "Admin", "ADMIN" },
                    { "c185f673-0fe5-4698-ac39-a29868fe0b4e", null, "User", "USER" }
                });
        }
    }
}
