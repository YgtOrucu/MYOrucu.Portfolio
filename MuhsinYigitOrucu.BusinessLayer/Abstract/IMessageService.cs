using FluentValidation.Results;
using MuhsinYigitOrucu.DtoLayer.Dtos.MessageDto;
using MuhsinYigitOrucu.DtoLayer.UIDtos.SendMessageSectionDto;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.BusinessLayer.Abstract
{
    public interface IMessageService : IGenericService<Message>
    {
        Task<ValidationResult> ValidatorForCreateMessageOperationsAsync(SendMessageDto sendMessageDto);
        Task<string> GenerateMessageWithAIAsync(string nameSurname, string subject, string body);
        Task SendEmailAsync(SendMailViewModel sendMailViewModel);
    }
}
