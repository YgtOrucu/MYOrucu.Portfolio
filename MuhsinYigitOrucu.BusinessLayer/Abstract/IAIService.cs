namespace MuhsinYigitOrucu.BusinessLayer.Abstract
{
    public interface IAIService
    {
        Task<string> GenerateMessageAsync(string nameSurname, string subject, string body);
    }
}
