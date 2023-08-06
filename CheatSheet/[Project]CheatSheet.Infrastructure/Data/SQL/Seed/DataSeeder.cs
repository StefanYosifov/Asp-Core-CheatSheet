namespace _Project_CheatSheet.Infrastructure.Data.SQL.Seed
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    using Models;
    using Models.Enums;

    public class DataSeeder
    {

        public static async Task Initializer(CheatSheetDbContext context)
        {

        }

        internal static ModelBuilder SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "1",
                    Name = ApplicationRolesEnum.Administrator.ToString(),
                    NormalizedName = ApplicationRolesEnum.Administrator.ToString().ToUpper(),
                    ConcurrencyStamp = "02174cf0–9412–4cfe-afbf-59f706d72cf0"
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = ApplicationRolesEnum.Moderator.ToString(),
                    NormalizedName = ApplicationRolesEnum.Moderator.ToString().ToUpper(),
                    ConcurrencyStamp = "02174cf0–9412–4cfe-afbf-59f706d72cf1"
                },
                new IdentityRole
                {
                    Id = "3",
                    Name = ApplicationRolesEnum.User.ToString(),
                    NormalizedName = ApplicationRolesEnum.User.ToString().ToUpper(),
                    ConcurrencyStamp = "02174cf0–9412–4cfe-afbf-59f706d72cf2"
                }
            );

            return modelBuilder;
        }

        public static void SeedDatabase(ModelBuilder modelBuilder)
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

            modelBuilder.Entity<User>()
                .HasData(usersToCreate);

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>{ RoleId ="1", UserId = usersToCreate[0].Id });

  
            string adminId = usersToCreate[0].Id;
            string adminUserName=usersToCreate[0].UserName;

            var categories = new Category[]
            {
                new()
                {
                    Id = 11,
                    Name = "Arrays"
                },
                new()
                {
                    Id = 12,
                    Name = "Data structures"
                },
                new()
                {
                    Id = 13,
                    Name = "Algorithms"
                },
                new()
                {
                    Id = 14,
                    Name = "Object-Oriented Programming"
                },
                new()
                {
                    Id = 15,
                    Name = "Recursion"
                },
                new()
                {
                    Id = 16,
                    Name = "Sorting"
                },
                new()
                {
                    Id = 17,
                    Name = "Graph Theory"
                },
                new()
                {
                    Id = 18,
                    Name = "Dynamic Programming"
                },
                new()
                {
                    Id = 19,
                    Name = "Artificial Intelligence"
                },
                new()
                {
                    Id = 20,
                    Name = "Database Management"
                }
            };

            var resources = new Resource[]
            {
                new()
                {
                    Title = "C# Advanced 1 2023",
                    Content = "C# advanced is a nice course to learn, to become better",
                    UserId = adminId,
                    IsPublic = true,
                    ImageUrl = "https://www.filepicker.io/api/file/2ZsQkVfR0yhZPRO33JEw",
                    CreatedBy = adminUserName,
                    CreatedOn = DateTime.UtcNow
                },
                new()
                {
                    Title = "C# Advanced 2 2023",
                    Content = "C# advanced is a nice course to learn, to become better",
                    UserId = adminId,
                    IsPublic = true,
                    ImageUrl = "https://www.filepicker.io/api/file/2ZsQkVfR0yhZPRO33JEw",
                    CreatedBy = adminUserName,
                    CreatedOn = DateTime.UtcNow
                },
                new()
                {
                    Title = "Javascript Advanced 2023",
                    Content = "Take your JavaScript skills to the next level with our comprehensive JavaScript Advanced course.learning.\r\nPrerequisites:\r\nThis course is de",
                    IsPublic = true,
                    UserId = adminId,
                    ImageUrl = "https://i.ytimg.com/vi/YT8s-90oDC0/maxresdefault.jpg",
                    CreatedBy = adminUserName,
                    CreatedOn = DateTime.UtcNow
                },
                new()
                {
                    Title = "Python for Data Science",
                    Content = "Learn how to use Python for data analysis, visualization, and machine learning.",
                    UserId = adminId,
                    IsPublic = true,
                    ImageUrl = "https://www.example.com/images/python_data_science.jpg",
                    CreatedBy = adminUserName,
                    CreatedOn = DateTime.UtcNow
                },
                new()
                {
                    Title = "Introduction to Machine Learning",
                    Content = "An introductory course to machine learning algorithms and techniques.",
                    UserId = adminId,
                    IsPublic = true,
                    ImageUrl = "https://www.example.com/images/intro_to_ml.jpg",
                    CreatedBy = adminUserName,
                    CreatedOn = DateTime.UtcNow
                },
                new()
                {
                    Title = "Web Development with React",
                    Content = "Master the art of building modern web applications using React.js.",
                    UserId = adminId,
                    IsPublic = true,
                    ImageUrl = "https://www.example.com/images/react_web_dev.jpg",
                    CreatedBy = adminUserName,
                    CreatedOn = DateTime.UtcNow
                },
                new()
                {
                    Title = "Introduction to Artificial Intelligence",
                    Content = "Explore the fundamentals of artificial intelligence and its applications.",
                    UserId = adminId,
                    IsPublic = true,
                    ImageUrl = "https://www.example.com/images/intro_to_ai.jpg",
                    CreatedBy = adminUserName,
                    CreatedOn = DateTime.UtcNow
                }
            };

            var categoryResources = new CategoryResource[]
            {
                new()
                {
                    ResourceId = resources[0].Id,
                    CategoryId = categories[0].Id
                },
                new()
                {
                    ResourceId = resources[0].Id,
                    CategoryId = categories[4].Id
                },
                new()
                {
                    ResourceId = resources[1].Id,
                    CategoryId = categories[5].Id
                },
                new ()
                {
                    ResourceId = resources[1].Id,
                    CategoryId = categories[9].Id
                },
                new ()
                {
                    ResourceId = resources[2].Id,
                    CategoryId = categories[1].Id
                },
                new ()
                {
                    ResourceId = resources[2].Id,
                    CategoryId = categories[6].Id
                },
                new()
                {
                    ResourceId = resources[3].Id,
                    CategoryId = categories[2].Id
                },
                new()
                {
                    ResourceId = resources[3].Id,
                    CategoryId = categories[7].Id
                },

                new()
                {
                    ResourceId = resources[4].Id,
                    CategoryId = categories[3].Id
                },
                new ()
                {
                    ResourceId = resources[4].Id,
                    CategoryId = categories[8].Id
                },
                new ()
                {
                    ResourceId = resources[5].Id,
                    CategoryId = categories[8].Id
                },
                new ()
                {
                    ResourceId = resources[5].Id,
                    CategoryId = categories[4].Id
                },
                new ()
                {
                    ResourceId = resources[6].Id,
                    CategoryId = categories[2].Id
                },
                new ()
                {
                    ResourceId = resources[6].Id,
                    CategoryId = categories[4].Id
                },
                new ()
                {
                    ResourceId = resources[6].Id,
                    CategoryId = categories[9].Id
                }, new ()
                {
                    ResourceId = resources[6].Id,
                    CategoryId = categories[5].Id
                },
            };

            var comments = new Comment[]
            {
                new()
                {
                    Content = "This is comment send by seeded admin",
                    UserId = adminId,
                    ResourceId = resources[1].Id,
                    CreatedBy = adminUserName,
                    CreatedOn = DateTime.UtcNow,
                },
                new()
                {
                    Content = "This is comment send by seeded admin",
                    UserId = adminId,
                    ResourceId = resources[3].Id,
                    CreatedBy = adminUserName,
                    CreatedOn = DateTime.UtcNow,
                },
                new()
                {
                    Content = "This is comment send by seeded admin",
                    UserId = adminId,
                    ResourceId = resources[4].Id,
                    CreatedBy = adminUserName,
                    CreatedOn = DateTime.UtcNow,
                },
                new()
                {
                    Content = "This is comment send by seeded admin",
                    UserId = adminId,
                    ResourceId = resources[5].Id,
                    CreatedBy = adminUserName,
                    CreatedOn = DateTime.UtcNow,
                }

            };

            var courses = new Course[]
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

            var categoryCourses = new CategoryCourse[]
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

            var categoryCourseCourses = new CategoryCourseCourses[]
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

            var userCourses = new UserCourses[]
            {
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

            var categoryIssues = new CategoryIssue[]
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

            var videos = new Video[]
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

            var topics = new Topic[]
            {
                new()
                {
                    Name = "Introduction to javascript",
                    Content = "This is a brief introduction to Javascript",
                    StartTime = DateTime.UtcNow.AddDays(24),
                    EndTime = DateTime.Now.AddDays(24).AddHours(4),
                    CreatedBy = adminUserName,
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
                    CreatedBy = adminUserName,
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
                    CreatedBy = adminUserName,
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
                    CreatedBy = adminUserName,
                    CreatedOn = DateTime.UtcNow,
                    VideoId = videos[1].Id,
                    CourseId = courses[0].Id,
                },
            };

            modelBuilder.Entity<Category>()
                .HasData(categories);
            modelBuilder.Entity<Comment>()
                .HasData(comments);
            modelBuilder.Entity<Resource>()
                .HasData(resources);
            modelBuilder.Entity<CategoryResource>()
                .HasData(categoryResources);
            modelBuilder.Entity<CategoryIssue>()
                .HasData(categoryIssues);
            modelBuilder.Entity<Course>()
                .HasData(courses);
            modelBuilder.Entity<UserCourses>()
                .HasData(userCourses);
            modelBuilder.Entity<CategoryCourse>()
                .HasData(categoryCourses);
            modelBuilder.Entity<CategoryCourseCourses>()
                .HasData(categoryCourseCourses);
            modelBuilder.Entity<Video>()
                .HasData(videos);
            modelBuilder.Entity<Topic>()
                .HasData(topics);

        }

        private static string CreatePassword(User user, string password)
        {
            var passwordHasher = new PasswordHasher<User>();
            return passwordHasher.HashPassword(user, password);
        }
    }
}