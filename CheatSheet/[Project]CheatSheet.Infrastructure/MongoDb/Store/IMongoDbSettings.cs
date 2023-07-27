namespace _Project_CheatSheet.Infrastructure.MongoDb.Store
{
    public interface IMongoDbSettings
    {
        string DatabaseName{get;set;}
        string ConnectionString{get;set;}
        string CoursesCollectionName{get;set; }

    }
}
