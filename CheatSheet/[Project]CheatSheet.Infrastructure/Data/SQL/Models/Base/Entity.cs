namespace _Project_CheatSheet.Infrastructure.Data.SQL.Models.Base
{
    using Interfaces;

    public abstract class Entity : IEntity
    {
        public DateTime CreatedOn { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public string? UpdatedBy { get; set; }
    }
}