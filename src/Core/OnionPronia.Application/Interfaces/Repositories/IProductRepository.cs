using OnionPronia.Domain.Entities;
using OnionPronia.Repositories.Generic;
using System;

namespace OnionPronia.Application.Interface.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetByIdAsync(long id, string v1, string v2, string v3);
    }
}
