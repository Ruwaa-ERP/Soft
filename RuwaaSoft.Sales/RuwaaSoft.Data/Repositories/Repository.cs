using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RuwaaSoft.Data.Context;

namespace RuwaaSoft.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly SalesDbContext Context;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(SalesDbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).ToList();
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.SingleOrDefault(predicate);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.SingleOrDefaultAsync(predicate);
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            DbSet.AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                DbSet.Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;
            }
        }

        public void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            DbSet.RemoveRange(entities);
        }

        public int Count()
        {
            return DbSet.Count();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Count(predicate);
        }

        public async Task<int> CountAsync()
        {
            return await DbSet.CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.CountAsync(predicate);
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Any(predicate);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AnyAsync(predicate);
        }

        public IQueryable<TEntity> Query()
        {
            return DbSet.AsQueryable();
        }
    }
}
