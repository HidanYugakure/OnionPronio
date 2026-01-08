using OnionPronia.Application.DTOs;

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
