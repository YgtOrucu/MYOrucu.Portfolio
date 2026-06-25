using FluentValidation;
using FluentValidation.Results;
using MuhsinYigitOrucu.BusinessLayer.Abstract;
using MuhsinYigitOrucu.DataAccessLayer.Abstract;
using MuhsinYigitOrucu.DtoLayer.Dtos.ProjectDtos;
using MuhsinYigitOrucu.DtoLayer.UIDtos.ProjectSectionDto;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.BusinessLayer.Concrete
{
    public class ProjectManager : IProjectService
    {
        private readonly IProjectDal _ProjectDal;
        private readonly IValidator<CreateProjectDto> _ProjectCreateValidator;
        private readonly IValidator<UpdateProjectDto> _ProjectUpdateValidator;

        public ProjectManager(IProjectDal ProjectDal, IValidator<CreateProjectDto> ProjectCreateValidator, IValidator<UpdateProjectDto> ProjectUpdateValidator)
        {
            _ProjectDal = ProjectDal;
            _ProjectCreateValidator = ProjectCreateValidator;
            _ProjectUpdateValidator = ProjectUpdateValidator;
        }

        public async Task TDeleteAsync(Project t) => await _ProjectDal.DeleteAsync(t);
        public async Task<Project> TGetByIdAsync(int id) => await _ProjectDal.GetByIdAsync(id);
        public async Task<List<Project>> TGetListAsync() => await _ProjectDal.GetListAsync();
        public async Task TUpdateAsync(Project t) => await _ProjectDal.UpdateAsync(t);
        public async Task TInsertAsync(Project t) => await _ProjectDal.InsertAsync(t);
        public async Task<List<GetForProjectSection>> TGetForProjectSectionAsync()=> await _ProjectDal.GetForProjectSectionAsync();
        public async Task<ValidationResult> ValidatorForCreateProjectOperationsAsync(CreateProjectDto CreateProjectDto)
        {
            return await _ProjectCreateValidator.ValidateAsync(CreateProjectDto);
        }
        public async Task<ValidationResult> ValidatorForUpdateProjectOperationsAsync(UpdateProjectDto UpdateProjectDto)
        {
            return await _ProjectUpdateValidator.ValidateAsync(UpdateProjectDto);
        }
    }
}
