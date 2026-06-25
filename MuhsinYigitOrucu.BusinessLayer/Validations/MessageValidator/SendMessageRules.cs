using FluentValidation;
using MuhsinYigitOrucu.DtoLayer.UIDtos.SendMessageSectionDto;

namespace MuhsinYigitOrucu.BusinessLayer.Validations.MessageValidator
{
    public class SendMessageRules : AbstractValidator<SendMessageDto>
    {
        public SendMessageRules()
        {
            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("Konu alanı boş geçilemez.")
                .MaximumLength(50).WithMessage("Konu alanı en fazla 50 karakter olabilir.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Mesaj içeriği boş geçilemez.")
                .MaximumLength(800).WithMessage("Mesaj içeriği en fazla 800 karakter olabilir.");

            RuleFor(x => x.NameSurname)
                .NotEmpty().WithMessage("Ad Soyad alanı boş geçilemez.")
                .MaximumLength(60).WithMessage("Ad Soyad alanı en fazla 60 karakter olabilir.")
                .MinimumLength(3).WithMessage("Ad Soyad alanı en az 3 karakter olmalıdır.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta adresi boş geçilemez.")
                .EmailAddress().WithMessage("Lütfen geçerli bir e-posta adresi giriniz.")
                .MaximumLength(25).WithMessage("E-posta adresi en fazla 25 karakter olabilir.");

            RuleFor(x => x.IsRead)
                .NotEmpty().WithMessage("Okundu bilgisi boş bırakılamaz.")
                .MaximumLength(10).WithMessage("Okundu durumu en fazla 10 karakter olabilir.")
                .Must(BeAValidStatus).WithMessage("Okundu bilgisi sadece'Okundu' veya 'Okunmadı' değerlerini alabilir.");
        }

        private bool BeAValidStatus(string isRead)
        {
            if (string.IsNullOrEmpty(isRead)) return false;

            var allowedValues = new[] {"Okundu", "Okunmadı", "okundu", "okunmadı" };
            return allowedValues.Contains(isRead);
        }
    }
}
