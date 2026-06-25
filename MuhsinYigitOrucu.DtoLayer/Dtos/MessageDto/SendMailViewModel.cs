namespace MuhsinYigitOrucu.DtoLayer.Dtos.MessageDto
{
    public class SendMailViewModel
    {
        public int MessageId { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
