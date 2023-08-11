namespace _Project_CheatSheet.Features.Resources.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.Pagination;

    public class ResourceCollectionModel
    {
        [Required]
        public int TotalPageCount { get; set; }

        [Required]
        public Pagination<ResourceModel>? Resources { get; set; }
    }
}
