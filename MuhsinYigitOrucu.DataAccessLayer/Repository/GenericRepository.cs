using Microsoft.EntityFrameworkCore;
using MuhsinYigitOrucu.DataAccessLayer.Abstract;
using MuhsinYigitOrucu.DataAccessLayer.Context;

namespace MuhsinYigitOrucu.DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        protected readonly MYOrucuPortfolioContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(MYOrucuPortfolioContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task DeleteAsync(T t)
        {
            _dbSet.Remove(t);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
           return await _dbSet.FindAsync(id);
        }

        public async Task<List<T>> GetListAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task InsertAsync(T t)
        {
            await _dbSet.AddAsync(t);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T t)
        {
            _dbSet.Update(t);
            await _context.SaveChangesAsync();
        }
    }
}
