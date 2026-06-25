using FluentValidation;
using MuhsinYigitOrucu.DtoLayer.Dtos.ProjectDtos;

namespace MuhsinYigitOrucu.BusinessLayer.Validations.ProjectValidator
{
    public class ProjectCreateRules : AbstractValidator<CreateProjectDto>
    {
        public ProjectCreateRules()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Proje başlığı boş geçilemez.")
                .MinimumLength(3).WithMessage("Proje başlığı en az 3 karakter olmalıdır.")
                .MaximumLength(40).WithMessage("Proje başlığı en fazla 40 karakter olmalıdır.");

            RuleFor(x => x.MiniDescription)
                .NotEmpty().WithMessage("Proje kısa açıklaması boş geçilemez.")
                .MinimumLength(10).WithMessage("Kısa açıklama en az 10 karakter olmalıdır.")
                .MaximumLength(250).WithMessage("Kısa açıklama en fazla 250 karakter olmalıdır.");

            RuleFor(x => x.FormFile)
                .NotEmpty().WithMessage("Proje görsel linki boş geçilemez.");

            RuleFor(x => x.GithubLink)
                .Must(LinkGecerliMi).When(x => !string.IsNullOrEmpty(x.GithubLink))
                .WithMessage("Lütfen geçerli bir GitHub kaynak kod linki giriniz.");

            RuleFor(x => x.UseTechnology)
                .NotEmpty().WithMessage("En az bir adet teknoloji eklemek zorundasınız.")
                .Must(list => list != null && list.Count > 0).WithMessage("Teknoloji listesi boş olamaz.");

            RuleForEach(x => x.UseTechnology).ChildRules(tech =>
            {
                tech.RuleFor(t => t)
                    .NotEmpty().WithMessage("Teknoloji alanı boş bırakılamaz, lütfen boş alanları temizleyin.")
                    .MaximumLength(30).WithMessage("Bir teknoloji adı en fazla 30 karakter olabilir.");
            });
        }
        private bool LinkGecerliMi(string? url)
        {
            if (string.IsNullOrEmpty(url)) return false;
            return Uri.TryCreate(url, UriKind.Absolute, out var uriResult)
                   && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }

}
