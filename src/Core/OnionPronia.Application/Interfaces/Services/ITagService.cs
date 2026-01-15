using OnionPronia.Application.DTOs;
using OnionPronia.Application.DTOs.AppUsers;
using OnionPronia.Application.DTOS;


namespace OnionPronia.Application.Interfaces.Services
{
    public interface ITagService
    {
        Task<IReadOnlyList<GetTagItemDto>> GetAllAsync(int page, int take);
        //Task<LoginDto> GetByIdAsync(long? id);
        Task CreateAsync(PostTagDto tagDto);
        Task UpdateAsync(long id, PutTagDto tagDto);
        Task DeleteAsync(long id);
        Task<object?> GetByIdAsync(long? id);
    }
}
