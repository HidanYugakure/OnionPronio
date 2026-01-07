using OnionPronia.Application.DTOS.Products;

namespace OnionPronia.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<IReadOnlyList<GetProductItemDto>> GetAllAsync(int page, int take);
        Task<object?> GetAllAsynch(int page, int pageSize);
    }
}
