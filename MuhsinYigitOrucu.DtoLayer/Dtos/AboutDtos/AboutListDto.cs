namespace MuhsinYigitOrucu.DtoLayer.Dtos.AboutDtos
{
    public class AboutListDto
    {
        public int AboutId { get; set; }
        public string? FullName { get; set; }
        public string? BrandInitials { get; set; }
        public string? Location { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }

        private string? _shortBio;
        public string? ShortBio
        {
            get
            {
                if (string.IsNullOrEmpty(_shortBio)) return _shortBio;

                return _shortBio.Length > 50 ? _shortBio.Substring(0, 50) + "..." : _shortBio;
            }
            set => _shortBio = value;
        }
    }
}
