namespace MuhsinYigitOrucu.DtoLayer.Dtos.SkillsDto
{
    public class UpdateSkillsDto
    {
        public int SkillsId { get; set; }
        public string? CategoryName { get; set; }
        public Dictionary<string, string>? SkillItem { get; set; }
    }
}
