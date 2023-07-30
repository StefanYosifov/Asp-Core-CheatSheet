namespace _Project_CheatSheet.Infrastructure.Data.SQL.Models.Base
{
    using Interfaces;

    public abstract class DeletableEntity : Entity, IDeletableEntity
    {
        public DateTime DeletedOn { get; set; }
        public string? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}