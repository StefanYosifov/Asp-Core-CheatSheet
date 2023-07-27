using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _Project_CheatSheet.Data.Migrations
{
    public partial class removingIssueTopicRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TopicIssues");

            migrationBuilder.AddColumn<Guid>(
                name: "TopicId",
                table: "Issues",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Issues_TopicId",
                table: "Issues",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Topics_TopicId",
                table: "Issues",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Topics_TopicId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_TopicId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Issues");

            migrationBuilder.CreateTable(
                name: "TopicIssues",
                columns: table => new
                {
                    IssueId = table.Column<int>(type: "int", nullable: false),
                    TopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicIssues", x => new { x.IssueId, x.TopicId });
                    table.ForeignKey(
                        name: "FK_TopicIssues_Issues_IssueId",
                        column: x => x.IssueId,
                        principalTable: "Issues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicIssues_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TopicIssues_TopicId",
                table: "TopicIssues",
                column: "TopicId");
        }
    }
}
