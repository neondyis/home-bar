using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace src.Migrations
{
    public partial class IngredientMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Liquers",
                table: "Liquers");

            migrationBuilder.RenameColumn(
                name: "LiquerName",
                table: "Liquers",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "LiquerId",
                table: "Liquers",
                newName: "IngredientId");

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

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Liquers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Percentage",
                table: "Liquers",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Liquers",
                table: "Liquers",
                column: "LiqueurId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Liquers",
                table: "Liquers");

            migrationBuilder.DropColumn(
                name: "LiqueurId",
                table: "Liquers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Liquers");

            migrationBuilder.DropColumn(
                name: "Percentage",
                table: "Liquers");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Liquers",
                newName: "LiquerName");

            migrationBuilder.RenameColumn(
                name: "IngredientId",
                table: "Liquers",
                newName: "LiquerId");

            migrationBuilder.AlterColumn<int>(
                name: "LiquerId",
                table: "Liquers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Liquers",
                table: "Liquers",
                column: "LiquerId");
        }
    }
}
