namespace MuhsinYigitOrucu.DtoLayer.Dtos.SkillsDto
{
    public class SkillsListDto
    {
        public int SkillsId { get; set; }
        public string? CategoryName { get; set; }
        public Dictionary<string, string>? SkillItem { get; set; }
    }
}
