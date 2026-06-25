using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace MuhsinYigitOrucu.EntityLayer.Entities
{
    public class Skills
    {
        public int SkillsId { get; set; }
        public string? CategoryName { get; set; }
        public string? SkillItemJson { get; set; }

        [NotMapped]
        public Dictionary<string, string> SkillItem
        {
            get => string.IsNullOrEmpty(SkillItemJson)
                ? new()
                : JsonSerializer.Deserialize<Dictionary<string, string>>(SkillItemJson) ?? new();
            set => SkillItemJson = JsonSerializer.Serialize(value);
        }
    }
}
