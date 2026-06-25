using MuhsinYigitOrucu.DtoLayer.UIDtos.ProjectSectionDto;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.DataAccessLayer.Abstract
{
    public interface IProjectDal : IGenericDal<Project>
    {
        Task <List<GetForProjectSection>> GetForProjectSectionAsync();
    }
}
