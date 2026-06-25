using FluentValidation.Results;
using MuhsinYigitOrucu.DtoLayer.Dtos.SkillsDto;
using MuhsinYigitOrucu.DtoLayer.UIDtos.SkillsSectionDto;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.BusinessLayer.Abstract
{
    public interface ISkillsService : IGenericService<Skills>
    {
        Task<List<GetForSkillsSection>> TGetForSkillsSectionAsync();
        Task<ValidationResult> ValidatorForCreateSkillsOperationsAsync(CreateSkillsDto dto);
        Task<ValidationResult> ValidatorForUpdateSkillsOperationsAsync(UpdateSkillsDto dto);
    }
}
