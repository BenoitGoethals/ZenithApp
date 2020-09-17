using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZenithApp.Migrations
{
    public partial class product2000 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Gsm = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(maxLength: 20, nullable: false),
                    Collected = table.Column<bool>(nullable: false),
                    Payed = table.Column<bool>(nullable: false),
                    DateTimeCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: false),
                    PriceString = table.Column<string>(nullable: false),
                    VatString = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    VatPercentage = table.Column<double>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true),
                    TypeProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_TypeProducts_TypeProductId",
                        column: x => x.TypeProductId,
                        principalTable: "TypeProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(maxLength: 50, nullable: false),
                    BasketId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLines_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Baskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLines_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TypeProducts",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Drank" });

            migrationBuilder.InsertData(
                table: "TypeProducts",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Chips" });

            migrationBuilder.InsertData(
                table: "TypeProducts",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "other" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_BasketId",
                table: "OrderLines",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_ProductId",
                table: "OrderLines",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TypeProductId",
                table: "Products",
                column: "TypeProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "TypeProducts");
        }
    }
}
