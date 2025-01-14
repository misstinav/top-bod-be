using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace top_bod_be.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NutritionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calories = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ServingInGrams = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalFatInGrams = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalProteinInGrams = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCarbsInGrams = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionDetails", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NutritionDetails");
        }
    }
}
