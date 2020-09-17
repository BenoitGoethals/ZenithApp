using Microsoft.EntityFrameworkCore.Migrations;

namespace ZenithApp.Migrations
{
    public partial class product20000q : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gsm",
                table: "Baskets",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20) CHARACTER SET utf8mb4",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Baskets",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20) CHARACTER SET utf8mb4",
                oldMaxLength: 20);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gsm",
                table: "Baskets",
                type: "varchar(20) CHARACTER SET utf8mb4",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Baskets",
                type: "varchar(20) CHARACTER SET utf8mb4",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
