namespace _Project_CheatSheet.Features.Resources.Models
{
    using Enums;

    public class ResourceQueryModel
    {

        public string? Search { get; set; }

        public string? Category { get; set; }

        public ResourceSorting? Sort { get; set; }

    }
}
