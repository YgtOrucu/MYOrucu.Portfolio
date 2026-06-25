using FluentValidation.Results;
using MuhsinYigitOrucu.DtoLayer.Dtos.ExperienceDtos;
using MuhsinYigitOrucu.DtoLayer.UIDtos.ExperienceSectionDto;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.BusinessLayer.Abstract
{
    public interface IExperienceService : IGenericService<Experience>
    {
        Task<List<GetForExperienceSectionDto>> TGetForExperienceSectionAsync();
        Task<ValidationResult> ValidatorForCreateExperienceOperationsAsync(CreateExperienceDto dto);
        Task<ValidationResult> ValidatorForUpdateExperienceOperationsAsync(UpdateExperienceDto dto);
    }
}
