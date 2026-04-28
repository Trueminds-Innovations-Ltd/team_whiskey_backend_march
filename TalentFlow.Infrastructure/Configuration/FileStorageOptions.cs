namespace TalentFlow.Infrastructure.Configuration
{
    public class FileStorageOptions
    {
        public string BaseUrl { get; set; } = string.Empty;
        public string UploadsPath { get; set; } = "uploads";
    }
}
