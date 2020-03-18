using Microsoft.EntityFrameworkCore.Migrations;

namespace NutritionalCalculator.Model.Migrations
{
    public partial class migration_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Folatos",
                schema: "Api",
                table: "Vitamins",
                newName: "Folates");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Folates",
                schema: "Api",
                table: "Vitamins",
                newName: "Folatos");
        }
    }
}
