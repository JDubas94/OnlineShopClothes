using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShopClothing.Migrations
{
    public partial class UpdateClothing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Сlothing_Sizes_SizeId",
                table: "Сlothing");

            migrationBuilder.DropIndex(
                name: "IX_Сlothing_SizeId",
                table: "Сlothing");

            migrationBuilder.AddColumn<int>(
                name: "ClothingId",
                table: "Sizes",
                type: "int",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Сlothing_SizeId",
                table: "Сlothing",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Сlothing_Sizes_SizeId",
                table: "Сlothing",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
