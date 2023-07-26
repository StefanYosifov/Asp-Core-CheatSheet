namespace _Project_CheatSheet.Features.AWS.AwsResponseFileModel
{
    using Microsoft.AspNetCore.WebUtilities;

    public class AwsResponseFileModel
    {
        public byte[] Bytes{ get; set; }

        public string ContentType { get; set; }
    }
}
