namespace AZ400_Backend.Models
{
    public class MinimalPackageVersion
    {
        public string Id { get; set; }
        public string PackageDescription { get; set; }
        
        public string Version { get; set; }
        public string NormalizedVersion { get; set; }
        public string DownloadUrl { get; set; }
        
    }
}
