using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foodies.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUselessLinkIngredient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_UnitOfMeasure_UnitOfMeasureId",
                table: "Ingredient");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_UnitOfMeasureId",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasureId",
                table: "Ingredient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UnitOfMeasureId",
                table: "Ingredient",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_UnitOfMeasureId",
                table: "Ingredient",
                column: "UnitOfMeasureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_UnitOfMeasure_UnitOfMeasureId",
                table: "Ingredient",
                column: "UnitOfMeasureId",
                principalTable: "UnitOfMeasure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
