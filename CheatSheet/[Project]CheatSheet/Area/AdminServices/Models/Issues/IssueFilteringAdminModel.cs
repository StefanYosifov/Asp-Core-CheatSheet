namespace _Project_CheatSheet.Area.AdminServices.Models.Issues
{
    using Features.Category.Models;

    public class IssueFilteringAdminModel
    {

        public ICollection<IssueViewModel> Courses { get; set; } = null!;
        
        public ICollection<SortingModel> IssueSorting { get; set; } =null!;
    }
}
