using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnionPronia.Application.DTOS.Categories;
using OnionPronia.Application.Interface.Repositories;
using OnionPronia.Application.Interface.Services;
using OnionPronia.Domain.Entities;


namespace OnionPronia.Persistence.Implementations.Services
{
    internal class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<GetCategoryItemDto>> GetAllAsync(int page, int take)
        {
            var categories = await _repository.GetAll(
                sort: c => c.Name,
                page: page,
                take: take,
                includes: nameof(Category.Products)
                )./*Select(c => new GetCategoryItemDto(c.Id, c.Name, c.Products.Count)).*/ToListAsync();
            return  _mapper.Map<IReadOnlyList<GetCategoryItemDto>>(categories);
        }
        public async Task<GetCategoryDto> GetByIdAsync(int? id)
        {
            Category category = await _repository.GetByIdAsynch(id.Value, nameof(Category.Products));
            if (category == null)
            {
                throw new KeyNotFoundException("Category not found");
            }

            return _mapper.Map<GetCategoryDto>(category);
        }

        public async Task CreateCategoryAsync(PostCategoryDto categoryDto)
        {
            //Category existed =_repository.GetAll(c=>c.Name == categoryDto.Name).FirstOrDefault();

            bool result = await _repository.AnyAsync(c => c.Name == categoryDto.Name /*&& c.Id!=id*/);
            if (result) throw new Exception("Category with the same name already exists");
            
            Category category = _mapper.Map<Category>(categoryDto);
            category.CreatedAt = DateTime.Now;
            category.UpdateAt = DateTime.Now;  

            //Category category = new Category
            //{
            //    Name = categoryDto.Name,
            //    CreatedAt= DateTime.Now
            //};
            _repository.Add(category);
            await _repository.SaveChangesAsync();
        }


        public async Task UpdateAsync(int id, PutCategoryDto categoryDto)
        {
            bool result = await _repository.AnyAsync(c => c.Name == categoryDto.Name && c.Id != id);
            if (result) throw new Exception("Category with the same name already exists");

            Category? existing = await _repository.GetByIdAsynch(id);

            if (existing is null)
            {
                throw new KeyNotFoundException("Category not found");
            }
            existing = _mapper.Map(categoryDto, existing);
            existing.UpdateAt = DateTime.Now;
            _repository.Update(existing);
            await _repository.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id)
        {
            Category? existing = await _repository.GetByIdAsynch(id);
            if (existing is null)
            {
                throw new KeyNotFoundException("Category not found");
            }
            _repository.Delete(existing);
            await _repository.SaveChangesAsync();
        }

        Task<GetCategoryItemDto> ICategoryService.GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }

}

