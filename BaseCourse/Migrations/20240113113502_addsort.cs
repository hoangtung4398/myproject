using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseCourse.Migrations
{
    /// <inheritdoc />
    public partial class addsort : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "Section",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "Lecture",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Lecture");
        }
    }
}
