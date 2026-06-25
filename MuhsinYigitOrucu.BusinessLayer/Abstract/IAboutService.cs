using FluentValidation.Results;
using MuhsinYigitOrucu.DtoLayer.Dtos.AboutDtos;
using MuhsinYigitOrucu.DtoLayer.UIDtos.AboutSectionDto;
using MuhsinYigitOrucu.DtoLayer.UIDtos.HeroSectionDto;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.BusinessLayer.Abstract
{
    public interface IAboutService : IGenericService<About>
    {
        Task<ValidationResult> ValidatorForCreateAboutOperationsAsync(AboutCreateDto aboutCreateDto);
        Task<ValidationResult> ValidatorForUpdateAboutOperationsAsync(AboutUpdateDto aboutUpdateDto);
        Task<GetForHeroSection> TGetForHeroSectionAsync();
        Task<GetForAboutSection> TGetForAboutSectionAsync();
    }
}
