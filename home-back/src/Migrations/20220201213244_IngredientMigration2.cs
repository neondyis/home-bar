using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace src.Migrations
{
    public partial class IngredientMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Liquers_Brands_BrandId",
                table: "Liquers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Liquers",
                table: "Liquers");

            migrationBuilder.DropColumn(
                name: "LiqueurId",
                table: "Liquers");

            migrationBuilder.RenameTable(
                name: "Liquers",
                newName: "Ingredients");

            migrationBuilder.RenameIndex(
                name: "IX_Liquers_BrandId",
                table: "Ingredients",
                newName: "IX_Ingredients_BrandId");

            migrationBuilder.AlterColumn<double>(
                name: "Percentage",
                table: "Ingredients",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<int>(
                name: "IngredientId",
                table: "Ingredients",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Ingredients",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Liquor_Percentage",
                table: "Ingredients",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients",
                column: "IngredientId");

            migrationBuilder.CreateTable(
                name: "Glasses",
                columns: table => new
                {
                    GlassId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Glasses", x => x.GlassId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Brands_BrandId",
                table: "Ingredients",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Brands_BrandId",
                table: "Ingredients");

            migrationBuilder.DropTable(
                name: "Glasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Liquor_Percentage",
                table: "Ingredients");

            migrationBuilder.RenameTable(
                name: "Ingredients",
                newName: "Liquers");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredients_BrandId",
                table: "Liquers",
                newName: "IX_Liquers_BrandId");

            migrationBuilder.AlterColumn<double>(
                name: "Percentage",
                table: "Liquers",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IngredientId",
                table: "Liquers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "LiqueurId",
                table: "Liquers",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Liquers",
                table: "Liquers",
                column: "LiqueurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Liquers_Brands_BrandId",
                table: "Liquers",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
