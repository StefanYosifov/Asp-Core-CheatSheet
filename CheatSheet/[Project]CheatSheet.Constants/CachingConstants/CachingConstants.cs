﻿namespace _Project_CheatSheet.Constants.CachingConstants
{
    public static class CachingConstants
    {
        public class Course
        {
            public const int PublicCoursesCache = 30;
            public const int MyCoursesCache = 720;
            public const int CategoriesCoursesCache = 1440;
            public const int UpComingCourses=60;
            public const int CourseStatistics=5;
        }

        public class Statistics
        {
            public const int HomeStatistics = 5;
        }

        public class Lessons
        {
            public const int YoutubeUrl = 25;
            public const int PdfFileUrl = 25;
        }
    }
}