using MuhsinYigitOrucu.DtoLayer.UIDtos.ExperienceSectionDto;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.DataAccessLayer.Abstract
{
    public interface IExperienceDal : IGenericDal<Experience>
    {
        Task<List<GetForExperienceSectionDto>> GetForExperienceSectionAsync();
    }
}
