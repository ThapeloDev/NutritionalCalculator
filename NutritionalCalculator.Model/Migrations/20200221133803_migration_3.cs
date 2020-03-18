using Microsoft.EntityFrameworkCore.Migrations;

namespace NutritionalCalculator.Model.Migrations
{
    public partial class migration_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pyridoxine",
                schema: "Api",
                table: "Vitamins",
                newName: "VitaminA");

            migrationBuilder.RenameColumn(
                name: "PantothenicAcid",
                schema: "Api",
                table: "Vitamins",
                newName: "Folatos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VitaminA",
                schema: "Api",
                table: "Vitamins",
                newName: "Pyridoxine");

            migrationBuilder.RenameColumn(
                name: "Folatos",
                schema: "Api",
                table: "Vitamins",
                newName: "PantothenicAcid");
        }
    }
}
