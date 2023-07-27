namespace _Project_CheatSheet.Infrastructure.Data.Models.Base.Interfaces
{
    public interface IEntity
    {
        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public string UpdatedBy { get; set; }
    }
}