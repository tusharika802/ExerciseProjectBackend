using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExerciseProject.Migrations
{
    /// <inheritdoc />
    public partial class initload : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExerciseTypes",
                columns: table => new
                {
                    ExerciseTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseTypes", x => x.ExerciseTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseNames",
                columns: table => new
                {
                    ExerciseNameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseNamee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExerciseCode = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ExerciseTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseNames", x => x.ExerciseNameId);
                    table.ForeignKey(
                        name: "FK_ExerciseNames_ExerciseTypes_ExerciseTypeId",
                        column: x => x.ExerciseTypeId,
                        principalTable: "ExerciseTypes",
                        principalColumn: "ExerciseTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseNames_ExerciseTypeId",
                table: "ExerciseNames",
                column: "ExerciseTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseNames");

            migrationBuilder.DropTable(
                name: "ExerciseTypes");
        }
    }
}
