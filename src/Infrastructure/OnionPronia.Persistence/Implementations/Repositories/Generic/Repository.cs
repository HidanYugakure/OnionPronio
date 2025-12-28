using Microsoft.EntityFrameworkCore;
using OnionPronia.Domain.Entities.Common;
using OnionPronia.Persistence.Contexts;
using OnionPronia.Repositories.Generic;
using System;
using System.Linq.Expressions;
using System.Text;

namespace OnionPronia.Persistence.Implementations.Repositories.Generic
{
    internal class Repository<T> : IRepository<T> where T : BaseEntity, new()

    {
        protected readonly DbSet<T> _dbSet;
        protected readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {

            _context = context;
            _dbSet = _context.Set<T>();
        }


        public IQueryable<T> GetAll(
            Expression<Func<T, bool>>? func = null,
            Expression<Func<T, object>>? sort = null,
            bool isDesc = false,
            int page = 0,
            int Take = 0,
            params string[]? includes
            )
        {
            IQueryable<T> query = _dbSet;

            if (query is null)
            {
                query = query.Where(func);
            }

            if (sort is not null)
            {
                if (isDesc)
                {
                    query = query.OrderByDescending(sort);
                }
                else
                {
                    query = query.OrderBy(sort);
                }
            }
            if (page > 0 && Take > 0)
            {
                int skip = (page - 1) * Take;
                query = query.Skip(skip).Take(Take);
            }

            if (includes is not null)
            {
                query = _getIncludes(query, includes);
            }

            return query;
        }

        public async Task<T?> GetByIdAsynch(int? id, params string[] includes)
        {
            IQueryable<T> query = _dbSet.AsNoTracking();

            if (includes is not null)
            {
                query = _getIncludes(query, includes);
            }
            return await query.FirstOrDefaultAsync(c => c.Id == id);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        private IQueryable<T> _getIncludes(IQueryable<T> query, params string[] inclludes)
        {
            for (int i = 0; i < inclludes.Length; i++)
            {
                query = query.Include(inclludes[i]);
            }

            return query;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> func)
        {
            return await _dbSet.AnyAsync(func);
        }
    }
}
