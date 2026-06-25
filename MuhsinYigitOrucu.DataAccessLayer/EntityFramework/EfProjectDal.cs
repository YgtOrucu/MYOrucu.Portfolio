using Microsoft.EntityFrameworkCore;
using MuhsinYigitOrucu.DataAccessLayer.Abstract;
using MuhsinYigitOrucu.DataAccessLayer.Context;
using MuhsinYigitOrucu.DataAccessLayer.Repository;
using MuhsinYigitOrucu.DtoLayer.UIDtos.ProjectSectionDto;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.DataAccessLayer.EntityFramework
{
    public class EfProjectDal : GenericRepository<Project>, IProjectDal
    {
        public EfProjectDal(MYOrucuPortfolioContext context) : base(context)
        {
        }

        public async Task<List<GetForProjectSection>> GetForProjectSectionAsync()
        {
            return await _context.Projects.AsNoTracking().Select(x=> new GetForProjectSection()
            {
                ProjectId = x.ProjectId,
                Title = x.Title,
                MiniDescription = x.MiniDescription,
                ImageUrl = x.ImageUrl,
                GithubLink = x.GithubLink,
                UseTechnology = x.UseTechnology,
                ShowOnHomePage = x.ShowOnHomePage
            }).ToListAsync();
        }
    }
}
