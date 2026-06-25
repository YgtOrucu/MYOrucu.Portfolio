using FluentValidation.Results;
using MuhsinYigitOrucu.DtoLayer.Dtos.ProjectDtos;
using MuhsinYigitOrucu.DtoLayer.UIDtos.ProjectSectionDto;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.BusinessLayer.Abstract
{
    public interface IProjectService :IGenericService<Project>
    {
        Task<ValidationResult> ValidatorForCreateProjectOperationsAsync(CreateProjectDto createProjectDto);
        Task<ValidationResult> ValidatorForUpdateProjectOperationsAsync(UpdateProjectDto updateProjectDto);
        Task<List<GetForProjectSection>> TGetForProjectSectionAsync();
    }
}
