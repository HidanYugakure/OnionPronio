using OnionPronia.Application.Interface.Repositories;
using OnionPronia.Domain.Entities;
using OnionPronia.Persistence.Contexts;
using OnionPronia.Persistence.Implementations.Repositories.Generic;


namespace OnionPronia.Persistence.Implementations.Repositories
{
    internal class ProductRepository: Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }
    }
}
