namespace _Project_CheatSheet.Features.AWS.Services
{
    using _Project_CheatSheet.Infrastructure.Data.SQL;
    using Amazon.S3;
    using Amazon.S3.Model;

    using Common.Caching;
    using Common.Exceptions;
    using Common.UserService.Interfaces;

    using Constants.CachingConstants;
    using Constants.GlobalConstants.AWS;
    using Constants.GlobalConstants.Course;

    using Interfaces;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Caching.Memory;

    public class AwsService : IAwsService
    {
        private const string BucketName = "pdffiles";
        private readonly IMemoryCache cache;
        private readonly ICacheService cacheService;
        private readonly CheatSheetDbContext context;
        private readonly IAmazonS3 s3;
        private readonly ICurrentUser userService;

        public AwsService(
            IAmazonS3 s3,
            ICurrentUser userService,
            CheatSheetDbContext context,
            IMemoryCache cache,
            ICacheService cacheService)
        {
            this.s3 = s3;
            this.userService = userService;
            this.context = context;
            this.cache = cache;
            this.cacheService = cacheService;
        }

        public async Task<string> UploadFile(Guid id, IFormFile file)
        {
            try
            {
                var putObjectRequest = new PutObjectRequest
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
                return string.Format(AwsMessages.SuccessfulUpload, putObjectRequest.ContentType, putObjectRequest.Key);
            }
            catch (AmazonS3Exception)
            {
                return AwsMessages.FailedToUpload;
            }
            catch (Exception)
            {
                return AwsMessages.FailedToUpload;
            }
        }

        public async Task<string> GetFile(Guid id)
        {
            var userId = userService.GetUserId();
            await CheckIfUserIsInCourse(id, userId);

            var cacheKey = $"Pdf_{id}";
            if (cache.TryGetValue(cacheKey, out string cachedPdfUrl))
            {
                return cachedPdfUrl;
            }

            var request = new GetPreSignedUrlRequest
            {
                BucketName = BucketName,
                Key = $"{id}",
                Expires = DateTime.Now.AddMinutes(CachingConstants.Lessons.PdfFileUrl)
            };

            var imageUrl = s3.GetPreSignedURL(request);
            cacheService.SetCache(cacheKey, imageUrl, CachingConstants.Lessons.PdfFileUrl);
            return imageUrl;
        }

        public Task<GetObjectResponse> GetAllFiles()
        {
            throw new NotImplementedException();
        }

        private async Task CheckIfUserIsInCourse(Guid id, string userId)
        {
            var course = await context.Courses
                .Include(c => c.Topics)
                .ThenInclude(v => v.Video)
                .Where(c => c.Topics.Any(t => t.Id == id))
                .FirstOrDefaultAsync();

            CustomException.ThrowIfNull(course, CourseMessages.CourseNotFound);

            bool userNotInCourse = await context.UserCourses
                .AllAsync(uc => uc.UserId != userId
                                && uc.CourseId.ToString() != course.Id.ToString());

            if (userNotInCourse)
            {
                throw new ServiceException(CourseMessages.UserNotInCourse);
            }
        }
    }
}