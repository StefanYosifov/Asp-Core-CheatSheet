using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _Project_CheatSheet.Data.Migrations
{
    public partial class IssueLimitedToTopicsOnly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Courses_CourseId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_CourseId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Issues");

            migrationBuilder.CreateTable(
                name: "TopicIssues",
                columns: table => new
                {
                    TopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IssueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicIssues", x => new { x.IssueId, x.TopicId });
                    table.ForeignKey(
                        name: "FK_TopicIssues_Issues_IssueId",
                        column: x => x.IssueId,
                        principalTable: "Issues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TopicIssues_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TopicIssues_TopicId",
                table: "TopicIssues",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TopicIssues");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "Issues",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Issues_CourseId",
                table: "Issues",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Courses_CourseId",
                table: "Issues",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}