namespace MuhsinYigitOrucu.DtoLayer.Dtos.ProjectDetailsDto
{
    public class ProjectDetailsListDto
    {
        public int ProjectDetailId { get; set; }
        public string? Title { get; set; }
        public string? ShortDescription { get; set; }
        public string? FullDescription { get; set; }
        public string? CoverImageUrl { get; set; }
        public List<string>? GalleryImages { get; set; }
        public string? Category { get; set; }
        public string? Status { get; set; }
        public string? Year { get; set; }
        public string? Duration { get; set; }
        public string? Role { get; set; }
        public string? TeamSize { get; set; }
        public string? GithubLink { get; set; }
        public string? LiveDemoUrl { get; set; }
        public List<string>? UseTechnology { get; set; }
        public List<string>? Features { get; set; }
        public List<string>? Challenges { get; set; }
    }
}
