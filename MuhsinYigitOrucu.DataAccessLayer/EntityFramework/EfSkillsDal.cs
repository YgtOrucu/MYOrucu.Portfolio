using Microsoft.EntityFrameworkCore;
using MuhsinYigitOrucu.DataAccessLayer.Abstract;
using MuhsinYigitOrucu.DataAccessLayer.Context;
using MuhsinYigitOrucu.DataAccessLayer.Repository;
using MuhsinYigitOrucu.DtoLayer.UIDtos.SkillsSectionDto;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.DataAccessLayer.EntityFramework
{
    public class EfSkillsDal : GenericRepository<Skills>, ISkillsDal
    {
        public EfSkillsDal(MYOrucuPortfolioContext context) : base(context)
        {
        }

        public async Task<List<GetForSkillsSection>> GetForSkillsSectionAsync()
        {
            return await _context.Skills.AsNoTracking().Select(x => new GetForSkillsSection
            {
                CategoryName = x.CategoryName,
                SkillItem = x.SkillItem,
            }).ToListAsync();
        }
    }
}
