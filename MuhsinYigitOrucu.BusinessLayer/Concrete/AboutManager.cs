using FluentValidation;
using FluentValidation.Results;
using MuhsinYigitOrucu.BusinessLayer.Abstract;
using MuhsinYigitOrucu.DataAccessLayer.Abstract;
using MuhsinYigitOrucu.DtoLayer.Dtos.AboutDtos;
using MuhsinYigitOrucu.DtoLayer.UIDtos.AboutSectionDto;
using MuhsinYigitOrucu.DtoLayer.UIDtos.HeroSectionDto;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;
        private readonly IValidator<AboutCreateDto> _aboutCreateValidator;
        private readonly IValidator<AboutUpdateDto> _aboutUpdateValidator;

        public AboutManager(IAboutDal aboutDal, IValidator<AboutCreateDto> aboutCreateValidator, IValidator<AboutUpdateDto> aboutUpdateValidator)
        {
            _aboutDal = aboutDal;
            _aboutCreateValidator = aboutCreateValidator;
            _aboutUpdateValidator = aboutUpdateValidator;
        }

        public async Task TDeleteAsync(About t) => await _aboutDal.DeleteAsync(t);
        public async Task<About> TGetByIdAsync(int id) => await _aboutDal.GetByIdAsync(id);
        public async Task<List<About>> TGetListAsync() => await _aboutDal.GetListAsync();
        public async Task TUpdateAsync(About t) => await _aboutDal.UpdateAsync(t);
        public async Task TInsertAsync(About t) => await _aboutDal.InsertAsync(t);
        public async Task<GetForHeroSection> TGetForHeroSectionAsync() => await _aboutDal.GetForHeroSectionAsync();
        public async Task<GetForAboutSection> TGetForAboutSectionAsync()=> await _aboutDal.GetForAboutSectionAsync();

        public async Task<ValidationResult> ValidatorForCreateAboutOperationsAsync(AboutCreateDto aboutCreateDto)
        {
           return await _aboutCreateValidator.ValidateAsync(aboutCreateDto);
        }

        public async Task<ValidationResult> ValidatorForUpdateAboutOperationsAsync(AboutUpdateDto aboutUpdateDto)
        {
            return await _aboutUpdateValidator.ValidateAsync(aboutUpdateDto);
        }
    }
}
