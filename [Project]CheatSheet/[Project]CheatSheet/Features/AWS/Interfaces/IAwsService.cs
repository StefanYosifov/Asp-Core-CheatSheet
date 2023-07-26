namespace _Project_CheatSheet.Features.AWS.Interfaces
{
    using Amazon.S3.Model;

    using AwsResponseFileModel;

    public interface IAwsService
    {

        Task<string> UploadFile(Guid id,IFormFile file);

        string GetFile(Guid id);

        public Task<GetObjectResponse> GetAllFiles();

    }
}
