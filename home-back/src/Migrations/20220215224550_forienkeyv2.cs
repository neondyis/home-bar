using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace src.Migrations
{
    public partial class forienkeyv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_Cocktails_CocktailId",
                table: "RecipeIngredients");

            migrationBuilder.AlterColumn<int>(
                name: "CocktailId",
                table: "RecipeIngredients",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_Cocktails_CocktailId",
                table: "RecipeIngredients",
                column: "CocktailId",
                principalTable: "Cocktails",
                principalColumn: "CocktailId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_Cocktails_CocktailId",
                table: "RecipeIngredients");

            migrationBuilder.AlterColumn<int>(
                name: "CocktailId",
                table: "RecipeIngredients",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_Cocktails_CocktailId",
                table: "RecipeIngredients",
                column: "CocktailId",
                principalTable: "Cocktails",
                principalColumn: "CocktailId");
        }
    }
}
