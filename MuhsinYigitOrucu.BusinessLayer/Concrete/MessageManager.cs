using FluentValidation;
using MuhsinYigitOrucu.BusinessLayer.Abstract;
using MuhsinYigitOrucu.DataAccessLayer.Abstract;
using MuhsinYigitOrucu.EntityLayer.Entities;
using MuhsinYigitOrucu.DtoLayer.UIDtos.SendMessageSectionDto;
using FluentValidation.Results;
using MuhsinYigitOrucu.DtoLayer.Dtos.MessageDto;

namespace MuhsinYigitOrucu.BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _MessageDal;
        private readonly IAIService _IAIService;
        private readonly IMailService _MailService;
        private readonly IValidator<SendMessageDto> _MessageCreateValidator;

        public MessageManager(IMessageDal MessageDal, IValidator<SendMessageDto> MessageCreateValidator, IAIService ıAIService, IMailService mailService)
        {
            _MessageDal = MessageDal;
            _MessageCreateValidator = MessageCreateValidator;
            _IAIService = ıAIService;
            _MailService = mailService;
        }

        public async Task TDeleteAsync(Message t) => await _MessageDal.DeleteAsync(t);
        public async Task<Message> TGetByIdAsync(int id) => await _MessageDal.GetByIdAsync(id);
        public async Task<List<Message>> TGetListAsync() => await _MessageDal.GetListAsync();
        public async Task TUpdateAsync(Message t) => await _MessageDal.UpdateAsync(t);
        public async Task TInsertAsync(Message t) => await _MessageDal.InsertAsync(t);

        public async Task<ValidationResult> ValidatorForCreateMessageOperationsAsync(SendMessageDto SendMessageDto)
        {
            return await _MessageCreateValidator.ValidateAsync(SendMessageDto);
        }

        public async Task<string> GenerateMessageWithAIAsync(string nameSurname, string subject, string body)
        {
            return await _IAIService.GenerateMessageAsync(nameSurname, subject, body);
        }

        public async Task SendEmailAsync(SendMailViewModel sendMailViewModel)
        {
            await _MailService.SendEmailAsync(sendMailViewModel.Email, sendMailViewModel.Subject, sendMailViewModel.Body);
        }
    }
}
