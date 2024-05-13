using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MuInStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddModelAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d374c03-27b1-4772-b684-1f72aefb6a1a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "890f0c82-986b-4900-bc57-d42a895a6b4d");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CatImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentCatId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CatId);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    ColorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.ColorId);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    FeatureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.FeatureId);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    ParentLocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "PayStatuses",
                columns: table => new
                {
                    PayStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayStatuses", x => x.PayStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BestSeller = table.Column<bool>(type: "bit", nullable: false),
                    Sale = table.Column<decimal>(type: "decimal(2,2)", nullable: false),
                    VideoLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    specifications = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    FeatureId = table.Column<int>(type: "int", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId");
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CatId");
                    table.ForeignKey(
                        name: "FK_Products_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "FeatureId");
                });

            migrationBuilder.CreateTable(
                name: "UserLocation",
                columns: table => new
                {
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLocation", x => new { x.AppUserId, x.LocationId });
                    table.ForeignKey(
                        name: "FK_UserLocation_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLocation_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PayStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_PayStatuses_PayStatusId",
                        column: x => x.PayStatusId,
                        principalTable: "PayStatuses",
                        principalColumn: "PayStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSkus",
                columns: table => new
                {
                    ProductSkuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitInStock = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSkus", x => x.ProductSkuId);
                    table.ForeignKey(
                        name: "FK_ProductSkus_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "ColorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSkus_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SumTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentImages",
                columns: table => new
                {
                    CommentImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentImages", x => x.CommentImageId);
                    table.ForeignKey(
                        name: "FK_CommentImages_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "CommentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    ProductImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductSkuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.ProductImageId);
                    table.ForeignKey(
                        name: "FK_ProductImages_ProductSkus_ProductSkuId",
                        column: x => x.ProductSkuId,
                        principalTable: "ProductSkus",
                        principalColumn: "ProductSkuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductSkuId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SaleRate = table.Column<decimal>(type: "decimal(2,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_ProductSkus_ProductSkuId",
                        column: x => x.ProductSkuId,
                        principalTable: "ProductSkus",
                        principalColumn: "ProductSkuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ac3c9cf4-c0e6-4c50-bf14-07bc6e5ce6df", null, "Admin", "ADMIN" },
                    { "c185f673-0fe5-4698-ac39-a29868fe0b4e", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandId", "Alias", "BrandImage", "BrandName" },
                values: new object[,]
                {
                    { 1, "casio", "", "Casio" },
                    { 2, "yamaha", "", "Yamaha" },
                    { 3, "roland", "", "Roland" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CatId", "Alias", "CatImage", "CatName", "ParentCatId" },
                values: new object[,]
                {
                    { 1, "piano", null, "Piano", null },
                    { 2, "guitar", null, "Guitar", null },
                    { 3, "Violin", null, "Violin", null },
                    { 4, "e-piano", null, "Piano điện", 1 }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "ColorId", "ColorName" },
                values: new object[,]
                {
                    { 1, "Black" },
                    { 2, "White" },
                    { 3, "Brown" },
                    { 4, "Grey" },
                    { 5, "Blue" }
                });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "FeatureId", "Alias", "FeatureName" },
                values: new object[,]
                {
                    { 1, "newbigginer", "Dành cho người mới học" },
                    { 2, "kids", "Dành cho người bạn nhỏ" },
                    { 3, "advanced", "Danh cho trình độ cao" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Alias", "Lat", "Level", "Lng", "LocationName", "ParentLocationId" },
                values: new object[,]
                {
                    { 1, "HCM", "10.7936663", 0, "106.6777955", "Tp Hồ Chí Minh", null },
                    { 839, "binh-duong", "11.3254024", 0, "106.477016999999", "Bình Dương", null },
                    { 1093, "binh-chanh", "10.7430983", 0, "106.54662209999992", "Huyện Bình Chánh", 1 },
                    { 1100, "thi-xa-ben-cat", "11.101302", 0, "106.58197889999997", "Thị Xã Bến Cát", 2 },
                    { 1103, "tp-thu-dau-mot", "10.9929842", 0, "106.65570730000002", "Thành Phố Thủ Dầu Một", 2 },
                    { 1136, "cu-chi", "11.0066683", 0, "106.51319669999998", "Huyện Củ Chi", 1 },
                    { 1141, "xa-binh-hung", "10.7200104", 0, "106.6703963", "Xã Bình Hưng", 1093 },
                    { 1142, "xa-binh-loi", "10.7756348", 0, "106.5096239", "Xã Bình Lợi", 1093 }
                });

            migrationBuilder.InsertData(
                table: "PayStatuses",
                columns: new[] { "PayStatusId", "Description", "Status" },
                values: new object[,]
                {
                    { 1, "Đang chờ thanh toán", "Pending" },
                    { 2, "Bị từ chối", "Declined" },
                    { 3, "Hủy bỏ", "Cancelled" },
                    { 4, "Hoàn trả", "Refunded" },
                    { 5, "Hết hạn", "Expired" },
                    { 6, "Đã thanh toán", "Settled" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Active", "Alias", "BestSeller", "BrandId", "CategoryId", "Description", "FeatureId", "ProductCode", "ProductName", "Sale", "VideoLink", "specifications" },
                values: new object[,]
                {
                    { 1, true, "yamahaC1Pe", false, 2, 1, "Thông số kỹ thuật YAMAHA C1PE. Model C1 PE Màu sắc/Lớp hoàn thiện Thùng đàn Màu sắc Polished Ebony Lớp phủ Polished Kích cỡ/Trọng lượng Kích thước Rộng 149cm (59\") Cao 101cm (40\") Dày 161cm (5'3\") Trọng lượng Trọng lượng...", 3, "C1PE-C", "Grand Piano Yamaha C1 PE - C Series", 0m, "", "Trọng lượng Kích thước Rộng 149cm (59\") Cao 101cm (40\") Dày 161cm (5'3\")" },
                    { 2, true, "CT300", false, 1, 4, "Thông số kỹ thuật YAMAHA C1PE. Model C1 PE Màu sắc/Lớp hoàn thiện Thùng đàn Màu sắc Polished Ebony Lớp phủ Polished Kích cỡ/Trọng lượng Kích thước Rộng 149cm (59\") Cao 101cm (40\") Dày 161cm (5'3\") Trọng lượng Trọng lượng...", 1, "CT300", "CASIO CT-S300", 0.3m, "", "Trọng lượng Kích thước Rộng 149cm (59\") Cao 101cm (40\") Dày 161cm (5'3\")" },
                    { 3, true, "CT300", false, 1, 4, "Thông số kỹ thuật YAMAHA C1PE. Model C1 PE Màu sắc/Lớp hoàn thiện Thùng đàn Màu sắc Polished Ebony Lớp phủ Polished Kích cỡ/Trọng lượng Kích thước Rộng 149cm (59\") Cao 101cm (40\") Dày 161cm (5'3\") Trọng lượng Trọng lượng...", 2, "CDP-S160BK", "CASIO CDP-S160BK", 0.3m, "", "Trọng lượng Kích thước Rộng 149cm (59\") Cao 101cm (40\") Dày 161cm (5'3\")" },
                    { 4, true, "digital-piano-rp501r", true, 3, 4, "- Sản phẩm bao gồm: Đàn + Ghế Roland RAM8065 | - Động cơ SuperNATURAL Piano cho âm thanh phong phú & chân thực | - Bàn phím PHA-4 Standard có tính năng cảm biến với độ phân giải cao | - Pedal Progressive Damper Action với phản ứng liên tục | - Hiệu ứng Headphones 3D Ambience. Kết nối với các ứng dụng thú vị | - Tính năng nhịp điệu phức tạp với điệu đệm thông minh; | - Đàn có dạng tủ đứng tiết kiệm không gian", 1, "RP-501R-CB", "Roland RP-501R", 0.3m, "", "Trọng lượng Kích thước Rộng 149cm (59\") Cao 101cm (40\") Dày 161cm (5'3\")" }
                });

            migrationBuilder.InsertData(
                table: "ProductSkus",
                columns: new[] { "ProductSkuId", "ColorId", "ProductId", "Sku", "UnitInStock", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, "C1PE-C1", 3, 12000000m },
                    { 2, 2, 1, "C1PE-C2", 5, 12500000m },
                    { 3, 3, 1, "C1PE-C3", 3, 12800000m },
                    { 4, 1, 2, "CT3001", 3, 18000000m },
                    { 5, 2, 2, "CT3002", 4, 18200000m },
                    { 6, 1, 3, "CDP-S160BK1", 4, 8200000m },
                    { 7, 1, 4, "RP-501R-CB1", 1, 82000000m }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "ProductImageId", "ImageUrl", "ProductSkuId" },
                values: new object[,]
                {
                    { 1, "Product1.jpg", 1 },
                    { 2, "Product1.jpg", 2 },
                    { 3, "Product1.jpg", 3 },
                    { 4, "Product1.jpg", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentImages_CommentId",
                table: "CommentImages",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AppUserId",
                table: "Comments",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductId",
                table: "Comments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductSkuId",
                table: "OrderDetails",
                column: "ProductSkuId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AppUserId",
                table: "Orders",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentId",
                table: "Orders",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PayStatusId",
                table: "Payments",
                column: "PayStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductSkuId",
                table: "ProductImages",
                column: "ProductSkuId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FeatureId",
                table: "Products",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSkus_ColorId",
                table: "ProductSkus",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSkus_ProductId",
                table: "ProductSkus",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLocation_LocationId",
                table: "UserLocation",
                column: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentImages");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "UserLocation");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductSkus");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "PayStatuses");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac3c9cf4-c0e6-4c50-bf14-07bc6e5ce6df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c185f673-0fe5-4698-ac39-a29868fe0b4e");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3d374c03-27b1-4772-b684-1f72aefb6a1a", null, "Admin", "ADMIN" },
                    { "890f0c82-986b-4900-bc57-d42a895a6b4d", null, "User", "USER" }
                });
        }
    }
}
