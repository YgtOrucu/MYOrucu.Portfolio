using MuhsinYigitOrucu.DtoLayer.Dtos.ProjectDetailsDto;
using MuhsinYigitOrucu.DtoLayer.UIDtos.ProjectDetailsSectionDto;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.DataAccessLayer.Abstract
{
    public interface IProjectDetailsDal : IGenericDal<ProjectDetail>
    {
        Task<GetForProjectDetailDto> GetForProjectDetailsSectionAsync(int Id);
        Task<List<GetProjectNameWithAdminDetails>> GetProjectNameWithDetailsPage();
        Task<bool> AnyProjectDetailByProjectIdAsync(int id);
    }
}
