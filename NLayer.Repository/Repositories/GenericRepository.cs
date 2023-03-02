using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repositories;
using System.Linq.Expressions;

namespace NLayer.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        // readonly olduğu zaman sadece constructer'da ya da oluşturulduğu esnada değer atayabilirsiniz.
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            
            await _dbSet.AddAsync(entity);

        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public IQueryable<T> GetAll()
        {
            // AsNoTracking() => EF Core çekmiş olduğu dataları memory'e çekmemesi buna bağlı olarak daha performanslı çalışması için kullanılır.
             return _dbSet.AsNoTracking().AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(T entity)
        {
           // _context.Entry(entity).State = EntityState.Deleted; aynı şeydir! Property'sini set ettiğimiz bir methodun async olmasına gerek yok.
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
           _dbSet.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
