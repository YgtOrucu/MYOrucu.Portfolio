using Microsoft.AspNetCore.Http;

namespace MuhsinYigitOrucu.DtoLayer.Dtos.ProjectDtos
{
    public class CreateProjectDto
    {
        public string? ImageUrl { get; set; }
        public IFormFile? FormFile { get; set; }
        public string? Title { get; set; }
        public string? MiniDescription { get; set; }
        public List<string>? UseTechnology { get; set; }
        public string? GithubLink { get; set; }
        public bool ShowOnHomePage { get; set; }
    }
}
