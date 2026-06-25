using Microsoft.AspNetCore.Http;

namespace MuhsinYigitOrucu.DtoLayer.Dtos.AboutDtos
{
    public class AboutCreateDto
    {
        public string? FullName { get; set; }
        public string? BrandInitials { get; set; }
        public string? ShortBio { get; set; }
        public string? AvatarUrl { get; set; }
        public IFormFile? FormFile { get; set; }
        public string? Location { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? GithubUrl { get; set; }
        public string? LinkedinUrl { get; set; }
        public List<string>? TypewriterTitles { get; set; }
        public List<string>? BioParagraphs { get; set; }
        public Dictionary<string, string>? QuickInfo { get; set; }
    }
}
