namespace _Project_CheatSheet.Area.AdminServices.Models.Issues
{
    using Common.Pagination;

    public class PaginatedIssuesAdminModel
    {

        public int TotalPages { get; set; }

        public Pagination<GetIssuesAdminModel> Issues { get; set; }
    }
}
