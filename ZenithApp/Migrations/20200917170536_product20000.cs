using Microsoft.EntityFrameworkCore.Migrations;

namespace ZenithApp.Migrations
{
    public partial class product20000 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Products_ProductId",
                table: "OrderLines");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Products_ProductId",
                table: "OrderLines",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Products_ProductId",
                table: "OrderLines");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Products_ProductId",
                table: "OrderLines",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
