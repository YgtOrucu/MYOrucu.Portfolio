using Microsoft.EntityFrameworkCore;
using MuhsinYigitOrucu.DataAccessLayer.Abstract;
using MuhsinYigitOrucu.DataAccessLayer.Context;
using MuhsinYigitOrucu.DataAccessLayer.Repository;
using MuhsinYigitOrucu.DtoLayer.UIDtos.ExperienceSectionDto;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.DataAccessLayer.EntityFramework
{
    public class EfExperienceDal : GenericRepository<Experience>, IExperienceDal
    {
        public EfExperienceDal(MYOrucuPortfolioContext context) : base(context)
        {
        }

        public async Task<List<GetForExperienceSectionDto>> GetForExperienceSectionAsync()
        {
            return await _context.Experience.AsNoTracking().Select(e => new GetForExperienceSectionDto
            {
                Company = e.Company,
                Title = e.Title,
                Date = e.Date,
                WorkMethod = e.WorkMethod,
                Description = e.Description,
                UseTechnology = e.UseTechnology
            }).ToListAsync();
        }
    }
}
