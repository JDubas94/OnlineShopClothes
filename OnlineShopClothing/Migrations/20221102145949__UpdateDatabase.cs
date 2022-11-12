using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShopClothing.Migrations
{
    public partial class _UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Сlothing_ClothingId",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_ClothingId",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "ClothingId",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "isCheked",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "Сlothing");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClothingId",
                table: "Sizes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isCheked",
                table: "Sizes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "Сlothing",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_ClothingId",
                table: "Sizes",
                column: "ClothingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Сlothing_ClothingId",
                table: "Sizes",
                column: "ClothingId",
                principalTable: "Сlothing",
                principalColumn: "Id");
        }
    }
}
