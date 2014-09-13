namespace Atm.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected IDbSet<TEntity> DbSet;

        public GenericRepository(DbContext dbContext)
        {
            this.DbSet = dbContext.Set<TEntity>();
        }

        public void Insert(TEntity entity)
        {
            this.DbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            this.DbSet.Remove(entity);
        }

        public IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return this.DbSet.Where(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return this.DbSet;
        }

        public TEntity GetById(int id)
        {
            return this.DbSet.Find(id);
        }
    }
}