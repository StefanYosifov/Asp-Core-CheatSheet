namespace _Project_CheatSheet.Tests.Fixtures
{
    using System.Collections;

    using _Project_CheatSheet.Infrastructure.Data.SQL.Models;

    using Infrastructure.Data.SQL;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class SetupInitializeData
    {

        internal static async Task InitializeDataForResources(string userId, CheatSheetDbContext context)
        {

            var resources = new List<Resource>()
              {
                new Resource()
                {
                    UserId = userId,
                    Content = "This is a very nice comment isn't it?",
                    Id = Guid.NewGuid(),
                    IsPublic = true,
                    Title = "THE BEST TITLE TO EVER EXIST",
                    ImageUrl = "https:/snimki.bg",
                    CreatedBy = userId,
                    CreatedOn = DateTime.UtcNow,
                    UpdatedBy = userId,
                    UpdatedOn = DateTime.UtcNow,
                },
                new Resource()
                {
                    UserId = "alice",
                    Content = "I really enjoyed reading this article!",
                    Id = Guid.NewGuid(),
                    IsPublic = true,
                    Title = "Amazing Article,comment here!!!,comment here!!!",
                    ImageUrl = "https://example.com/image1.jpg",
                    CreatedBy = "alice",
                    CreatedOn = DateTime.UtcNow.AddDays(-5),
                    UpdatedBy = "alice",
                    UpdatedOn = DateTime.UtcNow.AddDays(-2),
                },
                new Resource()
                {
                    UserId = "bob",
                    Content = "Great work! Keep it up!",
                    Id = Guid.NewGuid(),
                    IsPublic = false,
                    Title = "My Project Update,comment here!!!",
                    ImageUrl = "https://example.com/image2.jpg",
                    CreatedBy = "bob",
                    CreatedOn = DateTime.UtcNow.AddDays(-10),
                    UpdatedBy = "bob",
                    UpdatedOn = DateTime.UtcNow.AddDays(-7),
                },
                new Resource()
                {
                    UserId = "charlie",
                    Content = "This is an interesting topic.",
                    Id = Guid.NewGuid(),
                    IsPublic = true,
                    Title = "Discussion Thread, comment here!!!",
                    ImageUrl = "https://example.com/image3.jpg",
                    CreatedBy = "charlie",
                    CreatedOn = DateTime.UtcNow.AddDays(-2),
                    UpdatedBy = "charlie",
                    UpdatedOn = DateTime.UtcNow,
                }
            };
            await SaveIntoDatabase(resources, context);

            var comments = new List<Comment>
            {
                new Comment
                {
                    UserId = "pesho",
                    Content = "This is a very nice way to create a comment",
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "pesho",
                    UpdatedOn = DateTime.Now,
                    UpdatedBy = "pesho",
                    ResourceId = resources[1].Id,
                },
                new Comment
                {
                    UserId = "alice567",
                    Content = "I totally agree with your comment!",
                    CreatedOn = DateTime.UtcNow.AddDays(-1),
                    CreatedBy = "alice",
                    UpdatedOn = DateTime.UtcNow.AddDays(-1),
                    UpdatedBy = "alice",
                    ResourceId = resources[1].Id
                },
                new Comment
                {
                    UserId = "bob321",
                    Content = "Nice work! Keep it up!",
                    CreatedOn = DateTime.UtcNow.AddDays(-2),
                    CreatedBy = "bob",
                    UpdatedOn = DateTime.UtcNow.AddDays(-1),
                    UpdatedBy = "bob",
                    ResourceId = resources[2].Id
                },
                new Comment
                {
                    UserId = "pesho",
                    Content = "Thanks for sharing this information.",
                    CreatedOn = DateTime.UtcNow.AddDays(-3),
                    CreatedBy = "charlie",
                    UpdatedOn = DateTime.UtcNow.AddDays(-2),
                    UpdatedBy = "charlie",
                    ResourceId = resources[3].Id,
                    IsDeleted = true
                }
            };
            await SaveIntoDatabase(comments, context);

            var resourceLikes = new List<ResourceLike>
            {
                new ResourceLike
                {
                    UserId = "pesho",
                    CreatedAt = DateTime.UtcNow.AddDays(-10),
                    ResourceId = resources[1].Id,
                },
                new ResourceLike
                {
                    UserId = "alice",
                    CreatedAt = DateTime.UtcNow.AddDays(-5),
                    ResourceId = resources[2].Id,
                },
                new ResourceLike
                {
                    UserId = "bob",
                    CreatedAt = DateTime.UtcNow.AddDays(-2),
                    ResourceId = resources[2].Id,
                },
                new ResourceLike
                {
                    UserId = "charlie",
                    CreatedAt = DateTime.UtcNow,
                    ResourceId = resources[3].Id,
                }
            };
            await SaveIntoDatabase(resourceLikes, context);

            var categories = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "C#"
                },
                new Category
                {
                    Id = 2,
                    Name = "JavaScript"
                },
                new Category
                {
                    Id = 3,
                    Name = "Python"
                },
                new Category
                {
                    Id = 4,
                    Name = "Java"
                },
                new Category
                {
                    Id = 5,
                    Name = "PHP"
                }
            };
            await SaveIntoDatabase(categories, context);
        }

        internal static async Task IntializeDataForCourses(CheatSheetDbContext context)
        {

            var usersToCreate = new List<User>
            {
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "administrator",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@gmail.com",
                    UserJob = "Working from home",
                    UserEducation = "At Harvard",
                    ProfileDescription = "This is my in-depth description",
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "admin",
                    SecurityStamp = Guid.NewGuid().ToString(),
                },
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "john_doe",
                    NormalizedUserName = "JOHN_DOE",
                    Email = "john.doe@example.com",
                    UserJob = "Software Engineer",
                    UserEducation = "Self-taught",
                    ProfileDescription = "I love coding and building cool applications!",
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "admin",
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "jane_smith",
                    NormalizedUserName = "JANE_SMITH",
                    Email = "jane.smith@example.com",
                    UserJob = "Graphic Designer",
                    UserEducation = "Art Institute",
                    ProfileDescription = "Passionate about creating beautiful designs.",
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "admin",
                    SecurityStamp = Guid.NewGuid().ToString()
                }
            };

            foreach (var user in usersToCreate)
            {
                user.PasswordHash = CreatePassword(user, "test123");
            }

            string userId = usersToCreate[0].Id;
            string userName = usersToCreate[0].UserName;

            var courses = new List<Course>()
           {
                new()
                {
                    Title = "JS Advanced August 2023",
                    Description =
                        "Welcome to the JS Advanced August 2023 course! This comprehensive and hands-on training program is designed to take your JavaScript skills to the next level. Whether you're an aspiring web developer, an experienced coder looking to enhance your frontend abilities, or simply someone eager to delve deeper into the world of JavaScript, this course has something to offer for everyone.\r\n\r\nThroughout the course, you'll dive into the advanced concepts of JavaScript, exploring topics like closures, prototypes, asynchronous programming, and more. You'll gain a solid understanding of how to leverage JavaScript's full potential and build robust, efficient, and dynamic web applications.\r\n\r\nLed by industry experts, our interactive sessions and practical exercises will give you ample opportunities to apply your knowledge and reinforce your learning. By the end of this course, you'll be equipped with the skills and confidence to tackle complex JavaScript projects and stand out in the competitive world of web development.\r\n\r\nEnroll now and embark on a journey of JavaScript mastery. Don't miss this chance to become a proficient JavaScript developer and unlock a world of exciting possibilities in the realm of web development. Join us for JS Advanced August 2023!\"\r\n\r\nPlease feel free to customize and expand upon this description to suit your specific course content and target audience.",
                    Price = 49.99m,
                    ImageUrl =
                        "https://play-lh.googleusercontent.com/-EwtKuAhXBB9FgIe-XYAZt6vUbYPCZQp61dwO5HVyzBAnMUjdBavbWXcqrRWkT8a_rQ=w240-h480-rw",
                    CreatedBy = "admin",
                    CreatedOn = DateTime.UtcNow,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddMonths(3),
                },
                new()
                {
                    Title = "Photography Fundamentals for Beginners",
                    Description =
                        "Unleash your creative potential and capture stunning images with our Photography Fundamentals course. Learn about camera settings, composition, lighting, and post-processing techniques to bring your photographs to life. Whether you're using a DSLR, mirrorless, or smartphone camera, this course will help you master the art of photography and tell captivating visual stories.",
                    Price = 39.99m,
                    ImageUrl = "https://cdn01.alison-static.net/courses/1326/alison_courseware_intro_1326.jpg",
                    CreatedBy = "admin",
                    CreatedOn = DateTime.UtcNow,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddMonths(1),
                },
                new()
                {
                    Title = "Introduction to Ethical Hacking and Cybersecurity",
                    Description =
                        "Discover the world of ethical hacking and cybersecurity, where you'll learn to defend against cyber threats and secure digital assets. Explore common attack vectors, penetration testing techniques, and vulnerability assessment methods. With hands-on labs, you'll gain practical experience in identifying and mitigating security risks. Prepare yourself to become a cybersecurity expert and contribute to a safer online world.",
                    Price = 89.99m,
                    ImageUrl = "https://www.udacity.com/www-proxy/contentful/assets/2y9b3o528xhq/4PjDlJzjwAB1tWZ5qL93cz/df5750f8ec5fad0c11b8f9d0582d5f0b/SEO-Image-4.jpg",
                    CreatedBy = "admin",
                    CreatedOn = DateTime.UtcNow,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddMonths(3),
                },
                new()
                {
                    Title = "Introduction to Artificial Intelligence",
                    Description =
                        "Delve into the cutting-edge field of Artificial Intelligence (AI) and explore its diverse applications. This course provides a solid foundation in AI concepts, including machine learning, neural networks, natural language processing, and robotics. Gain insights into how AI is shaping various industries and be prepared to harness the potential of this transformative technology.",
                    Price = 129.99m,
                    ImageUrl = "https://cdn.mindmajix.com/courses/artificial-intelligence-training.png",
                    CreatedBy = "admin",
                    CreatedOn = DateTime.UtcNow,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddMonths(3),
                },
                new()
                {
                    Title = "Python for Data Science and Machine Learning",
                    Description =
                        "Dive into the fascinating world of data science and machine learning with our comprehensive Python course. Discover how to manipulate and analyze data, build predictive models, and derive valuable insights from complex datasets. Whether you're a data enthusiast or aspiring data scientist, this course will equip you with the essential skills to excel in the data-driven industry.",
                    Price = 99.99m,
                    ImageUrl = "https://cdn.mindmajix.com/courses/python-training.png",
                    CreatedBy = "admin",
                    CreatedOn = DateTime.UtcNow,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddMonths(4),
                },
           };
            await context.Courses.AddRangeAsync(courses);
            await context.SaveChangesAsync();

            var categoryCourses = new List<CategoryCourse>
            {
                new()
                {
                    Id = 21,
                    Name = "Web",
                },
                new()
                {
                    Id = 22,
                    Name = "Django",
                },
                new()
                {
                    Id = 23,
                    Name = "Flask",
                },
                new()
                {
                    Id = 24,
                    Name = "Python",
                },
                new()
                {
                    Id = 25,
                    Name = "JavaScript",
                },
                new()
                {
                    Id = 26,
                    Name = ".Net",
                },
                new()
                {
                    Id = 27,
                    Name = "MVC",
                },
                new()
                {
                    Id = 28,
                    Name = "API",
                },
                new()
                {
                    Id = 29,
                    Name = "Databases",
                },
                new()
                {
                    Id = 30,
                    Name = "C#",
                },
                new()
                {
                    Id = 31,
                    Name = "Java",
                },
                new()
                {
                    Id = 32,
                    Name = "Math",
                },
                new()
                {
                    Id = 33,
                    Name = "Windows",
                },
                new()
                {
                    Id = 34,
                    Name = "Servers",
                },
                new()
                {
                    Id = 35,
                    Name = "DataStructures",
                },
                new()
                {
                    Id = 36,
                    Name = "Security",
                },
                new()
                {
                    Id = 37,
                    Name = "UX/UI Design"
                },
                new()
                {
                    Id = 38,
                    Name="Photography and Design"
                },
                new()
                {
                    Id=39,
                    Name="Artificial Intelligence"
                }
            };
            await context.CategoryCourses.AddRangeAsync(categoryCourses);
            await context.SaveChangesAsync();

            var categoryCourseCourses = new List<CategoryCourseCourses>
            {
                new()
                {
                    CourseId = courses[0].Id,
                    CategoryCourseId = 21
                },
                new()
                {
                    CourseId = courses[0].Id,
                    CategoryCourseId = 25
                },
                new()
                {
                    CourseId = courses[0].Id,
                    CategoryCourseId = 35
                },
                new()
                {
                    CourseId = courses[1].Id,
                    CategoryCourseId = 38
                },
                new()
                {
                    CourseId = courses[2].Id,
                    CategoryCourseId = 36,
                },
                new()
                {
                    CourseId = courses[3].Id,
                    CategoryCourseId = 39,
                },
                new()
                {
                    CourseId = courses[4].Id,
                    CategoryCourseId = 24,
                },
                new()
                {
                    CourseId = courses[4].Id,
                    CategoryCourseId = 32,
                },
            };
            await context.CategoryCourseCourses.AddRangeAsync(categoryCourseCourses);
            await context.SaveChangesAsync();

            var userCourses = new List<UserCourses>(){
                new()
                {
                    CourseId = courses[0].Id,
                    UserId = usersToCreate[1].Id,
                },
                new()
                {
                    CourseId = courses[0].Id,
                    UserId = usersToCreate[2].Id,
                },
                new()
                {
                    CourseId = courses[2].Id,
                    UserId = usersToCreate[1].Id,
                },
                new()
                {
                    CourseId = courses[3].Id,
                    UserId = usersToCreate[2].Id,
                },
            };
            await context.UserCourses.AddRangeAsync(userCourses);
            await context.SaveChangesAsync();


            var categoryIssues = new List<CategoryIssue>()
            {
                new()
                {
                    Id = 1,
                    LocationIssue = "Problem with the title"
                },
                new()
                {
                    Id = 2,
                    LocationIssue = "Problem with the description"
                },
                new()
                {
                    Id = 3,
                    LocationIssue = "Problem with the video"
                },
                new()
                {
                    Id = 4,
                    LocationIssue = "Problem with the pdf file"
                },
            };
            await context.CategoriesIssues.AddRangeAsync(categoryIssues);
            await context.SaveChangesAsync();


            var videos = new List<Video>
            {
                new()
                {
                    Name = "Javascript Introduction",
                    VideoUrl = "https://www.youtube.com/watch?v=W6NZfCO5SIk"
                },
                new()
                {
                    Name = "Javascript Arrays",
                    VideoUrl = "https://www.youtube.com/watch?v=7W4pQQ20nJg"
                },
                new()
                {
                    Name = "Javascript Objects",
                    VideoUrl = "https://www.youtube.com/watch?v=BRSg22VacUA"
                },
                new()
                {
                    Name = "Javascript Operators",
                    VideoUrl = "https://www.youtube.com/watch?v=FZzyij43A54",
                }
            };
            await context.Videos.AddRangeAsync(videos);
            await context.SaveChangesAsync();


            var topics = new List<Topic>
            {
                new()
                {
                    Name = "Introduction to javascript",
                    Content = "This is a brief introduction to Javascript",
                    StartTime = DateTime.UtcNow.AddDays(24),
                    EndTime = DateTime.Now.AddDays(24).AddHours(4),
                    CreatedBy = userId,
                    CreatedOn = DateTime.UtcNow,
                    VideoId = videos[0].Id,
                    CourseId = courses[0].Id,
                },
                new()
                {
                    Name = "Javascript arrays",
                    Content = "This is a brief introduction to Javascript arrays",
                    StartTime = DateTime.UtcNow.AddDays(27),
                    EndTime = DateTime.Now.AddDays(27).AddHours(4),
                    CreatedBy = userId,
                    CreatedOn = DateTime.UtcNow,
                    VideoId = videos[1].Id,
                    CourseId = courses[0].Id,
                },
                new()
                {
                    Name = "Javascript objects",
                    Content = "This is a throughout introduction to Javascript objects",
                    StartTime = DateTime.UtcNow.AddDays(30),
                    EndTime = DateTime.Now.AddDays(30).AddHours(4),
                    CreatedBy = userId,
                    CreatedOn = DateTime.UtcNow,
                    VideoId = videos[1].Id,
                    CourseId = courses[0].Id,
                },
                new()
                {
                    Name = "Javascript Operators",
                    Content = "This is a throughout introduction to Javascript arrays",
                    StartTime = DateTime.UtcNow.AddDays(34),
                    EndTime = DateTime.Now.AddDays(34).AddHours(4),
                    CreatedBy = userId,
                    CreatedOn = DateTime.UtcNow,
                    VideoId = videos[1].Id,
                    CourseId = courses[0].Id,
                },
            };
            await context.Topics.AddRangeAsync(topics);
            await context.SaveChangesAsync();

        }

        private static async Task SaveIntoDatabase<T>(List<T> list, CheatSheetDbContext context)
        {
            await context.AddRangeAsync(list);
            await context.SaveChangesAsync();
        }

        private static string CreatePassword(User user, string password)
        {
            var passwordHasher = new PasswordHasher<User>();
            return passwordHasher.HashPassword(user, password);
        }

    }
}
