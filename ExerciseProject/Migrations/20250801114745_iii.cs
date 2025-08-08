using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExerciseProject.Migrations
{
    /// <inheritdoc />
    public partial class iii : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SelectedExercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseNameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedExercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedExercises_ExerciseNames_ExerciseNameId",
                        column: x => x.ExerciseNameId,
                        principalTable: "ExerciseNames",
                        principalColumn: "ExerciseNameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SelectedExercises_ExerciseNameId",
                table: "SelectedExercises",
                column: "ExerciseNameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SelectedExercises");
        }
    }
}
