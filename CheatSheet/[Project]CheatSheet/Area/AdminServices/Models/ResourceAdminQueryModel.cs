namespace _Project_CheatSheet.Area.AdminServices.Models
{
    using Features.Course.Enums;

    public class ResourceAdminQueryModel
    {
        public CourseFilters CourseActivity { get; set; }
        public string? CategoryName { get; set; }
        public string? Search { get; set; }

    }
}
