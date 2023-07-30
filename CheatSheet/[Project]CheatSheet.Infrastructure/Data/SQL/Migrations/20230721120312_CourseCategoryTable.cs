using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _Project_CheatSheet.Data.Migrations
{
    public partial class CourseCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Courses");

            migrationBuilder.CreateTable(
                name: "CategoryCourse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryCourse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryCourseCourses",
                columns: table => new
                {
                    CategoryCourseId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryCourseCourses", x => new { x.CourseId, x.CategoryCourseId });
                    table.ForeignKey(
                        name: "FK_CategoryCourseCourses_CategoryCourse_CategoryCourseId",
                        column: x => x.CategoryCourseId,
                        principalTable: "CategoryCourse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoryCourseCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryCourseCourses_CategoryCourseId",
                table: "CategoryCourseCourses",
                column: "CategoryCourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryCourseCourses");

            migrationBuilder.DropTable(
                name: "CategoryCourse");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
