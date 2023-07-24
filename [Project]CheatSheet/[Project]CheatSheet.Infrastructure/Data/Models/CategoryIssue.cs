namespace _Project_CheatSheet.Infrastructure.Data.Models
{
    using System.Collections.Generic;

    public class CategoryIssue
    {
        public CategoryIssue()
        {
            Issues = new HashSet<Issue>();
        }

        public int Id { get; set; }

        public string LocationIssue { get; set; } = null!;

        public ICollection<Issue> Issues { get; set; }
    }
}
