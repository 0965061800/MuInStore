using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MuInStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateProductSkuModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2cd53537-d53e-446c-9174-e3071cbe6f93");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79612c9f-1dfb-4197-b6ee-9910f70d15b0");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "ProductSkus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "skuImage",
                table: "ProductSkus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d0751337-b076-47f1-886f-d2ac2e65121f", null, "User", "USER" },
                    { "d3bfc716-0ba3-4d75-86d6-77731684042f", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "ProductSkus",
                keyColumn: "ProductSkuId",
                keyValue: 1,
                columns: new[] { "ImageName", "skuImage" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "ProductSkus",
                keyColumn: "ProductSkuId",
                keyValue: 2,
                columns: new[] { "ImageName", "skuImage" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "ProductSkus",
                keyColumn: "ProductSkuId",
                keyValue: 3,
                columns: new[] { "ImageName", "skuImage" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "ProductSkus",
                keyColumn: "ProductSkuId",
                keyValue: 4,
                columns: new[] { "ImageName", "skuImage" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "ProductSkus",
                keyColumn: "ProductSkuId",
                keyValue: 5,
                columns: new[] { "ImageName", "skuImage" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "ProductSkus",
                keyColumn: "ProductSkuId",
                keyValue: 6,
                columns: new[] { "ImageName", "skuImage" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "ProductSkus",
                keyColumn: "ProductSkuId",
                keyValue: 7,
                columns: new[] { "ImageName", "skuImage" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CreatAt",
                value: new DateTime(2024, 6, 2, 19, 57, 48, 398, DateTimeKind.Local).AddTicks(2156));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CreatAt",
                value: new DateTime(2024, 6, 2, 19, 57, 48, 398, DateTimeKind.Local).AddTicks(2178));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "CreatAt",
                value: new DateTime(2024, 6, 2, 19, 57, 48, 398, DateTimeKind.Local).AddTicks(2186));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "CreatAt",
                value: new DateTime(2024, 6, 2, 19, 57, 48, 398, DateTimeKind.Local).AddTicks(2190));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0751337-b076-47f1-886f-d2ac2e65121f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3bfc716-0ba3-4d75-86d6-77731684042f");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "ProductSkus");

            migrationBuilder.DropColumn(
                name: "skuImage",
                table: "ProductSkus");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2cd53537-d53e-446c-9174-e3071cbe6f93", null, "Admin", "ADMIN" },
                    { "79612c9f-1dfb-4197-b6ee-9910f70d15b0", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CreatAt",
                value: new DateTime(2024, 6, 2, 11, 18, 21, 332, DateTimeKind.Local).AddTicks(9726));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CreatAt",
                value: new DateTime(2024, 6, 2, 11, 18, 21, 332, DateTimeKind.Local).AddTicks(9756));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "CreatAt",
                value: new DateTime(2024, 6, 2, 11, 18, 21, 332, DateTimeKind.Local).AddTicks(9761));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "CreatAt",
                value: new DateTime(2024, 6, 2, 11, 18, 21, 332, DateTimeKind.Local).AddTicks(9764));
        }
    }
}
