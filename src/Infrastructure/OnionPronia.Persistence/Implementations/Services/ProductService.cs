using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnionPronia.Application.DTOS;
using OnionPronia.Application.DTOS.Products;
using OnionPronia.Application.Interface.Repositories;
using OnionPronia.Application.Interfaces.Services;
using OnionPronia.Domain.Entities;

namespace OnionPronia.Persistence.Implementations.Services
{
    internal class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, ICategoryRepository categoryRepository, ITagRepository tagRepository, IMapper mapper)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task CreateProductAsync(PostProductDto productDto)
        {
            bool result = await _repository.AnyAsync(p => p.Name == productDto.Name);
            if (result)
            {
                throw new Exception("Entity already exists");
            }
            bool categoryResult = await _categoryRepository.AnyAsync(c => c.Id == productDto.CategoryId);
            if (!categoryResult)
            {
                throw new Exception("Category does not exist");
            }
            var tags = await _tagRepository.GetAll(t => productDto.TagIds.Contains(t.Id)).ToListAsync();
            if (tags.Count != productDto.TagIds.Count())
            {
                throw new Exception("Tag does not exist");
            }
            Product product = _mapper.Map<Product>(productDto);
            _repository.Add(product);
            await _repository.SaveChangesAsync(); //videodan kocurdum biraz
        }

        public async Task<IReadOnlyList<GetProductItemDto>> GetAllAsync(int page, int take)
        {

            IReadOnlyList<Product> products = await _repository.GetAll(
                page: page,
                take: take,
                includes: nameof(Product.Category)
                ).ToListAsync();
            return _mapper.Map<IReadOnlyList<GetProductItemDto>>(products);
        }

        public async Task<GetProductDto> GetByIdAsync(int id)
        {
          Product product = await _repository.GetByIdAsynch(id,
              $"{nameof(Product.ProductTags)}.{nameof(ProductTag.Tag)}",
              $"{nameof(Product.ProductColors)}.{nameof(ProductColor.Color)}",
              nameof(Product.Category));
              return _mapper.Map<GetProductDto>(product);
        }

        public Task<GetProductDto> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateProductAsync(long id, PutProductDto productDto)
        {
            bool result = await _repository.AnyAsync(p => p.Name == productDto.Name && p.Id != id);
            if (result)
            {
                throw new Exception("Entity already exists");
            }
            bool categoryResult = await _categoryRepository.AnyAsync(c => c.Id == productDto.CategoryId);
            if (!categoryResult)
            {
                throw new Exception("Category not found");
            }
            var tags = await _tagRepository.GetAll(tag => !productDto.TagIds.Distinct().Contains(tag.Id)).ToListAsync();
            if (tags.Count != productDto.TagIds.Count)
                throw new Exception("Tag not found");
            Product product = await _repository.GetByIdAsynch(id, "ProductTags");
            _repository.Update(_mapper.Map(productDto, product));
            await _repository.SaveChangesAsync();
        }
    }
}
    