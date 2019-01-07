using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyNhaHangServer.Migrations
{
    public partial class addIngredientWithFood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Foods_FoodId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_FoodId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "FoodId",
                table: "Ingredients");

            migrationBuilder.CreateTable(
                name: "IngredientWithFoods",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    FoodId = table.Column<long>(nullable: false),
                    Quantities = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientWithFoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientWithFoods_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientWithFoods_FoodId",
                table: "IngredientWithFoods",
                column: "FoodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientWithFoods");

            migrationBuilder.AddColumn<long>(
                name: "FoodId",
                table: "Ingredients",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_FoodId",
                table: "Ingredients",
                column: "FoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Foods_FoodId",
                table: "Ingredients",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
