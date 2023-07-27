using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _Project_CheatSheet.Data.Migrations
{
    public partial class MissingDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_CategoryIssue_CategoryIssueId",
                table: "Issues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryIssue",
                table: "CategoryIssue");

            migrationBuilder.RenameTable(
                name: "CategoryIssue",
                newName: "CategoriesIssues");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoriesIssues",
                table: "CategoriesIssues",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_CategoriesIssues_CategoryIssueId",
                table: "Issues",
                column: "CategoryIssueId",
                principalTable: "CategoriesIssues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_CategoriesIssues_CategoryIssueId",
                table: "Issues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoriesIssues",
                table: "CategoriesIssues");

            migrationBuilder.RenameTable(
                name: "CategoriesIssues",
                newName: "CategoryIssue");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryIssue",
                table: "CategoryIssue",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_CategoryIssue_CategoryIssueId",
                table: "Issues",
                column: "CategoryIssueId",
                principalTable: "CategoryIssue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
