using FluentValidation;
using MuhsinYigitOrucu.DtoLayer.Dtos.SkillsDto;

namespace MuhsinYigitOrucu.BusinessLayer.Validations.SkillsValidator
{
    public class SkillsUpdateRules : AbstractValidator<UpdateSkillsDto>
    {
        public SkillsUpdateRules()
        {
            RuleFor(x => x.CategoryName)
           .NotEmpty().WithMessage("Yetenek kategorisi boş geçilemez.");

            RuleFor(x => x.SkillItem)
                .NotEmpty().WithMessage("En az bir adet yetenek eklemelisiniz.")
                .Must(kvp => kvp != null && kvp.Count > 0).WithMessage("Yetenek listesi boş olamaz.");

            RuleForEach(x => x.SkillItem).ChildRules(item =>
            {
                item.RuleFor(kvp => kvp.Key)
                    .NotEmpty().WithMessage("Yetenek adı boş olamaz.");

                item.RuleFor(kvp => kvp.Value)
                    .NotEmpty().WithMessage("Yetenek iconu boş olamaz.");
            });
        }
    }
}
