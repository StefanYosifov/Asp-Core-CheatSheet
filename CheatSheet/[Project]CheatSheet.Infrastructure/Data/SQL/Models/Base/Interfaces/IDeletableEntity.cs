﻿namespace _Project_CheatSheet.Infrastructure.Data.SQL.Models.Base.Interfaces
{
    public interface IDeletableEntity : IEntity
    {
        public DateTime DeletedOn { get; set; }

        public string DeletedBy { get; set; }

        public bool IsDeleted { get; set; }
    }
}