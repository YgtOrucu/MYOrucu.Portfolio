namespace MuhsinYigitOrucu.DtoLayer.UIDtos.ProjectSectionDto
{
    public class GetForProjectSection
    {
        public int ProjectId { get; set; }
        public string? ImageUrl { get; set; }
        public string? Title { get; set; }
        public List<string>? UseTechnology { get; set; }
        public string? GithubLink { get; set; }
        public bool ShowOnHomePage { get; set; }

        private string? _miniDescription;
        public string? MiniDescription
        {
            get
            {
                if (string.IsNullOrEmpty(_miniDescription)) return _miniDescription;

                return _miniDescription.Length > 110 ? _miniDescription.Substring(0, 110) + "..." : _miniDescription;
            }
            set => _miniDescription = value;
        }
    }
}
