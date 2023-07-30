namespace _Project_CheatSheet.Infrastructure.Data.MongoDb.Store
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string DatabaseName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string CoursesCollectionName { get; set; } = string.Empty;
    }
}
