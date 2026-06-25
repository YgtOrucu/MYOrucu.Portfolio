using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace MuhsinYigitOrucu.EntityLayer.Entities
{
    public class Experience
    {
        public int ExperienceId { get; set; }
        public string? Company { get; set; }
        public string? Title { get; set; }
        public string? Date { get; set; }
        public string? WorkMethod { get; set; }
        public string? DescriptionJson { get; set; }
        public string? UseTechnologyJson { get; set; }

        [NotMapped]

        public List<string> Description
        {
            get => string.IsNullOrEmpty(DescriptionJson)
                ? new()
                : JsonSerializer.Deserialize<List<string>>(DescriptionJson) ?? new();
            set => DescriptionJson = JsonSerializer.Serialize(value);
        }

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
