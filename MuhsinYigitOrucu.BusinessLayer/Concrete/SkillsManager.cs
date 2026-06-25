using FluentValidation;
using FluentValidation.Results;
using MuhsinYigitOrucu.BusinessLayer.Abstract;
using MuhsinYigitOrucu.DataAccessLayer.Abstract;
using MuhsinYigitOrucu.DtoLayer.Dtos.SkillsDto;
using MuhsinYigitOrucu.DtoLayer.UIDtos.SkillsSectionDto;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.BusinessLayer.Concrete
{
    public class SkillsManager : ISkillsService
    {
        private readonly ISkillsDal _SkillsDal;
        private readonly IValidator<CreateSkillsDto> _SkillsCreateValidator;
        private readonly IValidator<UpdateSkillsDto> _SkillsUpdateValidator;

        public SkillsManager(ISkillsDal SkillsDal, IValidator<CreateSkillsDto> SkillsCreateValidator, IValidator<UpdateSkillsDto> SkillsUpdateValidator)
        {
            _SkillsDal = SkillsDal;
            _SkillsCreateValidator = SkillsCreateValidator;
            _SkillsUpdateValidator = SkillsUpdateValidator;
        }

        public async Task TDeleteAsync(Skills t) => await _SkillsDal.DeleteAsync(t);
        public async Task<Skills> TGetByIdAsync(int id) => await _SkillsDal.GetByIdAsync(id);
        public async Task<List<Skills>> TGetListAsync() => await _SkillsDal.GetListAsync();
        public async Task TUpdateAsync(Skills t) => await _SkillsDal.UpdateAsync(t);
        public async Task TInsertAsync(Skills t) => await _SkillsDal.InsertAsync(t);
        public async Task<List<GetForSkillsSection>> TGetForSkillsSectionAsync() => await _SkillsDal.GetForSkillsSectionAsync();

        public async Task<ValidationResult> ValidatorForCreateSkillsOperationsAsync(CreateSkillsDto SkillsCreateDto)
        {
            return await _SkillsCreateValidator.ValidateAsync(SkillsCreateDto);
        }

        public async Task<ValidationResult> ValidatorForUpdateSkillsOperationsAsync(UpdateSkillsDto SkillsUpdateDto)
        {
            return await _SkillsUpdateValidator.ValidateAsync(SkillsUpdateDto);
        }
    }
}
