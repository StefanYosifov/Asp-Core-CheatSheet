using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _Project_CheatSheet.Data.Migrations
{
    public partial class UpdatingDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryCourseCourses_CategoryCourse_CategoryCourseId",
                table: "CategoryCourseCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryCourse",
                table: "CategoryCourse");

            migrationBuilder.RenameTable(
                name: "CategoryCourse",
                newName: "CategoryCourses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryCourses",
                table: "CategoryCourses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryCourseCourses_CategoryCourses_CategoryCourseId",
                table: "CategoryCourseCourses",
                column: "CategoryCourseId",
                principalTable: "CategoryCourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryCourseCourses_CategoryCourses_CategoryCourseId",
                table: "CategoryCourseCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryCourses",
                table: "CategoryCourses");

            migrationBuilder.RenameTable(
                name: "CategoryCourses",
                newName: "CategoryCourse");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryCourse",
                table: "CategoryCourse",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryCourseCourses_CategoryCourse_CategoryCourseId",
                table: "CategoryCourseCourses",
                column: "CategoryCourseId",
                principalTable: "CategoryCourse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
