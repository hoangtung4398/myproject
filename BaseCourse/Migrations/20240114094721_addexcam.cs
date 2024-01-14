using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseCourse.Migrations
{
    /// <inheritdoc />
    public partial class addexcam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseExam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseExam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseExam_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseExamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_CourseExam_CourseExamId",
                        column: x => x.CourseExamId,
                        principalTable: "CourseExam",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserExam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<int>(type: "int", nullable: false),
                    AnswerAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourseExamId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserExam_CourseExam_CourseExamId",
                        column: x => x.CourseExamId,
                        principalTable: "CourseExam",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserExam_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRight = table.Column<bool>(type: "bit", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answer_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ResultExam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TakeAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AnswerId = table.Column<int>(type: "int", nullable: true),
                    QuestionId = table.Column<int>(type: "int", nullable: true),
                    UserExamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultExam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultExam_Answer_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ResultExam_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ResultExam_UserExam_UserExamId",
                        column: x => x.UserExamId,
                        principalTable: "UserExam",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_QuestionId",
                table: "Answer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseExam_CourseId",
                table: "CourseExam",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_CourseExamId",
                table: "Question",
                column: "CourseExamId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultExam_AnswerId",
                table: "ResultExam",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultExam_QuestionId",
                table: "ResultExam",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultExam_UserExamId",
                table: "ResultExam",
                column: "UserExamId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExam_CourseExamId",
                table: "UserExam",
                column: "CourseExamId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExam_UserId",
                table: "UserExam",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResultExam");

            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "UserExam");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "CourseExam");
        }
    }
}
