using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Product_Catalog_API.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("00000001-0000-0000-0000-000000000001"), "Electronics", new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "High-end laptop for professionals", "Laptop Pro 15", 1200m, null },
                    { new Guid("00000002-0000-0000-0000-000000000002"), "Electronics", new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Ergonomic wireless mouse", "Wireless Mouse", 25m, null },
                    { new Guid("00000003-0000-0000-0000-000000000003"), "Electronics", new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Mechanical RGB keyboard", "Gaming Keyboard", 75m, null },
                    { new Guid("00000004-0000-0000-0000-000000000004"), "Electronics", new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Latest smartphone with OLED display", "Smartphone X", 999m, null },
                    { new Guid("00000005-0000-0000-0000-000000000005"), "Electronics", new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Noise-cancelling over-ear headphones", "Bluetooth Headphones", 199m, null },
                    { new Guid("00000006-0000-0000-0000-000000000006"), "Books", new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Comprehensive guide to C#", "C# Programming", 40m, null },
                    { new Guid("00000007-0000-0000-0000-000000000007"), "Books", new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Learn to build web APIs", "ASP.NET Core in Action", 50m, null },
                    { new Guid("00000008-0000-0000-0000-000000000008"), "Books", new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Engaging mystery story", "Mystery Novel", 15m, null },
                    { new Guid("00000009-0000-0000-0000-000000000009"), "Clothing", new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "100% cotton casual T-shirt", "Men's T-Shirt", 20m, null },
                    { new Guid("0000000a-0000-0000-0000-00000000000a"), "Clothing", new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Slim fit denim jeans", "Women's Jeans", 45m, null },
                    { new Guid("0000000b-0000-0000-0000-00000000000b"), "Home", new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Modern wooden coffee table", "Coffee Table", 120m, null },
                    { new Guid("0000000c-0000-0000-0000-00000000000c"), "Home", new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Desk lamp with adjustable brightness", "LED Lamp", 35m, null },
                    { new Guid("0000000d-0000-0000-0000-00000000000d"), "Sports", new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Official size football", "Football", 25m, null },
                    { new Guid("0000000e-0000-0000-0000-00000000000e"), "Sports", new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Professional tennis racket", "Tennis Racket", 80m, null },
                    { new Guid("0000000f-0000-0000-0000-00000000000f"), "Toys", new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Collectible action figure", "Action Figure", 25m, null },
                    { new Guid("00000010-0000-0000-0000-000000000010"), "Toys", new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "500-piece jigsaw puzzle", "Puzzle Game", 15m, null },
                    { new Guid("00000011-0000-0000-0000-000000000011"), "Electronics", new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "50-inch 4K Ultra HD Smart TV", "Smart LED TV 50\"", 450m, null },
                    { new Guid("00000012-0000-0000-0000-000000000012"), "Home", new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Fast boiling stainless steel kettle", "Electric Kettle", 30m, null },
                    { new Guid("00000013-0000-0000-0000-000000000013"), "Clothing", new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Lightweight breathable running shoes", "Running Shoes", 60m, null },
                    { new Guid("00000014-0000-0000-0000-000000000014"), "Home", new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Non-stick pots and pans set", "Cookware Set 10pcs", 120m, null },
                    { new Guid("00000015-0000-0000-0000-000000000015"), "Toys", new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Fun family board game", "Board Game Classic", 35m, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Category",
                table: "Products",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatedAt",
                table: "Products",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Price",
                table: "Products",
                column: "Price");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
