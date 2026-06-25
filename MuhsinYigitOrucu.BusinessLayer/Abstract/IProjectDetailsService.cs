using FluentValidation.Results;
using MuhsinYigitOrucu.DtoLayer.Dtos.ProjectDetailsDto;
using MuhsinYigitOrucu.DtoLayer.UIDtos.ProjectDetailsSectionDto;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.BusinessLayer.Abstract
{
    public interface IProjectDetailsService : IGenericService<ProjectDetail>
    {
        Task<ValidationResult> ValidatorForCreateProjectDetailOperationsAsync(CreateProjectDetailsDto createProjectDto);
        Task<ValidationResult> ValidatorForUpdateProjectDetailOperationsAsync(UpdateProjectDetailsDto updateProjectDto);
        Task<GetForProjectDetailDto> TGetForProjectDetailsSectionAsync(int Id);
        Task<List<GetProjectNameWithAdminDetails>> TGetProjectNameWithDetailsPage();
        Task<bool> TAnyProjectDetailByProjectIdAsync(int id);
    }
}
