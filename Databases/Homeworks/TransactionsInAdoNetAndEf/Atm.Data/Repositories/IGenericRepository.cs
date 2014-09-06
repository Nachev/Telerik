namespace Atm.Data.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    interface IGenericRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);

        void Delete(TEntity entity);

        IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> GetAll();

        TEntity GetById(int id);
    }
}