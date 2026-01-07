using OnionPronia.Application.Interface.Repositories;
using OnionPronia.Domain.Entities;
using OnionPronia.Persistence.Contexts;
using OnionPronia.Persistence.Implementations.Repositories.Generic;



namespace OnionPronia.Persistence.Implementations.Repositories
{
    internal class ColorRepository : Repository<Color>, IColorRepository
    {
        public ColorRepository(AppDbContext context) : base(context)
        {
        }
    }
}