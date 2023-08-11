namespace _Project_CheatSheet.Features.Statistics.Models
{
    using System.ComponentModel.DataAnnotations;

    public class StatisticsModel
    {
        [Required] public int ResourcesCount { get; set; }

        [Required] public int UsersCount { get; set; }
    }
}