using Microsoft.EntityFrameworkCore;
using MuhsinYigitOrucu.DataAccessLayer.Abstract;
using MuhsinYigitOrucu.DataAccessLayer.Context;
using MuhsinYigitOrucu.DataAccessLayer.Repository;
using MuhsinYigitOrucu.DtoLayer.UIDtos.AboutSectionDto;
using MuhsinYigitOrucu.DtoLayer.UIDtos.HeroSectionDto;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.DataAccessLayer.EntityFramework
{
    public class EfAboutDal : GenericRepository<About>, IAboutDal
    {
        public EfAboutDal(MYOrucuPortfolioContext context) : base(context)
        {
        }

        public async Task<GetForAboutSection> GetForAboutSectionAsync()
        {
            return await _context.Abouts.AsNoTracking()
                .Select(a => new GetForAboutSection
                {
                    BioParagraphs = a.BioParagraphs,
                    QuickInfo = a.QuickInfo
                }).FirstOrDefaultAsync();
        }

        public async Task<GetForHeroSection> GetForHeroSectionAsync()
        {
            return await _context.Abouts.AsNoTracking()
                .Select(a => new GetForHeroSection
                {
                    FullName = a.FullName,
                    ShortBio = a.ShortBio,
                    GithubUrl = a.GithubUrl,
                    LinkedinUrl = a.LinkedinUrl,
                    AvatarUrl = a.AvatarUrl,
                    Location = a.Location,
                    EmailAddress = a.EmailAddress,
                    PhoneNumber = a.PhoneNumber,
                    BrandInitials = a.BrandInitials,
                    TypewriterTitles = a.TypewriterTitles
                }).FirstOrDefaultAsync();
        }
    }
}
