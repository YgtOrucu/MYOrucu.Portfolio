using MuhsinYigitOrucu.DtoLayer.UIDtos.AboutSectionDto;
using MuhsinYigitOrucu.DtoLayer.UIDtos.HeroSectionDto;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.DataAccessLayer.Abstract
{
    public interface IAboutDal : IGenericDal<About>
    {
        Task<GetForHeroSection> GetForHeroSectionAsync();
        Task<GetForAboutSection> GetForAboutSectionAsync();
    }
}
