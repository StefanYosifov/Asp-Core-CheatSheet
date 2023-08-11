namespace _Project_CheatSheet.Features.Category.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SortingModel
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
}
