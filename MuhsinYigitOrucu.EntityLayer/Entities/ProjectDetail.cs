using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace MuhsinYigitOrucu.EntityLayer.Entities
{
    public class ProjectDetail
    {
        public int ProjectDetailId { get; set; }
        public string? Title { get; set; }
        public string? ShortDescription { get; set; }
        public string? FullDescription { get; set; }
        public string? CoverImageUrl { get; set; }
        public string? GalleryImagesJson { get; set; }
        public string? Category { get; set; } 
        public string? Status { get; set; }
        public string? Year { get; set; } 
        public string? Duration { get; set; } 
        public string? Role { get; set; } 
        public string? TeamSize { get; set; }
        public string? GithubLink { get; set; }
        public string? LiveDemoUrl { get; set; }
        public string? UseTechnologyJson { get; set; } 
        public string? FeaturesJson { get; set; }
        public string? ChallengesJson { get; set; }

        public int ProjectId { get; set; }
        public virtual Project? Project { get; set; }


        [NotMapped]
        public List<string> GalleryImages
        {
            get => string.IsNullOrEmpty(GalleryImagesJson)
                ? new()
                : JsonSerializer.Deserialize<List<string>>(GalleryImagesJson) ?? new();
            set => GalleryImagesJson = JsonSerializer.Serialize(value);
        }

        [NotMapped]
        public List<string> UseTechnology
        {
            get => string.IsNullOrEmpty(UseTechnologyJson)
                ? new()
                : JsonSerializer.Deserialize<List<string>>(UseTechnologyJson) ?? new();
            set => UseTechnologyJson = JsonSerializer.Serialize(value);
        }
        [NotMapped]
        public List<string> Features
        {
            get => string.IsNullOrEmpty(FeaturesJson)
                ? new()
                : JsonSerializer.Deserialize<List<string>>(FeaturesJson) ?? new();
            set => FeaturesJson = JsonSerializer.Serialize(value);
        }

        [NotMapped]
        public List<string> Challenges
        {
            get => string.IsNullOrEmpty(ChallengesJson)
                ? new()
                : JsonSerializer.Deserialize<List<string>>(ChallengesJson) ?? new();
            set => ChallengesJson = JsonSerializer.Serialize(value);
        }
    }
}
