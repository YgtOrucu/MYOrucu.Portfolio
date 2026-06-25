using FluentValidation;
using MuhsinYigitOrucu.DtoLayer.Dtos.ProjectDetailsDto;

namespace MuhsinYigitOrucu.BusinessLayer.Validations.ProjectDetailsValidator
{
    public class ProjectDetailsCreateRules : AbstractValidator<CreateProjectDetailsDto>
    {
        public ProjectDetailsCreateRules()
        {
            RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Proje başlığı boş geçilemez.")
            .MaximumLength(150).WithMessage("Proje başlığı en fazla 150 karakter olabilir.");

            RuleFor(x => x.ShortDescription)
                .NotEmpty().WithMessage("Kısa açıklama alanı boş geçilemez.")
                .MaximumLength(250).WithMessage("Kısa açıklama en fazla 250 karakter olabilir.");

            RuleFor(x => x.FullDescription)
                .MaximumLength(4000).WithMessage("Detaylı açıklama en fazla 4000 karakter olabilir.");

            RuleFor(x => x.CoverImageFile)
                .NotEmpty().WithMessage("Proje kapak görseli boş geçilemez.");

            RuleFor(x => x.GalleryImageFile)
                .NotEmpty().WithMessage("Mutlaka Proje görselleri olmalıdır.");

            RuleFor(x => x.Category)
                .MaximumLength(100).WithMessage("Kategori adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.Status)
                .MaximumLength(50).WithMessage("Durum bilgisi en fazla 50 karakter olabilir.");

            RuleFor(x => x.Year)
                .MaximumLength(20).WithMessage("Yıl bilgisi en fazla 20 karakter olabilir.");

            RuleFor(x => x.Duration)
                .MaximumLength(50).WithMessage("Süre bilgisi en fazla 50 karakter olabilir.");

            RuleFor(x => x.Role)
                .MaximumLength(100).WithMessage("Rol bilgisi en fazla 100 karakter olabilir.");

            RuleFor(x => x.TeamSize)
                .MaximumLength(50).WithMessage("Ekip boyutu bilgisi en fazla 50 karakter olabilir.");

            RuleFor(x => x.GithubLink)
                .Must(LinkGecerliMi).When(x => !string.IsNullOrEmpty(x.GithubLink))
                .WithMessage("Lütfen geçerli bir GitHub kaynak kod linki giriniz.");

            RuleFor(x => x.LiveDemoUrl)
                .Must(LinkGecerliMi).When(x => !string.IsNullOrEmpty(x.LiveDemoUrl))
                .WithMessage("Lütfen geçerli bir canlı demo linki giriniz.");

            RuleForEach(x => x.UseTechnology).ChildRules(tech =>
            {
                tech.RuleFor(t => t)
                    .NotEmpty().WithMessage("Teknoloji alanı boş bırakılamaz.")
                    .MaximumLength(50).WithMessage("Bir teknoloji adı en fazla 50 karakter olabilir.");
            });

            RuleForEach(x => x.Features).ChildRules(feat =>
            {
                feat.RuleFor(f => f)
                    .NotEmpty().WithMessage("Özellik alanı boş bırakılamaz.")
                    .MaximumLength(250).WithMessage("Bir özellik açıklaması en fazla 250 karakter olabilir.");
            });

            RuleForEach(x => x.Challenges).ChildRules(chal =>
            {
                chal.RuleFor(c => c)
                    .NotEmpty().WithMessage("Zorluk/Çözüm alanı boş bırakılamaz.")
                    .MaximumLength(500).WithMessage("Bir teknik zorluk açıklaması en fazla 500 karakter olabilir.");
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
