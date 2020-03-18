using Microsoft.EntityFrameworkCore.Migrations;

namespace NutritionalCalculator.Model.Migrations
{
    public partial class migration_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FatSolubleVitamins",
                schema: "Api");

            migrationBuilder.DropTable(
                name: "WaterSolubleVitamins",
                schema: "Api");

            migrationBuilder.DropColumn(
                name: "Fluorine",
                schema: "Api",
                table: "Minerals");

            migrationBuilder.DropColumn(
                name: "Magnesium",
                schema: "Api",
                table: "Minerals");

            migrationBuilder.AddColumn<float>(
                name: "Calories",
                schema: "Api",
                table: "Macronutrients",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FattyAcidsAndCholesterol",
                schema: "Api",
                columns: table => new
                {
                    IdFood = table.Column<string>(maxLength: 150, nullable: false),
                    SaturatedFat = table.Column<float>(nullable: true),
                    MonounsaturatedFat = table.Column<float>(nullable: true),
                    PolyunsaturatedFat = table.Column<float>(nullable: true),
                    Cholesterol = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FattyAcidsAndCholesterol", x => x.IdFood);
                    table.ForeignKey(
                        name: "FK_FattyAcidsAndCholesterol__Foods",
                        column: x => x.IdFood,
                        principalSchema: "Api",
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vitamins",
                schema: "Api",
                columns: table => new
                {
                    IdFood = table.Column<string>(maxLength: 150, nullable: false),
                    Thiamin = table.Column<float>(nullable: true),
                    Riboflavin = table.Column<float>(nullable: true),
                    Niacin = table.Column<float>(nullable: true),
                    PantothenicAcid = table.Column<float>(nullable: true),
                    Pyridoxine = table.Column<float>(nullable: true),
                    VitaminB12 = table.Column<float>(nullable: true),
                    VitaminC = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vitamins", x => x.IdFood);
                    table.ForeignKey(
                        name: "FK_Vitamins__Foods",
                        column: x => x.IdFood,
                        principalSchema: "Api",
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FattyAcidsAndCholesterol",
                schema: "Api");

            migrationBuilder.DropTable(
                name: "Vitamins",
                schema: "Api");

            migrationBuilder.DropColumn(
                name: "Calories",
                schema: "Api",
                table: "Macronutrients");

            migrationBuilder.AddColumn<float>(
                name: "Fluorine",
                schema: "Api",
                table: "Minerals",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Magnesium",
                schema: "Api",
                table: "Minerals",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FatSolubleVitamins",
                schema: "Api",
                columns: table => new
                {
                    IdFood = table.Column<string>(maxLength: 150, nullable: false),
                    VitaminA = table.Column<float>(nullable: true),
                    VitaminD = table.Column<float>(nullable: true),
                    VitaminE = table.Column<float>(nullable: true),
                    VitaminK = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FatSolubleVitamins", x => x.IdFood);
                    table.ForeignKey(
                        name: "FK_FatSolubleVitamins__Foods",
                        column: x => x.IdFood,
                        principalSchema: "Api",
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WaterSolubleVitamins",
                schema: "Api",
                columns: table => new
                {
                    IdFood = table.Column<string>(maxLength: 150, nullable: false),
                    Niacin = table.Column<float>(nullable: true),
                    PantothenicAcid = table.Column<float>(nullable: true),
                    Pyridoxine = table.Column<float>(nullable: true),
                    Riboflavin = table.Column<float>(nullable: true),
                    Thiamin = table.Column<float>(nullable: true),
                    VitaminB12 = table.Column<float>(nullable: true),
                    VitaminC = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterSolubleVitamins", x => x.IdFood);
                    table.ForeignKey(
                        name: "FK_WaterSolubleVitamins__Foods",
                        column: x => x.IdFood,
                        principalSchema: "Api",
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
