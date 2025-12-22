using System;
using System.Linq.Expressions;

namespace OnionPronia.Repositories.Generic
{
    public interface IRepository<T> where T : class, new()
    {
         IQueryable<T> GetAll(
          Expression<Func<T, bool>>? func = null,
          Expression<Func<T, object>>? sort = null,
          bool isDesc = false,
          int page = 0,
          int Take = 0,
          params string[]? includes
          );
          void Add(T entity);

          Task<T?> GetByIdAsynch(int? id, params string[] includes);
          void Update(T entity);
          void Delete(T entity);
          Task SaveChangesAsync();
    }
}
