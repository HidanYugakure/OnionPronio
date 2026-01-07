using OnionPronia.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Application.Interfaces.Services
{
    public interface ITagService
    {
        Task<IReadOnlyList<GetTagItemDto>> GetAllAsync(int page, int take);
        Task<GetTagDto> GetByIdAsync(long? id);
        Task CreateAsync(PostTagDto tagDto);
        Task UpdateAsync(long id, PutTagDto tagDto);
        Task DeleteAsync(long id);
    }
}
