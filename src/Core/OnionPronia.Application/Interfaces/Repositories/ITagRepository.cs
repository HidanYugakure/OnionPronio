using OnionPronia.Domain.Entities;
using OnionPronia.Repositories.Generic;
using System;

namespace OnionPronia.Application.Interface.Repositories
{
    public interface ITagRepository : IRepository<Tag>
    {
        Task<Tag?> GetByIdAsync(long id);
    }
}
