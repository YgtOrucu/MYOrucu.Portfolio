using Microsoft.EntityFrameworkCore;
using MuhsinYigitOrucu.DataAccessLayer.Abstract;
using MuhsinYigitOrucu.DataAccessLayer.Context;
using MuhsinYigitOrucu.DataAccessLayer.Repository;
using MuhsinYigitOrucu.DtoLayer.Dtos.ProjectDetailsDto;
using MuhsinYigitOrucu.DtoLayer.UIDtos.ProjectDetailsSectionDto;
using MuhsinYigitOrucu.EntityLayer.Entities;

namespace MuhsinYigitOrucu.DataAccessLayer.EntityFramework
{
    public class EfProjectDetailsDal : GenericRepository<ProjectDetail>, IProjectDetailsDal
    {
        public EfProjectDetailsDal(MYOrucuPortfolioContext context) : base(context)
        {
        }

        public async Task<bool> AnyProjectDetailByProjectIdAsync(int id)
        {
            return await _context.ProjectDetail.AnyAsync(x => x.ProjectId == id);
        }

        public async Task<GetForProjectDetailDto> GetForProjectDetailsSectionAsync(int Id)
        {
            return await _context.ProjectDetail.Where(x => x.ProjectId == Id).Select(x => new GetForProjectDetailDto
            {
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                FullDescription = x.FullDescription,
                CoverImageUrl = x.CoverImageUrl,
                GalleryImages = x.GalleryImages,
                Category = x.Category,
                Status = x.Status,
                Year = x.Year,
                Duration = x.Duration,
                Role = x.Role,
                TeamSize = x.TeamSize,
                GithubLink = x.GithubLink,
                LiveDemoUrl = x.LiveDemoUrl,
                UseTechnology = x.UseTechnology,
                Features = x.Features,
                Challenges = x.Challenges
            }).FirstOrDefaultAsync();
        }

        public async Task<List<GetProjectNameWithAdminDetails>> GetProjectNameWithDetailsPage()
        {
            var projectList = await _context.Projects.AsNoTracking().ToListAsync();

            return projectList.Select(x => new GetProjectNameWithAdminDetails
            {
                ProjectId = x.ProjectId,
                Title = x.Title
            }).ToList();
        }
    }
}
