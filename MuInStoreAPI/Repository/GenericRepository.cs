using Microsoft.EntityFrameworkCore;
using MuInStoreAPI.Data;
using MuInStoreAPI.Repository.IRepository;
using System.Linq.Expressions;

namespace MuInStoreAPI.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public virtual async Task Create(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public virtual async Task<T?> Delete(int id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity == null)
            {
                return null;
            }
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
            return entity;
        }

        public virtual bool DeleteRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
            return true;
        }

        public virtual async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                query = orderBy(query);
                return await query.ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public virtual async Task<T?> GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return dbSet.Find(id);
        }

        public virtual async Task<T?> Update(int id, T entity)
        {
            var entityObject = await dbSet.FindAsync(id);
            if (entityObject != null)
            {
                dbSet.Attach(entity);
                _db.Entry(entity).State = EntityState.Modified;
                return entity;
            }
            else
            {
                return null;
            }
        }
    }
}
