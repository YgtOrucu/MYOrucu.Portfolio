using MuhsinYigitOrucu.DtoLayer.UIDtos.SkillsSectionDto;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.DataAccessLayer.Abstract
{
    public interface ISkillsDal:IGenericDal<Skills>
    {
        Task<List<GetForSkillsSection>> GetForSkillsSectionAsync();
    }
}
