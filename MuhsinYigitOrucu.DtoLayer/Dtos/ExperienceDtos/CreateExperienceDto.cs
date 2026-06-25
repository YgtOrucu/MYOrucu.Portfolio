namespace MuhsinYigitOrucu.DtoLayer.Dtos.ExperienceDtos
{
    public class CreateExperienceDto
    {
        public string? Company { get; set; }
        public string? Title { get; set; }
        public string? Date { get; set; }
        public string? WorkMethod { get; set; }
        public List<string>? Description { get; set; }
        public List<string>? UseTechnology { get; set; }
    }
}
