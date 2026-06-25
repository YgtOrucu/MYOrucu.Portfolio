using FluentValidation;
using FluentValidation.Results;
using MuhsinYigitOrucu.BusinessLayer.Abstract;
using MuhsinYigitOrucu.DataAccessLayer.Abstract;
using MuhsinYigitOrucu.DtoLayer.Dtos.ProjectDetailsDto;
using MuhsinYigitOrucu.DtoLayer.UIDtos.ProjectDetailsSectionDto;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.BusinessLayer.Concrete
{
    public class ProjectDetailsManager : IProjectDetailsService
    {
        private readonly IProjectDetailsDal _ProjectDetailsDal;
        private readonly IValidator<CreateProjectDetailsDto> _ProjectDetailsCreateValidator;
        private readonly IValidator<UpdateProjectDetailsDto> _ProjectDetailsUpdateValidator;

        public ProjectDetailsManager(IProjectDetailsDal ProjectDetailsDal, IValidator<CreateProjectDetailsDto> ProjectDetailsCreateValidator, IValidator<UpdateProjectDetailsDto> ProjectDetailsUpdateValidator)
        {
            _ProjectDetailsDal = ProjectDetailsDal;
            _ProjectDetailsCreateValidator = ProjectDetailsCreateValidator;
            _ProjectDetailsUpdateValidator = ProjectDetailsUpdateValidator;
        }

        public async Task TDeleteAsync(ProjectDetail t) => await _ProjectDetailsDal.DeleteAsync(t);
        public async Task<ProjectDetail> TGetByIdAsync(int id) => await _ProjectDetailsDal.GetByIdAsync(id);
        public async Task<List<ProjectDetail>> TGetListAsync() => await _ProjectDetailsDal.GetListAsync();
        public async Task TUpdateAsync(ProjectDetail t) => await _ProjectDetailsDal.UpdateAsync(t);
        public async Task TInsertAsync(ProjectDetail t) => await _ProjectDetailsDal.InsertAsync(t);
        public async Task<GetForProjectDetailDto> TGetForProjectDetailsSectionAsync(int Id) => await _ProjectDetailsDal.GetForProjectDetailsSectionAsync(Id);
        public async Task<List<GetProjectNameWithAdminDetails>> TGetProjectNameWithDetailsPage() => await _ProjectDetailsDal.GetProjectNameWithDetailsPage();
        public async Task<bool> TAnyProjectDetailByProjectIdAsync(int id) => await _ProjectDetailsDal.AnyProjectDetailByProjectIdAsync(id);

        public async Task<ValidationResult> ValidatorForCreateProjectDetailOperationsAsync(CreateProjectDetailsDto createProjectDto)
        {
            return await _ProjectDetailsCreateValidator.ValidateAsync(createProjectDto);
        }

        public async Task<ValidationResult> ValidatorForUpdateProjectDetailOperationsAsync(UpdateProjectDetailsDto updateProjectDto)
        {
            return await _ProjectDetailsUpdateValidator.ValidateAsync(updateProjectDto);
        }
    }
}
