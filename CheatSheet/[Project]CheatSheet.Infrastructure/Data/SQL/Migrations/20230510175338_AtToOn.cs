using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _Project_CheatSheet.Data.Migrations
{
    public partial class AtToOn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Resources",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Resources",
                newName: "DeletedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Resources",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Comments",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Comments",
                newName: "DeletedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Comments",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "CommentLikes",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "AspNetUsers",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "AspNetUsers",
                newName: "DeletedOn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "Resources",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "DeletedOn",
                table: "Resources",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Resources",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "Comments",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "DeletedOn",
                table: "Comments",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Comments",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "CommentLikes",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "AspNetUsers",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "DeletedOn",
                table: "AspNetUsers",
                newName: "DeletedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
