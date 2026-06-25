namespace MuhsinYigitOrucu.DtoLayer.Dtos.MessageDto
{
    public class CreateMessageDto
    {
        public string? NameSurname { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Description { get; set; }
        public string? IsRead { get; set; } = "Okunmadı";
    }
}
