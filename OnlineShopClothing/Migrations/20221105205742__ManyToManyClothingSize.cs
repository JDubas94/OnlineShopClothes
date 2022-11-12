using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShopClothing.Migrations
{
    public partial class _ManyToManyClothingSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clothing_Sizes");

            migrationBuilder.CreateTable(
                name: "ClothingSizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    ClothingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothingSizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClothingSizes_Сlothing_ClothingId",
                        column: x => x.ClothingId,
                        principalTable: "Сlothing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClothingSizes_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClothingSizes_ClothingId",
                table: "ClothingSizes",
                column: "ClothingId");

            migrationBuilder.CreateIndex(
                name: "IX_ClothingSizes_SizeId",
                table: "ClothingSizes",
                column: "SizeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClothingSizes");

            migrationBuilder.CreateTable(
                name: "Clothing_Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClothingId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clothing_Sizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clothing_Sizes_Сlothing_ClothingId",
                        column: x => x.ClothingId,
                        principalTable: "Сlothing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clothing_Sizes_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clothing_Sizes_ClothingId",
                table: "Clothing_Sizes",
                column: "ClothingId");

            migrationBuilder.CreateIndex(
                name: "IX_Clothing_Sizes_SizeId",
                table: "Clothing_Sizes",
                column: "SizeId");
        }
    }
}
