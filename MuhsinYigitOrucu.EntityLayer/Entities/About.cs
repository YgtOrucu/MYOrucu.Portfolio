using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace MuhsinYigitOrucu.EntityLayer.Entities
{
    public class About
    {
        public int AboutId { get; set; }
        public string? FullName { get; set; }
        public string? BrandInitials { get; set; }
        public string? ShortBio { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Location { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? GithubUrl { get; set; }
        public string? LinkedinUrl { get; set; }
        public string? TypewriterTitlesJson { get; set; }
        public string? BioParagraphsJson { get; set; }
        public string? QuickInfoJson { get; set; }

        [NotMapped]
        public List<string> TypewriterTitles
        {
            get => string.IsNullOrEmpty(TypewriterTitlesJson)
                ? new()
                : JsonSerializer.Deserialize<List<string>>(TypewriterTitlesJson) ?? new();
            set => TypewriterTitlesJson = JsonSerializer.Serialize(value);
        }

        [NotMapped]
        public List<string> BioParagraphs
        {
            get => string.IsNullOrEmpty(BioParagraphsJson)
                ? new()
                : JsonSerializer.Deserialize<List<string>>(BioParagraphsJson) ?? new();
            set => BioParagraphsJson = JsonSerializer.Serialize(value);
        }

        [NotMapped]
        public Dictionary<string, string> QuickInfo
        {
            get => string.IsNullOrEmpty(QuickInfoJson)
                ? new()
                : JsonSerializer.Deserialize<Dictionary<string, string>>(QuickInfoJson) ?? new();
            set => QuickInfoJson = JsonSerializer.Serialize(value);
        }
    }
}
