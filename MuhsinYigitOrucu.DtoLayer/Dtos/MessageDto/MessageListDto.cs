namespace MuhsinYigitOrucu.DtoLayer.Dtos.MessageDto
{
    public class MessageListDto
    {
        public int MessageId { get; set; }
        public string? NameSurname { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Description { get; set; }
        public string? IsRead { get; set; }
    }
}
