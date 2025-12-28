using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnionPronia.Application.DTOS;
using OnionPronia.Application.DTOS.Products;
using OnionPronia.Application.Interface.Repositories;
using OnionPronia.Application.Interfaces.Services;
using OnionPronia.Domain.Entities;

namespace OnionPronia.Persistence.Implementations.Services
{
    internal class ProductService:IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository repository, 
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<GetProductItemDto>> GetAllAsynch(int page, int take)
        {
            IReadOnlyList<Product> products = await _repository.GetAll(
                page: page,
                take: take,
                includes: nameof(Product.Category)
                ).ToListAsync();

            return _mapper.Map<IReadOnlyList<GetProductItemDto>>(products);
        }

        public async Task<GetProductDto> GetByIdAsynch(long id)
        {
            Product product = await _repository.GetByIdAsynch(id,"Product.ProductTags.Tag", nameof(Product.Name));
            if (product is null) throw new Exception("Entity not found");
            return _mapper.Map<GetProductDto>(product); 
        }
    }
}
    