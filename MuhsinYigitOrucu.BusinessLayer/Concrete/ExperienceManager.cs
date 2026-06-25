using FluentValidation;
using FluentValidation.Results;
using MuhsinYigitOrucu.BusinessLayer.Abstract;
using MuhsinYigitOrucu.DataAccessLayer.Abstract;
using MuhsinYigitOrucu.DtoLayer.Dtos.ExperienceDtos;
using MuhsinYigitOrucu.DtoLayer.UIDtos.ExperienceSectionDto;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.BusinessLayer.Concrete
{
    public class ExperienceManager : IExperienceService
    {
        private readonly IExperienceDal _experienceDal;
        private readonly IValidator<CreateExperienceDto> _createExperienceValidator;
        private readonly IValidator<UpdateExperienceDto> _updateExperienceValidator;

        public ExperienceManager(IExperienceDal experienceDal, IValidator<CreateExperienceDto> createExperienceValidator, IValidator<UpdateExperienceDto> updateExperienceValidator)
        {
            _experienceDal = experienceDal;
            _createExperienceValidator = createExperienceValidator;
            _updateExperienceValidator = updateExperienceValidator;
        }

        public async Task TDeleteAsync(Experience t) => await _experienceDal.DeleteAsync(t);
        public async Task<Experience> TGetByIdAsync(int id) => await _experienceDal.GetByIdAsync(id);
        public async Task<List<Experience>> TGetListAsync() => await _experienceDal.GetListAsync();
        public async Task TUpdateAsync(Experience t) => await _experienceDal.UpdateAsync(t);
        public async Task TInsertAsync(Experience t) => await _experienceDal.InsertAsync(t);
        public async Task<List<GetForExperienceSectionDto>> TGetForExperienceSectionAsync() => await _experienceDal.GetForExperienceSectionAsync();

        public async Task<ValidationResult> ValidatorForCreateExperienceOperationsAsync(CreateExperienceDto createExperienceDto)
        {
            return await _createExperienceValidator.ValidateAsync(createExperienceDto);
        }

        public async Task<ValidationResult> ValidatorForUpdateExperienceOperationsAsync(UpdateExperienceDto updateExperienceDto)
        {
            return await _updateExperienceValidator.ValidateAsync(updateExperienceDto);
        }
    }
}
