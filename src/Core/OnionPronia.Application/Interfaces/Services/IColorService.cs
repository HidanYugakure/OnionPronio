using OnionPronia.Application.DTOs;
using OnionPronia.Application.DTOS.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Application.Interfaces.Services
{
    public interface IColorService
    {
        Task<IReadOnlyList<GetColorItemDto>> GetAllAsync(int page, int take);
        Task<GetColorDto> GetByIdAsync(long? id);
        Task CreateAsync(PostColorDto colorDto);
        Task UpdateAsync(long id, PutColorDto colorDto);
        Task DeleteAsync(long id);
    }
}
