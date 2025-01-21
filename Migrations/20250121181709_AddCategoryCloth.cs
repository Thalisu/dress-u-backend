using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dress_u_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryCloth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryCloth");

            migrationBuilder.CreateTable(
                name: "CategoryCloths",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ClothId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryCloths", x => new { x.ClothId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_CategoryCloths_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryCloths_Cloths_ClothId",
                        column: x => x.ClothId,
                        principalTable: "Cloths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryCloths_CategoryId",
                table: "CategoryCloths",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryCloths");

            migrationBuilder.CreateTable(
                name: "CategoryCloth",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ClothsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryCloth", x => new { x.CategoriesId, x.ClothsId });
                    table.ForeignKey(
                        name: "FK_CategoryCloth_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryCloth_Cloths_ClothsId",
                        column: x => x.ClothsId,
                        principalTable: "Cloths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryCloth_ClothsId",
                table: "CategoryCloth",
                column: "ClothsId");
        }
    }
}
