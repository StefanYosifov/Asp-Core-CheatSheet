namespace _Project_CheatSheet.Features.Resources.Models
{
    using _Project_CheatSheet.Common.Pagination;

    public class ResourceCollectionModel
    {

        public int TotalPageCount{get;set;}
        public Pagination<ResourceModel>? Resources { get; set; }
    }
}
