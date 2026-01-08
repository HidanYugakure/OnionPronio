using OnionPronia.Application.DTOS.Products;

namespace OnionPronia.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<IReadOnlyList<GetProductItemDto>> GetAllAsync(int page, int take);
        Task<GetProductDto> GetByIdAsync(int id);
        Task CreateProductAsync(PostProductDto productDto);
    }
}
