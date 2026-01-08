using OnionPronia.Application.DTOS.Products;

namespace OnionPronia.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<IReadOnlyList<GetProductItemDto>> GetAllAsync(int page, int take);
        Task<GetProductDto> GetByIdAsync(long id);
        Task CreateProductAsync(PostProductDto productDto);
        Task UpdateProductAsync(long id, PutProductDto productDto);
    }
}
