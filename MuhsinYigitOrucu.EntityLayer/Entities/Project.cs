using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace MuhsinYigitOrucu.EntityLayer.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string? ImageUrl { get; set; }
        public string? Title { get; set; }
        public string? MiniDescription { get; set; }
        public string? UseTechnologyJson { get; set; }
        public string? GithubLink { get; set; }
        public bool ShowOnHomePage { get; set; }
        public virtual ProjectDetail? ProjectDetail { get; set; }


        [NotMapped]
        public List<string> UseTechnology
        {
            get => string.IsNullOrEmpty(UseTechnologyJson)
                ? new()
                : JsonSerializer.Deserialize<List<string>>(UseTechnologyJson) ?? new();
            set => UseTechnologyJson = JsonSerializer.Serialize(value);
        }
    }
}
