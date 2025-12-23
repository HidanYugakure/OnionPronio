using Microsoft.EntityFrameworkCore;
using OnionPronia.Application.DTOS;
using OnionPronia.Application.Interface.Repositories;
using OnionPronia.Application.Interface.Services;
using OnionPronia.Domain.Entities;


namespace OnionPronia.Persistence.Implementations.Services
{
    internal class CategoryService:ICategoryServices
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;

        }

        public async Task<IReadOnlyList<GetCategoryItemDto>> GetAllAsync(int page, int take)
        {
            return await _repository.GetAll(
                sort: c => c.Name,
                page: page,
                Take: take
                ).Select(c => new GetCategoryItemDto(c.Id, c.Name, c.Products.Count)).ToListAsync();
        }
        public async Task<GetCategoryItemDto> GetByIdAsync(int? id)
        {
            Category categories = await _repository.GetByIdAsynch(id.Value, nameof(Category.Products));
            if (categories == null)
            {
                throw new KeyNotFoundException("Category not found");
            }

            return new GetCategoryItemDto(
                categories.Id,
                categories.Name,
                categories.Products?.Count ?? 0
            );
        }

        public async Task CreateCategoryAsync(PostCategoryDto categoryDto)
        {
            Category category = new Category
            {
                Name = categoryDto.Name
            };
            _repository.Add(category);
            await _repository.SaveChangesAsync();
        }


        public async Task UpdateAsync(int id, PutCategoryDto categoryDto)
        {
            Category? existing = await _repository.GetByIdAsynch(id);


            if (existing is null)
            {
                throw new KeyNotFoundException("Category not found");
            }
            existing.Name = categoryDto.Name;
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
    }

}

