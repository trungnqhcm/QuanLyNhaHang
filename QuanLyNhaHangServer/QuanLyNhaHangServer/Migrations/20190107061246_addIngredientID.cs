using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyNhaHangServer.Migrations
{
    public partial class addIngredientID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "IngredientId",
                table: "IngredientWithFoods",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_IngredientWithFoods_IngredientId",
                table: "IngredientWithFoods",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientWithFoods_Ingredients_IngredientId",
                table: "IngredientWithFoods",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientWithFoods_Ingredients_IngredientId",
                table: "IngredientWithFoods");

            migrationBuilder.DropIndex(
                name: "IX_IngredientWithFoods_IngredientId",
                table: "IngredientWithFoods");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "IngredientWithFoods");
        }
    }
}
