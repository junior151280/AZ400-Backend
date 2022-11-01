namespace AZ400_Backend.Models
{
    public class Package
    {
        public string Id { get; set; }
        public bool IsCached { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ProtocolType { get; set; }
        public string Url { get; set; }
        public MinimalPackageVersion[] Versions { get; set; }
    }
}
