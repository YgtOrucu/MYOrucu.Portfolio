using FluentValidation;
using MuhsinYigitOrucu.DtoLayer.Dtos.AboutDtos;

namespace MuhsinYigitOrucu.BusinessLayer.Validations.AboutValidator
{
    public class AboutUpdateRules : AbstractValidator<AboutUpdateDto>
    {
        public AboutUpdateRules()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Ad ve Soyad boş geçilemez.")
           .MinimumLength(5).WithMessage("Ad en az 5 karakter olabilir.")
           .MaximumLength(80).WithMessage("Ad en fazla 80 karakter olabilir.");

            RuleFor(x => x.BrandInitials).NotEmpty().WithMessage("Marka Başlıkları boş geçilemez.")
           .MaximumLength(20).WithMessage("Marka Başlıkları en fazla 20 karakter olabilir.");

            RuleFor(x => x.ShortBio).NotEmpty().WithMessage("Kısa Biyografi boş geçilemez.")
           .MaximumLength(300).WithMessage("Kısa Biyografi en fazla 300 karakter olabilir.");

            RuleFor(x => x.AvatarUrl).NotEmpty().WithMessage("Avatar URL boş geçilemez.");

            RuleFor(x => x.Location).NotEmpty().WithMessage("Konum boş geçilemez.")
           .MaximumLength(100).WithMessage("Konum en fazla 100 karakter olabilir.");

            RuleFor(x => x.EmailAddress).NotEmpty().WithMessage("E-posta Adresi boş geçilemez.")
           .MaximumLength(100).WithMessage("E-posta Adresi en fazla 100 karakter olabilir.");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon Numarası boş geçilemez.")
           .MaximumLength(20).WithMessage("Telefon Numarası en fazla 20 karakter olabilir.");

            RuleFor(x => x.GithubUrl).NotEmpty().WithMessage("GitHub URL boş geçilemez.")
           .MaximumLength(200).WithMessage("GitHub URL en fazla 200 karakter olabilir.");

            RuleFor(x => x.LinkedinUrl).NotEmpty().WithMessage("LinkedIn URL boş geçilemez.")
           .MaximumLength(200).WithMessage("LinkedIn URL en fazla 200 karakter olabilir.");
        }
    }
}
