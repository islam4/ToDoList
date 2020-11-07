using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using ToDoList.Web.Interfaces;
using ToDoList.Web.Models.Context;

namespace ToDoList.Web.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<TEntity> _db;

        public Repository()
        {

        }
        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _db = dbContext.Set<TEntity>();
        }
        public virtual async Task<int> Add(TEntity entity)
        {
            if (entity != null)
            {
                _db.Add(entity);
                return await Save();
            }

            return -1;
        }

        public virtual async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await _db.Where(predicate).ToListAsync(); ;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _db.ToListAsync();
        }

        public virtual async Task<TEntity> GetById(object id)
        {
            return await _db.FindAsync(id);
        }

        public virtual IEnumerable<TEntity> Get(
                       Expression<Func<TEntity, bool>> filter = null,
                       Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                       string includeProperties = "")
        {
            IQueryable<TEntity> query = _db;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual async Task<int> Remove(TEntity entityToDelete)
        {
            if (entityToDelete != null && _dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _db.Attach(entityToDelete);
                _db.Remove(entityToDelete);

                return await Save();
            }

            return -1;
        }

        public virtual async Task<int> Update(TEntity entityToUpdate)
        {
            if (entityToUpdate != null)
            {
                _db.Attach(entityToUpdate);
                _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
                return await Save();
            }

            return -1;
        }

        private async Task<int> Save()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}