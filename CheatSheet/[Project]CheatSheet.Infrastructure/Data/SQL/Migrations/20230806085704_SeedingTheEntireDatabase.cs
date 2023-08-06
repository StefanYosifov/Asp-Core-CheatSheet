using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _Project_CheatSheet.Data.Migrations
{
    public partial class SeedingTheEntireDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Courses",
                type: "nvarchar(max)",
                maxLength: 10000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileBackground", "ProfileDescription", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "UpdatedBy", "UpdatedOn", "UserEducation", "UserJob", "UserName" },
                values: new object[,]
                {
                    { "69d67468-e0d1-44b5-8b9a-719889b230b9", 0, "ab902a04-a484-4b80-a339-432073d0a348", "admin", new DateTime(2023, 8, 6, 8, 57, 3, 675, DateTimeKind.Utc).AddTicks(6071), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", false, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEN70t397JeZeZgizgdHP0KTNHyq5Phhmy6gJ7hq2/H7XT47lDJ+cOuoHk0cWNOAN4A==", null, false, null, "This is my in-depth description", null, "c3a11ee6-46cf-418a-bcf5-3c4e193000fe", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "At Harvard", "Working from home", "administrator" },
                    { "e2432f3d-489e-4230-81ff-b110e80cc165", 0, "0c0840ce-76fe-4650-a235-aaa48ee2f5f1", "admin", new DateTime(2023, 8, 6, 8, 57, 3, 675, DateTimeKind.Utc).AddTicks(6099), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", false, false, false, null, null, "JANE_SMITH", "AQAAAAEAACcQAAAAEBP7Gtp7JHbAqrg3MirV+IibBeGIUdSVaFN8pQlqZymHU2qpkW1pZn/MUgVTlU5xew==", null, false, null, "Passionate about creating beautiful designs.", null, "bbdf9735-d833-4c30-a6cc-e7e6ceb52f4f", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Art Institute", "Graphic Designer", "jane_smith" },
                    { "fc5d084d-38d6-4ff0-abe6-abb2e1e3f323", 0, "68d97103-9f8f-4528-b001-5a0bc9a6fc27", "admin", new DateTime(2023, 8, 6, 8, 57, 3, 675, DateTimeKind.Utc).AddTicks(6089), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", false, false, false, null, null, "JOHN_DOE", "AQAAAAEAACcQAAAAENzPfuoq+vP5CAVikqeMsV4S1j1ikT24kQeinOwZVoSCgePrgQiDQzQsh7c/ArEigg==", null, false, null, "I love coding and building cool applications!", null, "209979ec-2418-421e-a9c2-bde190f7ce1a", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Self-taught", "Software Engineer", "john_doe" }
                });

            migrationBuilder.InsertData(
                table: "CategoriesIssues",
                columns: new[] { "Id", "LocationIssue" },
                values: new object[,]
                {
                    { 1, "Problem with the title" },
                    { 2, "Problem with the description" },
                    { 3, "Problem with the video" },
                    { 4, "Problem with the pdf file" }
                });

            migrationBuilder.InsertData(
                table: "CategoryCourses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 21, "Web" },
                    { 22, "Django" },
                    { 23, "Flask" },
                    { 24, "Python" },
                    { 25, "JavaScript" },
                    { 26, ".Net" },
                    { 27, "MVC" },
                    { 28, "API" },
                    { 29, "Databases" },
                    { 30, "C#" },
                    { 31, "Java" },
                    { 32, "Math" },
                    { 33, "Windows" },
                    { 34, "Servers" },
                    { 35, "DataStructures" },
                    { 36, "Security" },
                    { 37, "UX/UI Design" },
                    { 38, "Photography and Design" },
                    { 39, "Artificial Intelligence" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "EndDate", "ImageUrl", "Price", "StartDate", "Title", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("10838b25-d523-41f2-bf93-04302f1c79c9"), "admin", new DateTime(2023, 8, 6, 8, 57, 3, 693, DateTimeKind.Utc).AddTicks(5608), "Discover the world of ethical hacking and cybersecurity, where you'll learn to defend against cyber threats and secure digital assets. Explore common attack vectors, penetration testing techniques, and vulnerability assessment methods. With hands-on labs, you'll gain practical experience in identifying and mitigating security risks. Prepare yourself to become a cybersecurity expert and contribute to a safer online world.", new DateTime(2023, 11, 6, 8, 57, 3, 693, DateTimeKind.Utc).AddTicks(5609), "https://www.udacity.com/www-proxy/contentful/assets/2y9b3o528xhq/4PjDlJzjwAB1tWZ5qL93cz/df5750f8ec5fad0c11b8f9d0582d5f0b/SEO-Image-4.jpg", 89.99m, new DateTime(2023, 8, 6, 8, 57, 3, 693, DateTimeKind.Utc).AddTicks(5609), "Introduction to Ethical Hacking and Cybersecurity", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("320439e3-1b9b-4a8e-9f88-97b85cfd0ab7"), "admin", new DateTime(2023, 8, 6, 8, 57, 3, 693, DateTimeKind.Utc).AddTicks(5615), "Dive into the fascinating world of data science and machine learning with our comprehensive Python course. Discover how to manipulate and analyze data, build predictive models, and derive valuable insights from complex datasets. Whether you're a data enthusiast or aspiring data scientist, this course will equip you with the essential skills to excel in the data-driven industry.", new DateTime(2023, 12, 6, 8, 57, 3, 693, DateTimeKind.Utc).AddTicks(5615), "https://cdn.mindmajix.com/courses/python-training.png", 99.99m, new DateTime(2023, 8, 6, 8, 57, 3, 693, DateTimeKind.Utc).AddTicks(5615), "Python for Data Science and Machine Learning", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("87df5fa0-4c6e-4ae5-8b8c-6b6aca412107"), "admin", new DateTime(2023, 8, 6, 8, 57, 3, 693, DateTimeKind.Utc).AddTicks(5606), "Unleash your creative potential and capture stunning images with our Photography Fundamentals course. Learn about camera settings, composition, lighting, and post-processing techniques to bring your photographs to life. Whether you're using a DSLR, mirrorless, or smartphone camera, this course will help you master the art of photography and tell captivating visual stories.", new DateTime(2023, 9, 6, 8, 57, 3, 693, DateTimeKind.Utc).AddTicks(5607), "https://cdn01.alison-static.net/courses/1326/alison_courseware_intro_1326.jpg", 39.99m, new DateTime(2023, 8, 6, 8, 57, 3, 693, DateTimeKind.Utc).AddTicks(5606), "Photography Fundamentals for Beginners", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("adcd69ea-02d8-4990-bd6e-5dfbe9fef815"), "admin", new DateTime(2023, 8, 6, 8, 57, 3, 693, DateTimeKind.Utc).AddTicks(5613), "Delve into the cutting-edge field of Artificial Intelligence (AI) and explore its diverse applications. This course provides a solid foundation in AI concepts, including machine learning, neural networks, natural language processing, and robotics. Gain insights into how AI is shaping various industries and be prepared to harness the potential of this transformative technology.", new DateTime(2023, 11, 6, 8, 57, 3, 693, DateTimeKind.Utc).AddTicks(5613), "https://cdn.mindmajix.com/courses/artificial-intelligence-training.png", 129.99m, new DateTime(2023, 8, 6, 8, 57, 3, 693, DateTimeKind.Utc).AddTicks(5613), "Introduction to Artificial Intelligence", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e67079bf-2bb7-4183-9ac1-47d587d7e091"), "admin", new DateTime(2023, 8, 6, 8, 57, 3, 693, DateTimeKind.Utc).AddTicks(5599), "Welcome to the JS Advanced August 2023 course! This comprehensive and hands-on training program is designed to take your JavaScript skills to the next level. Whether you're an aspiring web developer, an experienced coder looking to enhance your frontend abilities, or simply someone eager to delve deeper into the world of JavaScript, this course has something to offer for everyone.\r\n\r\nThroughout the course, you'll dive into the advanced concepts of JavaScript, exploring topics like closures, prototypes, asynchronous programming, and more. You'll gain a solid understanding of how to leverage JavaScript's full potential and build robust, efficient, and dynamic web applications.\r\n\r\nLed by industry experts, our interactive sessions and practical exercises will give you ample opportunities to apply your knowledge and reinforce your learning. By the end of this course, you'll be equipped with the skills and confidence to tackle complex JavaScript projects and stand out in the competitive world of web development.\r\n\r\nEnroll now and embark on a journey of JavaScript mastery. Don't miss this chance to become a proficient JavaScript developer and unlock a world of exciting possibilities in the realm of web development. Join us for JS Advanced August 2023!\"\r\n\r\nPlease feel free to customize and expand upon this description to suit your specific course content and target audience.", new DateTime(2023, 11, 6, 8, 57, 3, 693, DateTimeKind.Utc).AddTicks(5599), "https://play-lh.googleusercontent.com/-EwtKuAhXBB9FgIe-XYAZt6vUbYPCZQp61dwO5HVyzBAnMUjdBavbWXcqrRWkT8a_rQ=w240-h480-rw", 49.99m, new DateTime(2023, 8, 6, 8, 57, 3, 693, DateTimeKind.Utc).AddTicks(5599), "JS Advanced August 2023", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Name", "UpdatedBy", "UpdatedOn", "VideoUrl" },
                values: new object[,]
                {
                    { new Guid("4d6ccb28-7def-4e34-a596-4579d8473aec"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Javascript Objects", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.youtube.com/watch?v=BRSg22VacUA" },
                    { new Guid("83d9d8cd-2179-40c9-b3e2-2f319b4a377b"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Javascript Operators", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.youtube.com/watch?v=FZzyij43A54" },
                    { new Guid("a8042461-09b4-47f7-8d62-02e8fa5c14f2"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Javascript Introduction", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.youtube.com/watch?v=W6NZfCO5SIk" },
                    { new Guid("e8eeb398-ab72-4c95-a038-8e7d25dd7a8d"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Javascript Arrays", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.youtube.com/watch?v=7W4pQQ20nJg" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "69d67468-e0d1-44b5-8b9a-719889b230b9" });

            migrationBuilder.InsertData(
                table: "CategoryCourseCourses",
                columns: new[] { "CategoryCourseId", "CourseId" },
                values: new object[,]
                {
                    { 36, new Guid("10838b25-d523-41f2-bf93-04302f1c79c9") },
                    { 24, new Guid("320439e3-1b9b-4a8e-9f88-97b85cfd0ab7") },
                    { 32, new Guid("320439e3-1b9b-4a8e-9f88-97b85cfd0ab7") },
                    { 38, new Guid("87df5fa0-4c6e-4ae5-8b8c-6b6aca412107") },
                    { 39, new Guid("adcd69ea-02d8-4990-bd6e-5dfbe9fef815") },
                    { 21, new Guid("e67079bf-2bb7-4183-9ac1-47d587d7e091") },
                    { 25, new Guid("e67079bf-2bb7-4183-9ac1-47d587d7e091") },
                    { 35, new Guid("e67079bf-2bb7-4183-9ac1-47d587d7e091") }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "ImageUrl", "IsDeleted", "IsPublic", "Title", "UpdatedBy", "UpdatedOn", "UserId" },
                values: new object[,]
                {
                    { new Guid("20e979bb-e8a4-49a1-947b-515f125bfd5a"), "C# advanced is a nice course to learn, to become better", "administrator", new DateTime(2023, 8, 6, 8, 57, 3, 693, DateTimeKind.Utc).AddTicks(5554), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.filepicker.io/api/file/2ZsQkVfR0yhZPRO33JEw", false, true, "C# Advanced 1 2023", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "69d67468-e0d1-44b5-8b9a-719889b230b9" },
                    { new Guid("2b53dad6-ff6a-433e-b0dc-d21632d8ffac"), "Learn how to use Python for data analysis, visualization, and machine learning.", "administrator", new DateTime(2023, 8, 6, 8, 57, 3, 693, DateTimeKind.Utc).AddTicks(5562), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.example.com/images/python_data_science.jpg", false, true, "Python for Data Science", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "69d67468-e0d1-44b5-8b9a-719889b230b9" },
                    { new Guid("74c78874-479b-4514-92e3-bdd65b1c262f"), "Take your JavaScript skills to the next level with our comprehensive JavaScript Advanced course.learning.\r\nPrerequisites:\r\nThis course is de", "administrator", new DateTime(2023, 8, 6, 8, 57, 3, 693, DateTimeKind.Utc).AddTicks(5560), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.ytimg.com/vi/YT8s-90oDC0/maxresdefault.jpg", false, true, "Javascript Advanced 2023", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "69d67468-e0d1-44b5-8b9a-719889b230b9" },
                    { new Guid("83f91203-f951-4f57-af5e-df3c7b7af2c3"), "An introductory course to machine learning algorithms and techniques.", "administrator", new DateTime(2023, 8, 6, 8, 57, 3, 693, DateTimeKind.Utc).AddTicks(5563), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.example.com/images/intro_to_ml.jpg", false, true, "Introduction to Machine Learning", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "69d67468-e0d1-44b5-8b9a-719889b230b9" },
                    { new Guid("8d2b966c-0e52-4078-aaff-63f674bdc306"), "C# advanced is a nice course to learn, to become better", "administrator", new DateTime(2023, 8, 6, 8, 57, 3, 693, DateTimeKind.Utc).AddTicks(5558), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.filepicker.io/api/file/2ZsQkVfR0yhZPRO33JEw", false, true, "C# Advanced 2 2023", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "69d67468-e0d1-44b5-8b9a-719889b230b9" },
                    { new Guid("9b56dbbc-e61a-4994-8908-662be812a130"), "Explore the fundamentals of artificial intelligence and its applications.", "administrator", new DateTime(2023, 8, 6, 8, 57, 3, 693, DateTimeKind.Utc).AddTicks(5574), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.example.com/images/intro_to_ai.jpg", false, true, "Introduction to Artificial Intelligence", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "69d67468-e0d1-44b5-8b9a-719889b230b9" },
                    { new Guid("a2af6703-e2cd-48d5-9ad3-1ea91d8ba63e"), "Master the art of building modern web applications using React.js.", "administrator", new DateTime(2023, 8, 6, 8, 57, 3, 693, DateTimeKind.Utc).AddTicks(5565), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.example.com/images/react_web_dev.jpg", false, true, "Web Development with React", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "69d67468-e0d1-44b5-8b9a-719889b230b9" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Content", "CourseId", "CreatedBy", "CreatedOn", "EndTime", "Name", "StartTime", "UpdatedBy", "UpdatedOn", "VideoId" },
                values: new object[,]
                {
                    { new Guid("0b7288c6-8b6f-4c39-a2d7-c47e99232901"), "This is a throughout introduction to Javascript objects", new Guid("e67079bf-2bb7-4183-9ac1-47d587d7e091"), "administrator", new DateTime(2023, 8, 6, 8, 57, 3, 693, DateTimeKind.Utc).AddTicks(5712), new DateTime(2023, 9, 5, 15, 57, 3, 693, DateTimeKind.Local).AddTicks(5710), "Javascript objects", new DateTime(2023, 9, 5, 8, 57, 3, 693, DateTimeKind.Utc).AddTicks(5710), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e8eeb398-ab72-4c95-a038-8e7d25dd7a8d") },
                    { new Guid("20ede8e8-b460-48f7-af8d-b2e23432023b"), "This is a throughout introduction to Javascript arrays", new Guid("e67079bf-2bb7-4183-9ac1-47d587d7e091"), "administrator", new DateTime(2023, 8, 6, 8, 57, 3, 693, DateTimeKind.Utc).AddTicks(5716), new DateTime(2023, 9, 9, 15, 57, 3, 693, DateTimeKind.Local).AddTicks(5714), "Javascript Operators", new DateTime(2023, 9, 9, 8, 57, 3, 693, DateTimeKind.Utc).AddTicks(5714), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e8eeb398-ab72-4c95-a038-8e7d25dd7a8d") },
                    { new Guid("627d913f-4ef1-411d-b1b7-95a77db73666"), "This is a brief introduction to Javascript arrays", new Guid("e67079bf-2bb7-4183-9ac1-47d587d7e091"), "administrator", new DateTime(2023, 8, 6, 8, 57, 3, 693, DateTimeKind.Utc).AddTicks(5706), new DateTime(2023, 9, 2, 15, 57, 3, 693, DateTimeKind.Local).AddTicks(5705), "Javascript arrays", new DateTime(2023, 9, 2, 8, 57, 3, 693, DateTimeKind.Utc).AddTicks(5704), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e8eeb398-ab72-4c95-a038-8e7d25dd7a8d") },
                    { new Guid("7b589ca4-c727-419c-867d-032524820c4a"), "This is a brief introduction to Javascript", new Guid("e67079bf-2bb7-4183-9ac1-47d587d7e091"), "administrator", new DateTime(2023, 8, 6, 8, 57, 3, 693, DateTimeKind.Utc).AddTicks(5702), new DateTime(2023, 8, 30, 15, 57, 3, 693, DateTimeKind.Local).AddTicks(5676), "Introduction to javascript", new DateTime(2023, 8, 30, 8, 57, 3, 693, DateTimeKind.Utc).AddTicks(5671), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a8042461-09b4-47f7-8d62-02e8fa5c14f2") }
                });

            migrationBuilder.InsertData(
                table: "UserCourses",
                columns: new[] { "CourseId", "UserId" },
                values: new object[,]
                {
                    { new Guid("10838b25-d523-41f2-bf93-04302f1c79c9"), "fc5d084d-38d6-4ff0-abe6-abb2e1e3f323" },
                    { new Guid("adcd69ea-02d8-4990-bd6e-5dfbe9fef815"), "e2432f3d-489e-4230-81ff-b110e80cc165" },
                    { new Guid("e67079bf-2bb7-4183-9ac1-47d587d7e091"), "e2432f3d-489e-4230-81ff-b110e80cc165" },
                    { new Guid("e67079bf-2bb7-4183-9ac1-47d587d7e091"), "fc5d084d-38d6-4ff0-abe6-abb2e1e3f323" }
                });

            migrationBuilder.InsertData(
                table: "CategoriesResources",
                columns: new[] { "CategoryId", "ResourceId" },
                values: new object[,]
                {
                    { 11, new Guid("20e979bb-e8a4-49a1-947b-515f125bfd5a") },
                    { 12, new Guid("74c78874-479b-4514-92e3-bdd65b1c262f") },
                    { 13, new Guid("2b53dad6-ff6a-433e-b0dc-d21632d8ffac") },
                    { 13, new Guid("9b56dbbc-e61a-4994-8908-662be812a130") },
                    { 14, new Guid("83f91203-f951-4f57-af5e-df3c7b7af2c3") },
                    { 15, new Guid("20e979bb-e8a4-49a1-947b-515f125bfd5a") },
                    { 15, new Guid("9b56dbbc-e61a-4994-8908-662be812a130") },
                    { 15, new Guid("a2af6703-e2cd-48d5-9ad3-1ea91d8ba63e") },
                    { 16, new Guid("8d2b966c-0e52-4078-aaff-63f674bdc306") },
                    { 16, new Guid("9b56dbbc-e61a-4994-8908-662be812a130") },
                    { 17, new Guid("74c78874-479b-4514-92e3-bdd65b1c262f") },
                    { 18, new Guid("2b53dad6-ff6a-433e-b0dc-d21632d8ffac") },
                    { 19, new Guid("83f91203-f951-4f57-af5e-df3c7b7af2c3") },
                    { 19, new Guid("a2af6703-e2cd-48d5-9ad3-1ea91d8ba63e") },
                    { 20, new Guid("8d2b966c-0e52-4078-aaff-63f674bdc306") },
                    { 20, new Guid("9b56dbbc-e61a-4994-8908-662be812a130") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "IsDeleted", "ResourceId", "UpdatedBy", "UpdatedOn", "UserId" },
                values: new object[,]
                {
                    { new Guid("2dac94c0-5caf-4477-9b52-7a5c75dbcc97"), "This is comment send by seeded admin", "administrator", new DateTime(2023, 8, 6, 8, 57, 3, 693, DateTimeKind.Utc).AddTicks(5587), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("8d2b966c-0e52-4078-aaff-63f674bdc306"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "69d67468-e0d1-44b5-8b9a-719889b230b9" },
                    { new Guid("3d331e25-91d8-4bc5-93cc-ce4811c6201e"), "This is comment send by seeded admin", "administrator", new DateTime(2023, 8, 6, 8, 57, 3, 693, DateTimeKind.Utc).AddTicks(5591), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("83f91203-f951-4f57-af5e-df3c7b7af2c3"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "69d67468-e0d1-44b5-8b9a-719889b230b9" },
                    { new Guid("573b22ad-b55f-4133-bc08-4606d6f678d6"), "This is comment send by seeded admin", "administrator", new DateTime(2023, 8, 6, 8, 57, 3, 693, DateTimeKind.Utc).AddTicks(5589), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("2b53dad6-ff6a-433e-b0dc-d21632d8ffac"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "69d67468-e0d1-44b5-8b9a-719889b230b9" },
                    { new Guid("f98af5a2-e334-4fa5-a429-2348cfeb5996"), "This is comment send by seeded admin", "administrator", new DateTime(2023, 8, 6, 8, 57, 3, 693, DateTimeKind.Utc).AddTicks(5592), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("a2af6703-e2cd-48d5-9ad3-1ea91d8ba63e"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "69d67468-e0d1-44b5-8b9a-719889b230b9" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "69d67468-e0d1-44b5-8b9a-719889b230b9" });

            migrationBuilder.DeleteData(
                table: "CategoriesIssues",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CategoriesIssues",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CategoriesIssues",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CategoriesIssues",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CategoriesResources",
                keyColumns: new[] { "CategoryId", "ResourceId" },
                keyValues: new object[] { 11, new Guid("20e979bb-e8a4-49a1-947b-515f125bfd5a") });

            migrationBuilder.DeleteData(
                table: "CategoriesResources",
                keyColumns: new[] { "CategoryId", "ResourceId" },
                keyValues: new object[] { 12, new Guid("74c78874-479b-4514-92e3-bdd65b1c262f") });

            migrationBuilder.DeleteData(
                table: "CategoriesResources",
                keyColumns: new[] { "CategoryId", "ResourceId" },
                keyValues: new object[] { 13, new Guid("2b53dad6-ff6a-433e-b0dc-d21632d8ffac") });

            migrationBuilder.DeleteData(
                table: "CategoriesResources",
                keyColumns: new[] { "CategoryId", "ResourceId" },
                keyValues: new object[] { 13, new Guid("9b56dbbc-e61a-4994-8908-662be812a130") });

            migrationBuilder.DeleteData(
                table: "CategoriesResources",
                keyColumns: new[] { "CategoryId", "ResourceId" },
                keyValues: new object[] { 14, new Guid("83f91203-f951-4f57-af5e-df3c7b7af2c3") });

            migrationBuilder.DeleteData(
                table: "CategoriesResources",
                keyColumns: new[] { "CategoryId", "ResourceId" },
                keyValues: new object[] { 15, new Guid("20e979bb-e8a4-49a1-947b-515f125bfd5a") });

            migrationBuilder.DeleteData(
                table: "CategoriesResources",
                keyColumns: new[] { "CategoryId", "ResourceId" },
                keyValues: new object[] { 15, new Guid("9b56dbbc-e61a-4994-8908-662be812a130") });

            migrationBuilder.DeleteData(
                table: "CategoriesResources",
                keyColumns: new[] { "CategoryId", "ResourceId" },
                keyValues: new object[] { 15, new Guid("a2af6703-e2cd-48d5-9ad3-1ea91d8ba63e") });

            migrationBuilder.DeleteData(
                table: "CategoriesResources",
                keyColumns: new[] { "CategoryId", "ResourceId" },
                keyValues: new object[] { 16, new Guid("8d2b966c-0e52-4078-aaff-63f674bdc306") });

            migrationBuilder.DeleteData(
                table: "CategoriesResources",
                keyColumns: new[] { "CategoryId", "ResourceId" },
                keyValues: new object[] { 16, new Guid("9b56dbbc-e61a-4994-8908-662be812a130") });

            migrationBuilder.DeleteData(
                table: "CategoriesResources",
                keyColumns: new[] { "CategoryId", "ResourceId" },
                keyValues: new object[] { 17, new Guid("74c78874-479b-4514-92e3-bdd65b1c262f") });

            migrationBuilder.DeleteData(
                table: "CategoriesResources",
                keyColumns: new[] { "CategoryId", "ResourceId" },
                keyValues: new object[] { 18, new Guid("2b53dad6-ff6a-433e-b0dc-d21632d8ffac") });

            migrationBuilder.DeleteData(
                table: "CategoriesResources",
                keyColumns: new[] { "CategoryId", "ResourceId" },
                keyValues: new object[] { 19, new Guid("83f91203-f951-4f57-af5e-df3c7b7af2c3") });

            migrationBuilder.DeleteData(
                table: "CategoriesResources",
                keyColumns: new[] { "CategoryId", "ResourceId" },
                keyValues: new object[] { 19, new Guid("a2af6703-e2cd-48d5-9ad3-1ea91d8ba63e") });

            migrationBuilder.DeleteData(
                table: "CategoriesResources",
                keyColumns: new[] { "CategoryId", "ResourceId" },
                keyValues: new object[] { 20, new Guid("8d2b966c-0e52-4078-aaff-63f674bdc306") });

            migrationBuilder.DeleteData(
                table: "CategoriesResources",
                keyColumns: new[] { "CategoryId", "ResourceId" },
                keyValues: new object[] { 20, new Guid("9b56dbbc-e61a-4994-8908-662be812a130") });

            migrationBuilder.DeleteData(
                table: "CategoryCourseCourses",
                keyColumns: new[] { "CategoryCourseId", "CourseId" },
                keyValues: new object[] { 36, new Guid("10838b25-d523-41f2-bf93-04302f1c79c9") });

            migrationBuilder.DeleteData(
                table: "CategoryCourseCourses",
                keyColumns: new[] { "CategoryCourseId", "CourseId" },
                keyValues: new object[] { 24, new Guid("320439e3-1b9b-4a8e-9f88-97b85cfd0ab7") });

            migrationBuilder.DeleteData(
                table: "CategoryCourseCourses",
                keyColumns: new[] { "CategoryCourseId", "CourseId" },
                keyValues: new object[] { 32, new Guid("320439e3-1b9b-4a8e-9f88-97b85cfd0ab7") });

            migrationBuilder.DeleteData(
                table: "CategoryCourseCourses",
                keyColumns: new[] { "CategoryCourseId", "CourseId" },
                keyValues: new object[] { 38, new Guid("87df5fa0-4c6e-4ae5-8b8c-6b6aca412107") });

            migrationBuilder.DeleteData(
                table: "CategoryCourseCourses",
                keyColumns: new[] { "CategoryCourseId", "CourseId" },
                keyValues: new object[] { 39, new Guid("adcd69ea-02d8-4990-bd6e-5dfbe9fef815") });

            migrationBuilder.DeleteData(
                table: "CategoryCourseCourses",
                keyColumns: new[] { "CategoryCourseId", "CourseId" },
                keyValues: new object[] { 21, new Guid("e67079bf-2bb7-4183-9ac1-47d587d7e091") });

            migrationBuilder.DeleteData(
                table: "CategoryCourseCourses",
                keyColumns: new[] { "CategoryCourseId", "CourseId" },
                keyValues: new object[] { 25, new Guid("e67079bf-2bb7-4183-9ac1-47d587d7e091") });

            migrationBuilder.DeleteData(
                table: "CategoryCourseCourses",
                keyColumns: new[] { "CategoryCourseId", "CourseId" },
                keyValues: new object[] { 35, new Guid("e67079bf-2bb7-4183-9ac1-47d587d7e091") });

            migrationBuilder.DeleteData(
                table: "CategoryCourses",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "CategoryCourses",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "CategoryCourses",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "CategoryCourses",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "CategoryCourses",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "CategoryCourses",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "CategoryCourses",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "CategoryCourses",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "CategoryCourses",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "CategoryCourses",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "CategoryCourses",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("2dac94c0-5caf-4477-9b52-7a5c75dbcc97"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("3d331e25-91d8-4bc5-93cc-ce4811c6201e"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("573b22ad-b55f-4133-bc08-4606d6f678d6"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("f98af5a2-e334-4fa5-a429-2348cfeb5996"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("0b7288c6-8b6f-4c39-a2d7-c47e99232901"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("20ede8e8-b460-48f7-af8d-b2e23432023b"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("627d913f-4ef1-411d-b1b7-95a77db73666"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("7b589ca4-c727-419c-867d-032524820c4a"));

            migrationBuilder.DeleteData(
                table: "UserCourses",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { new Guid("10838b25-d523-41f2-bf93-04302f1c79c9"), "fc5d084d-38d6-4ff0-abe6-abb2e1e3f323" });

            migrationBuilder.DeleteData(
                table: "UserCourses",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { new Guid("adcd69ea-02d8-4990-bd6e-5dfbe9fef815"), "e2432f3d-489e-4230-81ff-b110e80cc165" });

            migrationBuilder.DeleteData(
                table: "UserCourses",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { new Guid("e67079bf-2bb7-4183-9ac1-47d587d7e091"), "e2432f3d-489e-4230-81ff-b110e80cc165" });

            migrationBuilder.DeleteData(
                table: "UserCourses",
                keyColumns: new[] { "CourseId", "UserId" },
                keyValues: new object[] { new Guid("e67079bf-2bb7-4183-9ac1-47d587d7e091"), "fc5d084d-38d6-4ff0-abe6-abb2e1e3f323" });

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("4d6ccb28-7def-4e34-a596-4579d8473aec"));

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("83d9d8cd-2179-40c9-b3e2-2f319b4a377b"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2432f3d-489e-4230-81ff-b110e80cc165");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc5d084d-38d6-4ff0-abe6-abb2e1e3f323");

            migrationBuilder.DeleteData(
                table: "CategoryCourses",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "CategoryCourses",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "CategoryCourses",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "CategoryCourses",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "CategoryCourses",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "CategoryCourses",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "CategoryCourses",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "CategoryCourses",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("10838b25-d523-41f2-bf93-04302f1c79c9"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("320439e3-1b9b-4a8e-9f88-97b85cfd0ab7"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("87df5fa0-4c6e-4ae5-8b8c-6b6aca412107"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("adcd69ea-02d8-4990-bd6e-5dfbe9fef815"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("e67079bf-2bb7-4183-9ac1-47d587d7e091"));

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("20e979bb-e8a4-49a1-947b-515f125bfd5a"));

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("2b53dad6-ff6a-433e-b0dc-d21632d8ffac"));

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("74c78874-479b-4514-92e3-bdd65b1c262f"));

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("83f91203-f951-4f57-af5e-df3c7b7af2c3"));

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("8d2b966c-0e52-4078-aaff-63f674bdc306"));

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("9b56dbbc-e61a-4994-8908-662be812a130"));

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("a2af6703-e2cd-48d5-9ad3-1ea91d8ba63e"));

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("a8042461-09b4-47f7-8d62-02e8fa5c14f2"));

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("e8eeb398-ab72-4c95-a038-8e7d25dd7a8d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69d67468-e0d1-44b5-8b9a-719889b230b9");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Courses",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 10000);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileBackground", "ProfileDescription", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "UpdatedBy", "UpdatedOn", "UserEducation", "UserJob", "UserName" },
                values: new object[] { "341e7640-881b-4ba5-a7cd-da4d7c8db203", 0, "a95bd67f-e2df-475d-ba00-405ec08c0c05", "admin", new DateTime(2023, 8, 5, 19, 54, 11, 319, DateTimeKind.Utc).AddTicks(3527), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", false, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEDKe2n1Y/5E49Nav6HYjHaUzJQrsooMjoPyx4Zl2ptkoqy/IfmyUmpRK7Hw1ROFiag==", null, false, null, "This is my in-depth description", null, "87fb375f-bf38-4acd-bdbe-984649f9c2fc", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "At Harvard", "Working from home", "administrator" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileBackground", "ProfileDescription", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "UpdatedBy", "UpdatedOn", "UserEducation", "UserJob", "UserName" },
                values: new object[] { "48e5b1d3-cd95-41c9-9ae9-718765be6338", 0, "f29d3d99-8e65-4044-82af-8c57687212d9", "admin", new DateTime(2023, 8, 5, 19, 54, 11, 319, DateTimeKind.Utc).AddTicks(3556), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", false, false, false, null, null, "JANE_SMITH", "AQAAAAEAACcQAAAAECxaCV/2PikmiTo8QNTgcP4gFP7RrsqpZMAK5ghGJmh9YU7pJouhFzwdrcTr/OGnpA==", null, false, null, "Passionate about creating beautiful designs.", null, "fe493286-8e8d-4677-83d3-6b9d31a25d21", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Art Institute", "Graphic Designer", "jane_smith" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileBackground", "ProfileDescription", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "UpdatedBy", "UpdatedOn", "UserEducation", "UserJob", "UserName" },
                values: new object[] { "7df422ab-b2e1-450d-a773-c960d17e3e09", 0, "2c16b144-67ac-4f7f-8512-4157e5c72170", "admin", new DateTime(2023, 8, 5, 19, 54, 11, 319, DateTimeKind.Utc).AddTicks(3545), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", false, false, false, null, null, "JOHN_DOE", "AQAAAAEAACcQAAAAEGaeyVi9mx1IZ86lQhWGDUNzjYiSKnWkZSuiDnVACmU35yx90fTSgwlw+YkWh+wTMg==", null, false, null, "I love coding and building cool applications!", null, "cd07dadb-d1d9-4ba3-b599-841979d160de", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Self-taught", "Software Engineer", "john_doe" });

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
    }
}
