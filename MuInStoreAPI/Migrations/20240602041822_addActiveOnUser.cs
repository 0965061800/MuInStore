using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MuInStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class addActiveOnUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "596ba788-dbf7-47dc-978c-d1e29db6b3e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94e6ba45-a02b-4246-ba50-a71720c971ce");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2cd53537-d53e-446c-9174-e3071cbe6f93");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79612c9f-1dfb-4197-b6ee-9910f70d15b0");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "596ba788-dbf7-47dc-978c-d1e29db6b3e3", null, "Admin", "ADMIN" },
                    { "94e6ba45-a02b-4246-ba50-a71720c971ce", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CreatAt",
                value: new DateTime(2024, 6, 1, 17, 26, 22, 566, DateTimeKind.Local).AddTicks(4905));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CreatAt",
                value: new DateTime(2024, 6, 1, 17, 26, 22, 566, DateTimeKind.Local).AddTicks(4930));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "CreatAt",
                value: new DateTime(2024, 6, 1, 17, 26, 22, 566, DateTimeKind.Local).AddTicks(4934));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "CreatAt",
                value: new DateTime(2024, 6, 1, 17, 26, 22, 566, DateTimeKind.Local).AddTicks(4937));
        }
    }
}
