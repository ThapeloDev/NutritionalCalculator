using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NutritionalCalculator.Model.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Api");

            migrationBuilder.CreateTable(
                name: "FoodCategories",
                schema: "Api",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                schema: "Api",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 150, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    ReferenceMassInGrams = table.Column<float>(nullable: true),
                    ReferenceVolumeInMililiters = table.Column<float>(nullable: true),
                    ReferenceUnits = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reference",
                schema: "Api",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 150, nullable: false),
                    Url = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reference", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Api",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    RoleName = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Api",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 150, nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: false),
                    FirstName = table.Column<string>(maxLength: 256, nullable: false),
                    LastName = table.Column<string>(maxLength: 256, nullable: false),
                    Email = table.Column<string>(maxLength: 256, nullable: false),
                    PasswordHash = table.Column<string>(nullable: false),
                    Unlockedaccount = table.Column<bool>(name: "Unlocked account", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

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
                name: "FoodInCategories",
                schema: "Api",
                columns: table => new
                {
                    FoodCategoryId = table.Column<short>(nullable: false),
                    FoodId = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodInCategories", x => new { x.FoodCategoryId, x.FoodId });
                    table.ForeignKey(
                        name: "FK_FoodInCategories___FoodCategory",
                        column: x => x.FoodCategoryId,
                        principalSchema: "Api",
                        principalTable: "FoodCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodInCategories___Foods",
                        column: x => x.FoodId,
                        principalSchema: "Api",
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Macronutrients",
                schema: "Api",
                columns: table => new
                {
                    IdFood = table.Column<string>(maxLength: 150, nullable: false),
                    Protein = table.Column<float>(nullable: true),
                    Carbohydrates = table.Column<double>(nullable: true),
                    Grease = table.Column<float>(nullable: true),
                    Fiber = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Macronutrients", x => x.IdFood);
                    table.ForeignKey(
                        name: "FK_Macronutrients__Foods",
                        column: x => x.IdFood,
                        principalSchema: "Api",
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Minerals",
                schema: "Api",
                columns: table => new
                {
                    IdFood = table.Column<string>(maxLength: 150, nullable: false),
                    Calcium = table.Column<float>(nullable: true),
                    Iron = table.Column<float>(nullable: true),
                    Sodium = table.Column<float>(nullable: true),
                    Phosphorus = table.Column<float>(nullable: true),
                    Iodo = table.Column<float>(nullable: true),
                    Fluorine = table.Column<float>(nullable: true),
                    Zinc = table.Column<float>(nullable: true),
                    Manganese = table.Column<float>(nullable: true),
                    Magnesium = table.Column<float>(nullable: true),
                    Potassium = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Minerals", x => x.IdFood);
                    table.ForeignKey(
                        name: "FK_Minerals__Foods",
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
                    table.PrimaryKey("PK_WaterSolubleVitamins", x => x.IdFood);
                    table.ForeignKey(
                        name: "FK_WaterSolubleVitamins__Foods",
                        column: x => x.IdFood,
                        principalSchema: "Api",
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodReferences",
                schema: "Api",
                columns: table => new
                {
                    IdFood = table.Column<string>(maxLength: 150, nullable: false),
                    IdReference = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodReferences", x => new { x.IdFood, x.IdReference });
                    table.ForeignKey(
                        name: "FK_FoodReferences__Foods",
                        column: x => x.IdFood,
                        principalSchema: "Api",
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodReferences__References",
                        column: x => x.IdReference,
                        principalSchema: "Api",
                        principalTable: "Reference",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsumedFoods",
                schema: "Api",
                columns: table => new
                {
                    IdUser = table.Column<string>(maxLength: 150, nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    NumberOfPlate = table.Column<byte>(nullable: false),
                    IdFood = table.Column<string>(maxLength: 150, nullable: false),
                    MassConsumedInGr = table.Column<float>(nullable: true),
                    VolumeConsumedInMl = table.Column<float>(nullable: true),
                    ConsumedUnits = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumedFoods", x => new { x.IdUser, x.Date, x.NumberOfPlate, x.IdFood });
                    table.ForeignKey(
                        name: "FK_ConsumedFoods__Foods",
                        column: x => x.IdFood,
                        principalSchema: "Api",
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConsumedFoods__Users",
                        column: x => x.IdUser,
                        principalSchema: "Api",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FoodsEditedByUsers",
                schema: "Api",
                columns: table => new
                {
                    UserId = table.Column<string>(maxLength: 150, nullable: false),
                    FoodId = table.Column<string>(maxLength: 150, nullable: false),
                    EditionDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Creation = table.Column<bool>(nullable: false),
                    Edition = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodsEditedByUsers", x => new { x.UserId, x.FoodId, x.EditionDate });
                    table.ForeignKey(
                        name: "FK_FoodsEditedByUsers__Foods",
                        column: x => x.FoodId,
                        principalSchema: "Api",
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodsEditedByUsers__Users",
                        column: x => x.UserId,
                        principalSchema: "Api",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersInRoles",
                schema: "Api",
                columns: table => new
                {
                    UserId = table.Column<string>(maxLength: 150, nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersInRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UsersInRoles__Roles",
                        column: x => x.RoleId,
                        principalSchema: "Api",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersInRoles__Users",
                        column: x => x.UserId,
                        principalSchema: "Api",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsumedFoods_IdFood",
                schema: "Api",
                table: "ConsumedFoods",
                column: "IdFood");

            migrationBuilder.CreateIndex(
                name: "IX_FoodInCategories_FoodId",
                schema: "Api",
                table: "FoodInCategories",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodReferences_IdReference",
                schema: "Api",
                table: "FoodReferences",
                column: "IdReference");

            migrationBuilder.CreateIndex(
                name: "IX_FoodsEditedByUsers_FoodId",
                schema: "Api",
                table: "FoodsEditedByUsers",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInRoles_RoleId",
                schema: "Api",
                table: "UsersInRoles",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsumedFoods",
                schema: "Api");

            migrationBuilder.DropTable(
                name: "FatSolubleVitamins",
                schema: "Api");

            migrationBuilder.DropTable(
                name: "FoodInCategories",
                schema: "Api");

            migrationBuilder.DropTable(
                name: "FoodReferences",
                schema: "Api");

            migrationBuilder.DropTable(
                name: "FoodsEditedByUsers",
                schema: "Api");

            migrationBuilder.DropTable(
                name: "Macronutrients",
                schema: "Api");

            migrationBuilder.DropTable(
                name: "Minerals",
                schema: "Api");

            migrationBuilder.DropTable(
                name: "UsersInRoles",
                schema: "Api");

            migrationBuilder.DropTable(
                name: "WaterSolubleVitamins",
                schema: "Api");

            migrationBuilder.DropTable(
                name: "FoodCategories",
                schema: "Api");

            migrationBuilder.DropTable(
                name: "Reference",
                schema: "Api");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Api");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Api");

            migrationBuilder.DropTable(
                name: "Foods",
                schema: "Api");
        }
    }
}
