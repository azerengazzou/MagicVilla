using MagicVilla_Api.Data;
using MagicVilla_Api.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MagicVilla_Api.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        internal DbSet<T> DbSet;
        private readonly ApplicationDbContext _db;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.DbSet = _db.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await DbSet.AddAsync(entity);
            await Save();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true)
        {
            IQueryable<T> query = DbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = DbSet;
            if (filter != null)
            {
                query = query.Where(filter);

            }
            return await query.ToListAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            DbSet.Remove(entity);
            await Save();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
