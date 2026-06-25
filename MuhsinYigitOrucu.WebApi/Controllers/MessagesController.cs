using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MuhsinYigitOrucu.BusinessLayer.Abstract;
using MuhsinYigitOrucu.DtoLayer.Dtos.MessageDto;
using MuhsinYigitOrucu.DtoLayer.UIDtos.SendMessageSectionDto;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _MessageService;
        private readonly IMapper _mapper;

        public MessagesController(IMessageService MessageService, IMapper mapper)
        {
            _MessageService = MessageService;
            _mapper = mapper;
        }

        [HttpGet("MessageList")]
        public async Task<IActionResult> MessageList()
        {
            var Messages = await _MessageService.TGetListAsync();
            var MessageListDtos = _mapper.Map<List<MessageListDto>>(Messages);
            return Ok(MessageListDtos);
        }

        [HttpGet("GetByIdMessage")]
        public async Task<IActionResult> GetByIdMessage(int id)
        {
            var GetMessages = await _MessageService.TGetByIdAsync(id);
            return Ok(_mapper.Map<MessageListDto>(GetMessages));
        }

        [HttpPost("MessageCreate")]
        public async Task<IActionResult> MessageCreate(SendMessageDto sendMessageDto)
        {
            var validationResult = await _MessageService.ValidatorForCreateMessageOperationsAsync(sendMessageDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(errors);
            }
            await _MessageService.TInsertAsync(_mapper.Map<Message>(sendMessageDto));
            return Ok("Mesaj oluşturuldu");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedvalue = await _MessageService.TGetByIdAsync(id);
            if (deletedvalue != null)
            {
                await _MessageService.TDeleteAsync(deletedvalue);
                return Ok("Silme İşlemi Başarılı");
            }
            return NotFound("Hata: Kayıt bulunamadı.");
        }

        [HttpGet("GenerateMessageWithAI/{messageId}")]
        public async Task<IActionResult> GenerateMessageWithAI(int messageId)
        {
            if(messageId <= 0)
                return BadRequest("MessageId bulunamadı.");

            var receiver = await _MessageService.TGetByIdAsync(messageId);

            if (receiver == null)
                return NotFound("Kullanıcı bulunamadı.");
            
            string aiResponse = await _MessageService.GenerateMessageWithAIAsync(receiver.NameSurname!,receiver.Subject!,receiver.Description!);
            return Ok(aiResponse);
        }

        [HttpPost("SendMessageMail")]
        public async Task<IActionResult> SendMessageMail(SendMailViewModel sendMailView)
        {
            await _MessageService.SendEmailAsync(sendMailView);
            var getMessage = await _MessageService.TGetByIdAsync(sendMailView.MessageId);
            getMessage.IsRead = "Okundu";
            await _MessageService.TUpdateAsync(getMessage);
            return Ok("Mesaj Gönderildi ve Durumu Okundu olarak değiştirildi.");
        }
    }
}
