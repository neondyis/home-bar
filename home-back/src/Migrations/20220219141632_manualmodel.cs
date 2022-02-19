using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace src.Migrations
{
    public partial class manualmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "brands",
                columns: table => new
                {
                    brand_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    brand_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brands", x => x.brand_id);
                });

            migrationBuilder.CreateTable(
                name: "cocktails",
                columns: table => new
                {
                    cocktail_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cocktail_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    cocktail_strength = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cocktails", x => x.cocktail_id);
                });

            migrationBuilder.CreateTable(
                name: "glasses",
                columns: table => new
                {
                    glass_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    glass_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_glasses", x => x.glass_id);
                });

            migrationBuilder.CreateTable(
                name: "measurement_types",
                columns: table => new
                {
                    measurement_type_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    measurement_type_unit = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_measurement_types", x => x.measurement_type_id);
                });

            migrationBuilder.CreateTable(
                name: "ingredients",
                columns: table => new
                {
                    liqueur_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ingredient_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    BrandId = table.Column<int>(type: "integer", nullable: false),
                    ingredient_type = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, defaultValue: "Syrup"),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    liqueur_percentage = table.Column<double>(type: "double precision", nullable: true),
                    liquor_percentage = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredients", x => x.liqueur_id);
                    table.ForeignKey(
                        name: "FK_ingredients_brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "brands",
                        principalColumn: "brand_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "instructions",
                columns: table => new
                {
                    instruction_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CocktailId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instructions", x => x.instruction_id);
                    table.ForeignKey(
                        name: "FK_instructions_cocktails_CocktailId",
                        column: x => x.CocktailId,
                        principalTable: "cocktails",
                        principalColumn: "cocktail_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "measurements",
                columns: table => new
                {
                    instruction_id = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_measurements", x => x.instruction_id);
                    table.ForeignKey(
                        name: "FK_measurements_measurement_types_instruction_id",
                        column: x => x.instruction_id,
                        principalTable: "measurement_types",
                        principalColumn: "measurement_type_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "instruction_steps",
                columns: table => new
                {
                    InstructionId = table.Column<int>(type: "integer", nullable: false),
                    step_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    step_number = table.Column<int>(type: "integer", nullable: false),
                    step_description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instruction_steps", x => x.InstructionId);
                    table.ForeignKey(
                        name: "FK_instruction_steps_instructions_InstructionId",
                        column: x => x.InstructionId,
                        principalTable: "instructions",
                        principalColumn: "instruction_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "recipe_ingredients",
                columns: table => new
                {
                    recipe_ingredient_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MeasurementId = table.Column<int>(type: "integer", nullable: false),
                    IngredientId = table.Column<int>(type: "integer", nullable: false),
                    CocktailId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipe_ingredients", x => x.recipe_ingredient_id);
                    table.ForeignKey(
                        name: "FK_recipe_ingredients_cocktails_CocktailId",
                        column: x => x.CocktailId,
                        principalTable: "cocktails",
                        principalColumn: "cocktail_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_recipe_ingredients_ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "ingredients",
                        principalColumn: "liqueur_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_recipe_ingredients_measurements_MeasurementId",
                        column: x => x.MeasurementId,
                        principalTable: "measurements",
                        principalColumn: "instruction_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ingredients_BrandId",
                table: "ingredients",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_instructions_CocktailId",
                table: "instructions",
                column: "CocktailId");

            migrationBuilder.CreateIndex(
                name: "IX_recipe_ingredients_CocktailId",
                table: "recipe_ingredients",
                column: "CocktailId");

            migrationBuilder.CreateIndex(
                name: "IX_recipe_ingredients_IngredientId",
                table: "recipe_ingredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_recipe_ingredients_MeasurementId",
                table: "recipe_ingredients",
                column: "MeasurementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "glasses");

            migrationBuilder.DropTable(
                name: "instruction_steps");

            migrationBuilder.DropTable(
                name: "recipe_ingredients");

            migrationBuilder.DropTable(
                name: "instructions");

            migrationBuilder.DropTable(
                name: "ingredients");

            migrationBuilder.DropTable(
                name: "measurements");

            migrationBuilder.DropTable(
                name: "cocktails");

            migrationBuilder.DropTable(
                name: "brands");

            migrationBuilder.DropTable(
                name: "measurement_types");
        }
    }
}
