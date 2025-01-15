using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dress_u_backend.Migrations
{
    /// <inheritdoc />
    public partial class add_category_model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Description_Cloth_ClothId",
                table: "Description");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cloth",
                table: "Cloth");

            migrationBuilder.RenameTable(
                name: "Cloth",
                newName: "Cloths");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cloths",
                table: "Cloths",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

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
                        name: "FK_CategoryCloth_Category_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Category",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Description_Cloths_ClothId",
                table: "Description",
                column: "ClothId",
                principalTable: "Cloths",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Description_Cloths_ClothId",
                table: "Description");

            migrationBuilder.DropTable(
                name: "CategoryCloth");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cloths",
                table: "Cloths");

            migrationBuilder.RenameTable(
                name: "Cloths",
                newName: "Cloth");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cloth",
                table: "Cloth",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Description_Cloth_ClothId",
                table: "Description",
                column: "ClothId",
                principalTable: "Cloth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
