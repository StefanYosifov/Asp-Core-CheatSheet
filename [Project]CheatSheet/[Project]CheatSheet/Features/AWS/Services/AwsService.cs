namespace _Project_CheatSheet.Features.AWS.Services
{
    using Amazon.S3;
    using Amazon.S3.Model;

    using AwsResponseFileModel;

    using Constants.GlobalConstants.AWS;

    using Interfaces;

    public class AwsService:IAwsService
    {
        private readonly IAmazonS3 s3;

        public AwsService(IAmazonS3 s3)
        {
            this.s3 = s3;
        }

        private const string BucketName="pdffiles";

        public async Task<string> UploadFile(Guid id, IFormFile file)
        {
            try
            {
                var putObjectRequest = new PutObjectRequest()
                {
                    BucketName = BucketName,
                    Key = $"{id}",
                    ContentType = file.ContentType,
                    InputStream = file.OpenReadStream(),
                    Metadata =
                    {
                        ["x-amz-meta-originalname"] = file.FileName,
                        ["x-amz-meta-extension"] = Path.GetExtension(file.Name)
                    }
                };

                await s3.PutObjectAsync(putObjectRequest);
                return string.Format(AwsMessages.SuccessfulUpload,putObjectRequest.ContentType,putObjectRequest.Key);
            }
            catch (AmazonS3Exception ex)
            {
                return AwsMessages.FailedToUpload;
            }
            catch (Exception ex)
            {
                return AwsMessages.FailedToUpload;
            }
        }

        public string GetFile(Guid id)
        {

            GetPreSignedUrlRequest request = new GetPreSignedUrlRequest
            {
                BucketName = BucketName,
                Key = $"{id}",
                Expires = DateTime.Now.AddMinutes(15)
            };

           return s3.GetPreSignedURL(request);

        }

        public Task<GetObjectResponse> GetAllFiles()
        {
            throw new NotImplementedException();
        }
    }
}
