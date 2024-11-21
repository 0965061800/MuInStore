using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MuIn.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_CategoryCatId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CategoryCatId",
                table: "Categories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31c15610-951b-4cd7-9528-4f7148711050");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6389555d-defd-416d-b768-cd1c113bd2f5");

            migrationBuilder.DropColumn(
                name: "CategoryCatId",
                table: "Categories");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0bb0f4c7-0750-4e97-9d2a-bca06c1f34a5", null, "User", "USER" },
                    { "362c8d9e-74fd-41b2-be21-ed9f680fb4d7", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CreatAt",
                value: new DateTime(2024, 11, 16, 16, 33, 12, 243, DateTimeKind.Local).AddTicks(9359));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CreatAt",
                value: new DateTime(2024, 11, 16, 16, 33, 12, 243, DateTimeKind.Local).AddTicks(9366));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "CreatAt",
                value: new DateTime(2024, 11, 16, 16, 33, 12, 243, DateTimeKind.Local).AddTicks(9370));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "CreatAt",
                value: new DateTime(2024, 11, 16, 16, 33, 12, 243, DateTimeKind.Local).AddTicks(9373));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                column: "CreatAt",
                value: new DateTime(2024, 11, 16, 16, 33, 12, 243, DateTimeKind.Local).AddTicks(9377));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                column: "CreatAt",
                value: new DateTime(2024, 11, 16, 16, 33, 12, 243, DateTimeKind.Local).AddTicks(9380));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7,
                column: "CreatAt",
                value: new DateTime(2024, 11, 16, 16, 33, 12, 243, DateTimeKind.Local).AddTicks(9382));

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCatId",
                table: "Categories",
                column: "ParentCatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentCatId",
                table: "Categories",
                column: "ParentCatId",
                principalTable: "Categories",
                principalColumn: "CatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentCatId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ParentCatId",
                table: "Categories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0bb0f4c7-0750-4e97-9d2a-bca06c1f34a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "362c8d9e-74fd-41b2-be21-ed9f680fb4d7");

            migrationBuilder.AddColumn<int>(
                name: "CategoryCatId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "31c15610-951b-4cd7-9528-4f7148711050", null, "Admin", "ADMIN" },
                    { "6389555d-defd-416d-b768-cd1c113bd2f5", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CatId",
                keyValue: 1,
                column: "CategoryCatId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CatId",
                keyValue: 2,
                column: "CategoryCatId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CatId",
                keyValue: 3,
                column: "CategoryCatId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CatId",
                keyValue: 4,
                column: "CategoryCatId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CatId",
                keyValue: 5,
                column: "CategoryCatId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CatId",
                keyValue: 6,
                column: "CategoryCatId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CatId",
                keyValue: 7,
                column: "CategoryCatId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CreatAt",
                value: new DateTime(2024, 11, 15, 10, 53, 3, 903, DateTimeKind.Local).AddTicks(7362));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CreatAt",
                value: new DateTime(2024, 11, 15, 10, 53, 3, 903, DateTimeKind.Local).AddTicks(7367));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "CreatAt",
                value: new DateTime(2024, 11, 15, 10, 53, 3, 903, DateTimeKind.Local).AddTicks(7370));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "CreatAt",
                value: new DateTime(2024, 11, 15, 10, 53, 3, 903, DateTimeKind.Local).AddTicks(7373));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                column: "CreatAt",
                value: new DateTime(2024, 11, 15, 10, 53, 3, 903, DateTimeKind.Local).AddTicks(7376));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                column: "CreatAt",
                value: new DateTime(2024, 11, 15, 10, 53, 3, 903, DateTimeKind.Local).AddTicks(7380));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7,
                column: "CreatAt",
                value: new DateTime(2024, 11, 15, 10, 53, 3, 903, DateTimeKind.Local).AddTicks(7383));

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryCatId",
                table: "Categories",
                column: "CategoryCatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_CategoryCatId",
                table: "Categories",
                column: "CategoryCatId",
                principalTable: "Categories",
                principalColumn: "CatId");
        }
    }
}
