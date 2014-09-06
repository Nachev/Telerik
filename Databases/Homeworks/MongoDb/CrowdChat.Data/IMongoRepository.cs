namespace CrowdChat.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IMongoRepository<T> where T : IEntity
    {
        bool Insert(T entity);

        bool Update(T entity);

        bool Delete(T entity);

        IList<T> Find(Expression<Func<T, bool>> predicate);

        IList<T> GetAll();

        T GetById(Guid id);
    }
}
