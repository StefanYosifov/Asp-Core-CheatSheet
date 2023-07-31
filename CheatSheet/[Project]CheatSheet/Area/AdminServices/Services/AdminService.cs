namespace _Project_CheatSheet.Area.AdminServices.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Features.Course.Enums;

    using Infrastructure.Data.SQL;

    using Interfaces;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class AdminService : IAdminService
    {

        private readonly CheatSheetDbContext context;
        private readonly IMapper mapper;

        public AdminService(
            CheatSheetDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ICollection<ResourceAdminModel>> GetListOfCourses(ResourceAdminQueryModel query)
        {
            var courses= context.Courses.AsNoTracking();

            if (!string.IsNullOrEmpty(query.Search))
            {
                var wildcard = $"%{query.Search.ToLower()}%";

                courses = courses.Where(c => EF.Functions.Like(c.Title.ToLower(), wildcard));
            }

            if (!string.IsNullOrWhiteSpace(query.CategoryName))
            {
                courses = courses.Where(c => c.CategoryCourseCourses.Any(cc =>cc.CategoryCourse.Name==query.CategoryName));
            }

            if (query.CourseActivity != null && query.CourseActivity.ToString() != "All")
            {
                courses = query.CourseActivity switch
                {
                    CourseFilters.Active => courses.Where(c => c.StartDate > DateTime.UtcNow),
                    CourseFilters.Passed => courses.Where(c => c.StartDate < DateTime.UtcNow),
                    CourseFilters.OnGoing => courses.Where(c => c.StartDate < DateTime.UtcNow && c.EndDate> DateTime.UtcNow),
                };
            }

            return await courses.ProjectTo<ResourceAdminModel>(mapper.ConfigurationProvider).ToArrayAsync();
        }


    }
}
