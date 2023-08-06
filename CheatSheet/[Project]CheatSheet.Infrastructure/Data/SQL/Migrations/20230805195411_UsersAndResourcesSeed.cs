using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _Project_CheatSheet.Data.Migrations
{
    public partial class UsersAndResourcesSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileBackground", "ProfileDescription", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "UpdatedBy", "UpdatedOn", "UserEducation", "UserJob", "UserName" },
                values: new object[,]
                {
                    { "341e7640-881b-4ba5-a7cd-da4d7c8db203", 0, "a95bd67f-e2df-475d-ba00-405ec08c0c05", "admin", new DateTime(2023, 8, 5, 19, 54, 11, 319, DateTimeKind.Utc).AddTicks(3527), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", false, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEDKe2n1Y/5E49Nav6HYjHaUzJQrsooMjoPyx4Zl2ptkoqy/IfmyUmpRK7Hw1ROFiag==", null, false, null, "This is my in-depth description", null, "87fb375f-bf38-4acd-bdbe-984649f9c2fc", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "At Harvard", "Working from home", "administrator" },
                    { "48e5b1d3-cd95-41c9-9ae9-718765be6338", 0, "f29d3d99-8e65-4044-82af-8c57687212d9", "admin", new DateTime(2023, 8, 5, 19, 54, 11, 319, DateTimeKind.Utc).AddTicks(3556), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", false, false, false, null, null, "JANE_SMITH", "AQAAAAEAACcQAAAAECxaCV/2PikmiTo8QNTgcP4gFP7RrsqpZMAK5ghGJmh9YU7pJouhFzwdrcTr/OGnpA==", null, false, null, "Passionate about creating beautiful designs.", null, "fe493286-8e8d-4677-83d3-6b9d31a25d21", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Art Institute", "Graphic Designer", "jane_smith" },
                    { "7df422ab-b2e1-450d-a773-c960d17e3e09", 0, "2c16b144-67ac-4f7f-8512-4157e5c72170", "admin", new DateTime(2023, 8, 5, 19, 54, 11, 319, DateTimeKind.Utc).AddTicks(3545), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", false, false, false, null, null, "JOHN_DOE", "AQAAAAEAACcQAAAAEGaeyVi9mx1IZ86lQhWGDUNzjYiSKnWkZSuiDnVACmU35yx90fTSgwlw+YkWh+wTMg==", null, false, null, "I love coding and building cool applications!", null, "cd07dadb-d1d9-4ba3-b599-841979d160de", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Self-taught", "Software Engineer", "john_doe" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 11, "Arrays" },
                    { 12, "Data structures" },
                    { 13, "Algorithms" },
                    { 14, "Object-Oriented Programming" },
                    { 15, "Recursion" },
                    { 16, "Sorting" },
                    { 17, "Graph Theory" },
                    { 18, "Dynamic Programming" },
                    { 19, "Artificial Intelligence" },
                    { 20, "Database Management" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "341e7640-881b-4ba5-a7cd-da4d7c8db203" });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "ImageUrl", "IsDeleted", "IsPublic", "Title", "UpdatedBy", "UpdatedOn", "UserId" },
                values: new object[,]
                {
                    { new Guid("2d50f369-c713-47eb-bc81-2dfc150e73c0"), "An introductory course to machine learning algorithms and techniques.", "administrator", new DateTime(2023, 8, 5, 19, 54, 11, 338, DateTimeKind.Utc).AddTicks(1405), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.example.com/images/intro_to_ml.jpg", false, true, "Introduction to Machine Learning", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "341e7640-881b-4ba5-a7cd-da4d7c8db203" },
                    { new Guid("7a51c1d2-7590-46a7-8540-38411ce630b9"), "Learn how to use Python for data analysis, visualization, and machine learning.", "administrator", new DateTime(2023, 8, 5, 19, 54, 11, 338, DateTimeKind.Utc).AddTicks(1404), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.example.com/images/python_data_science.jpg", false, true, "Python for Data Science", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "341e7640-881b-4ba5-a7cd-da4d7c8db203" },
                    { new Guid("84159dce-3fb9-4b09-ab68-ea8113539561"), "Take your JavaScript skills to the next level with our comprehensive JavaScript Advanced course.learning.\r\nPrerequisites:\r\nThis course is de", "administrator", new DateTime(2023, 8, 5, 19, 54, 11, 338, DateTimeKind.Utc).AddTicks(1387), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.ytimg.com/vi/YT8s-90oDC0/maxresdefault.jpg", false, true, "Javascript Advanced 2023", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "341e7640-881b-4ba5-a7cd-da4d7c8db203" },
                    { new Guid("94657488-0349-45e4-8224-66594d0e267e"), "Explore the fundamentals of artificial intelligence and its applications.", "administrator", new DateTime(2023, 8, 5, 19, 54, 11, 338, DateTimeKind.Utc).AddTicks(1409), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.example.com/images/intro_to_ai.jpg", false, true, "Introduction to Artificial Intelligence", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "341e7640-881b-4ba5-a7cd-da4d7c8db203" },
                    { new Guid("ccea7bf5-88b4-4851-80d6-c40240b8a066"), "C# advanced is a nice course to learn, to become better", "administrator", new DateTime(2023, 8, 5, 19, 54, 11, 338, DateTimeKind.Utc).AddTicks(1381), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.filepicker.io/api/file/2ZsQkVfR0yhZPRO33JEw", false, true, "C# Advanced 1 2023", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "341e7640-881b-4ba5-a7cd-da4d7c8db203" },
                    { new Guid("ceb5990a-222b-4b2a-a57b-5404bfb8c79d"), "Master the art of building modern web applications using React.js.", "administrator", new DateTime(2023, 8, 5, 19, 54, 11, 338, DateTimeKind.Utc).AddTicks(1407), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.example.com/images/react_web_dev.jpg", false, true, "Web Development with React", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "341e7640-881b-4ba5-a7cd-da4d7c8db203" },
                    { new Guid("d7b9a245-d1bc-400e-b66e-079c0ce21548"), "C# advanced is a nice course to learn, to become better", "administrator", new DateTime(2023, 8, 5, 19, 54, 11, 338, DateTimeKind.Utc).AddTicks(1385), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.filepicker.io/api/file/2ZsQkVfR0yhZPRO33JEw", false, true, "C# Advanced 2 2023", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "341e7640-881b-4ba5-a7cd-da4d7c8db203" }
                });

            migrationBuilder.InsertData(
                table: "CategoriesResources",
                columns: new[] { "CategoryId", "ResourceId" },
                values: new object[,]
                {
                    { 11, new Guid("ccea7bf5-88b4-4851-80d6-c40240b8a066") },
                    { 12, new Guid("84159dce-3fb9-4b09-ab68-ea8113539561") },
                    { 13, new Guid("7a51c1d2-7590-46a7-8540-38411ce630b9") },
                    { 13, new Guid("94657488-0349-45e4-8224-66594d0e267e") },
                    { 14, new Guid("2d50f369-c713-47eb-bc81-2dfc150e73c0") },
                    { 15, new Guid("94657488-0349-45e4-8224-66594d0e267e") },
                    { 15, new Guid("ccea7bf5-88b4-4851-80d6-c40240b8a066") },
                    { 15, new Guid("ceb5990a-222b-4b2a-a57b-5404bfb8c79d") },
                    { 16, new Guid("94657488-0349-45e4-8224-66594d0e267e") },
                    { 16, new Guid("d7b9a245-d1bc-400e-b66e-079c0ce21548") },
                    { 17, new Guid("84159dce-3fb9-4b09-ab68-ea8113539561") },
                    { 18, new Guid("7a51c1d2-7590-46a7-8540-38411ce630b9") },
                    { 19, new Guid("2d50f369-c713-47eb-bc81-2dfc150e73c0") },
                    { 19, new Guid("ceb5990a-222b-4b2a-a57b-5404bfb8c79d") },
                    { 20, new Guid("94657488-0349-45e4-8224-66594d0e267e") },
                    { 20, new Guid("d7b9a245-d1bc-400e-b66e-079c0ce21548") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "IsDeleted", "ResourceId", "UpdatedBy", "UpdatedOn", "UserId" },
                values: new object[,]
                {
                    { new Guid("21ee6178-9eec-4f6f-afb1-fb8460d19faf"), "This is comment send by seeded admin", "administrator", new DateTime(2023, 8, 5, 19, 54, 11, 338, DateTimeKind.Utc).AddTicks(1434), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("2d50f369-c713-47eb-bc81-2dfc150e73c0"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "341e7640-881b-4ba5-a7cd-da4d7c8db203" },
                    { new Guid("515353a0-33e5-4c74-ab50-673c2ee5e8b1"), "This is comment send by seeded admin", "administrator", new DateTime(2023, 8, 5, 19, 54, 11, 338, DateTimeKind.Utc).AddTicks(1436), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("ceb5990a-222b-4b2a-a57b-5404bfb8c79d"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "341e7640-881b-4ba5-a7cd-da4d7c8db203" },
                    { new Guid("56956421-bb46-491f-9a62-b23ae98b23a0"), "This is comment send by seeded admin", "administrator", new DateTime(2023, 8, 5, 19, 54, 11, 338, DateTimeKind.Utc).AddTicks(1433), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("7a51c1d2-7590-46a7-8540-38411ce630b9"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "341e7640-881b-4ba5-a7cd-da4d7c8db203" },
                    { new Guid("d1903659-fb76-4042-bb5e-bb597c631cca"), "This is comment send by seeded admin", "administrator", new DateTime(2023, 8, 5, 19, 54, 11, 338, DateTimeKind.Utc).AddTicks(1431), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("d7b9a245-d1bc-400e-b66e-079c0ce21548"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "341e7640-881b-4ba5-a7cd-da4d7c8db203" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "341e7640-881b-4ba5-a7cd-da4d7c8db203" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "48e5b1d3-cd95-41c9-9ae9-718765be6338");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7df422ab-b2e1-450d-a773-c960d17e3e09");

            migrationBuilder.DeleteData(
                table: "CategoriesResources",
                keyColumns: new[] { "CategoryId", "ResourceId" },
                keyValues: new object[] { 11, new Guid("ccea7bf5-88b4-4851-80d6-c40240b8a066") });

            migrationBuilder.DeleteData(
                table: "CategoriesResources",
                keyColumns: new[] { "CategoryId", "ResourceId" },
                keyValues: new object[] { 12, new Guid("84159dce-3fb9-4b09-ab68-ea8113539561") });

            migrationBuilder.DeleteData(
                table: "CategoriesResources",
                keyColumns: new[] { "CategoryId", "ResourceId" },
                keyValues: new object[] { 13, new Guid("7a51c1d2-7590-46a7-8540-38411ce630b9") });

            migrationBuilder.DeleteData(
                table: "CategoriesResources",
                keyColumns: new[] { "CategoryId", "ResourceId" },
                keyValues: new object[] { 13, new Guid("94657488-0349-45e4-8224-66594d0e267e") });

            migrationBuilder.DeleteData(
                table: "CategoriesResources",
                keyColumns: new[] { "CategoryId", "ResourceId" },
                keyValues: new object[] { 14, new Guid("2d50f369-c713-47eb-bc81-2dfc150e73c0") });

            migrationBuilder.DeleteData(
                table: "CategoriesResources",
                keyColumns: new[] { "CategoryId", "ResourceId" },
                keyValues: new object[] { 15, new Guid("94657488-0349-45e4-8224-66594d0e267e") });

            migrationBuilder.DeleteData(
                table: "CategoriesResources",
                keyColumns: new[] { "CategoryId", "ResourceId" },
                keyValues: new object[] { 15, new Guid("ccea7bf5-88b4-4851-80d6-c40240b8a066") });

            migrationBuilder.DeleteData(
                table: "CategoriesResources",
                keyColumns: new[] { "CategoryId", "ResourceId" },
                keyValues: new object[] { 15, new Guid("ceb5990a-222b-4b2a-a57b-5404bfb8c79d") });

            migrationBuilder.DeleteData(
                table: "CategoriesResources",
                keyColumns: new[] { "CategoryId", "ResourceId" },
                keyValues: new object[] { 16, new Guid("94657488-0349-45e4-8224-66594d0e267e") });

            migrationBuilder.DeleteData(
                table: "CategoriesResources",
                keyColumns: new[] { "CategoryId", "ResourceId" },
                keyValues: new object[] { 16, new Guid("d7b9a245-d1bc-400e-b66e-079c0ce21548") });

            migrationBuilder.DeleteData(
                table: "CategoriesResources",
                keyColumns: new[] { "CategoryId", "ResourceId" },
                keyValues: new object[] { 17, new Guid("84159dce-3fb9-4b09-ab68-ea8113539561") });

            migrationBuilder.DeleteData(
                table: "CategoriesResources",
                keyColumns: new[] { "CategoryId", "ResourceId" },
                keyValues: new object[] { 18, new Guid("7a51c1d2-7590-46a7-8540-38411ce630b9") });

            migrationBuilder.DeleteData(
                table: "CategoriesResources",
                keyColumns: new[] { "CategoryId", "ResourceId" },
                keyValues: new object[] { 19, new Guid("2d50f369-c713-47eb-bc81-2dfc150e73c0") });

            migrationBuilder.DeleteData(
                table: "CategoriesResources",
                keyColumns: new[] { "CategoryId", "ResourceId" },
                keyValues: new object[] { 19, new Guid("ceb5990a-222b-4b2a-a57b-5404bfb8c79d") });

            migrationBuilder.DeleteData(
                table: "CategoriesResources",
                keyColumns: new[] { "CategoryId", "ResourceId" },
                keyValues: new object[] { 20, new Guid("94657488-0349-45e4-8224-66594d0e267e") });

            migrationBuilder.DeleteData(
                table: "CategoriesResources",
                keyColumns: new[] { "CategoryId", "ResourceId" },
                keyValues: new object[] { 20, new Guid("d7b9a245-d1bc-400e-b66e-079c0ce21548") });

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("21ee6178-9eec-4f6f-afb1-fb8460d19faf"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("515353a0-33e5-4c74-ab50-673c2ee5e8b1"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("56956421-bb46-491f-9a62-b23ae98b23a0"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("d1903659-fb76-4042-bb5e-bb597c631cca"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("2d50f369-c713-47eb-bc81-2dfc150e73c0"));

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("7a51c1d2-7590-46a7-8540-38411ce630b9"));

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("84159dce-3fb9-4b09-ab68-ea8113539561"));

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("94657488-0349-45e4-8224-66594d0e267e"));

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("ccea7bf5-88b4-4851-80d6-c40240b8a066"));

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("ceb5990a-222b-4b2a-a57b-5404bfb8c79d"));

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("d7b9a245-d1bc-400e-b66e-079c0ce21548"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341e7640-881b-4ba5-a7cd-da4d7c8db203");
        }
    }
}
