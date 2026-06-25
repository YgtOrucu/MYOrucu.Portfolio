namespace MuhsinYigitOrucu.DtoLayer.UIDtos.SendMessageSectionDto
{
    public class SendMessageDto
    {
        public string? NameSurname { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Description { get; set; }
        public string? IsRead { get; set; } = "Okunmadı";
    }
}
