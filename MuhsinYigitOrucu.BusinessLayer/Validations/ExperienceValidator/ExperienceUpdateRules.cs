using FluentValidation;
using MuhsinYigitOrucu.DtoLayer.Dtos.ExperienceDtos;

namespace MuhsinYigitOrucu.BusinessLayer.Validations.ExperienceValidator
{
    public class ExperienceUpdateRules : AbstractValidator<UpdateExperienceDto>
    {
        public ExperienceUpdateRules()
        {
            RuleFor(x => x.Company).NotEmpty().WithMessage("Şirket boş geçilemez.")
            .MinimumLength(5).WithMessage("Şirket en az 5 karakter olabilir.")
            .MaximumLength(40).WithMessage("Şirket en fazla 40 karakter olabilir.");

            RuleFor(x => x.Title).NotEmpty().WithMessage("Unvan boş geçilemez.")
            .MinimumLength(5).WithMessage("Unvan en az 5 karakter olabilir.")
            .MaximumLength(40).WithMessage("Unvan en fazla 40 karakter olabilir.");

            RuleFor(x => x.Date).NotEmpty().WithMessage("Tarih boş geçilemez.")
            .MinimumLength(5).WithMessage("Tarih en az 5 karakter olabilir.")
            .MaximumLength(40).WithMessage("Tarih en fazla 40 karakter olabilir.");

            RuleFor(x => x.WorkMethod).NotEmpty().WithMessage("Çalışma yöntemi boş geçilemez.")
            .MinimumLength(3).WithMessage("Çalışma yöntemi en az 3 karakter olabilir.")
            .MaximumLength(40).WithMessage("Çalışma yöntemi en fazla 40 karakter olabilir.");
        }
    }
}
