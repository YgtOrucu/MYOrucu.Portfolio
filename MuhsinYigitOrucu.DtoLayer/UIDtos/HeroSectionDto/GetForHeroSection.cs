namespace MuhsinYigitOrucu.DtoLayer.UIDtos.HeroSectionDto
{
    public class GetForHeroSection
    {
        public string? FullName { get; set; }
        public string? ShortBio { get; set; }
        public string? GithubUrl { get; set; }
        public string? LinkedinUrl { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Location { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BrandInitials { get; set; }
        public List<string>? TypewriterTitles { get; set; }
    }
}
