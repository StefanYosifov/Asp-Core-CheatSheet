namespace _Project_CheatSheet.Infrastructure.Data.MongoDb.Models
{
    using Attributes;

    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    [BsonCollection("Courses")]
    public class CourseDetails
    {
        public CourseDetails()
        {
            TopicsCoverage = new HashSet<string>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }


        [BsonElement("courseId")]
        public string CourseId { get; set; }

        [BsonElement("summary")]
        public string Summary { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("topicCoverage")]
        public ICollection<string> TopicsCoverage { get; set; }

    }
}
