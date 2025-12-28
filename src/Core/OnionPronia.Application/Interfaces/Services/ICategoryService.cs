using OnionPronia.Application.DTOS.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Application.Interface.Services
{
    public interface ICategoryService
    {
        Task<IReadOnlyList<GetCategoryItemDto>> GetAllAsync(int page, int take);
        Task<GetCategoryItemDto> GetByIdAsync(int? id);
        Task CreateCategoryAsync(PostCategoryDto categoryDto);
        Task UpdateAsync(int id, PutCategoryDto categoryDto);
        Task DeleteAsync(int id);
    }
}
