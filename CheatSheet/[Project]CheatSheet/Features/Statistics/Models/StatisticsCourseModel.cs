namespace _Project_CheatSheet.Features.Statistics.Models
{
    using System.ComponentModel.DataAnnotations;

    public class StatisticsCourseModel
    {
        [Required] public int CoursesCount { get; set; }

        [Required] public int UserCoursesCount { get; set; }
    }
}