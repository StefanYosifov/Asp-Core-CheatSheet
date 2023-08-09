namespace _Project_CheatSheet.Features.AWS.Models
{
    using Microsoft.AspNetCore.WebUtilities;

    public class AwsFileModel
    {
        public byte[] Bytes { get; set; }

        public string ContentType { get; set; }
    }
}
