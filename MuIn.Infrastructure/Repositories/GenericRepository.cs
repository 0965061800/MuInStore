using Microsoft.EntityFrameworkCore;
using MuIn.Domain.SeedWork.InterfaceRepo;

namespace MuIn.Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly MuInDbContext _context;
        internal DbSet<T> dbSet;
        public GenericRepository(MuInDbContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
        }
        public virtual async Task<T?> GetByIdAsync(int id)
        {
            T? entity = await dbSet.FindAsync(id);
            if (entity == null) return null;
            return entity;
        }
        public virtual async Task<T?> CreateAsync(T entity)
        {
            var entityEntry = await dbSet.AddAsync(entity);
            if (entityEntry.Entity != null)
            {
                return entityEntry.Entity;
            }
            return null;
        }

        public virtual async Task<T?> UpdateAsync(T entity)
        {
            var newEntity = dbSet.Update(entity);
            return newEntity.Entity;
        }

        public virtual async Task<T?> Delete(int id)
        {
            T? entity = await dbSet.FindAsync(id);
            var deletedEntity = dbSet.Remove(entity);
            return deletedEntity.Entity;
        }
        public async Task SaveChange()
        {
            await _context.SaveChangesAsync();
        }
    }
}
