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
            var categories = await _repository
                .GetAll(
               sort: c => c.Id,
               isDesc: true,
               page: page,
               take: take,
               includes: nameof(Category.Products)
               ).ToListAsync();
            /*Select(c => new GetCategoryItemDto(c.Id, c.Name, c.Products.Count)).*/
            return _mapper.Map<IReadOnlyList<GetCategoryItemDto>>(categories);
        }
        public async Task<GetCategoryDto> GetByIdAsync(int? id)
        {
            Category? category = await _repository.GetByIdAsynch(id.Value, nameof(Category.Products));
            if (category == null) throw new Exception("Notfound");
            return _mapper.Map<GetCategoryDto>(category);
        }
        public async Task CreateCategoryAsync(PostCategoryDto categoryDto)
        {
            //Category existed =_repository.GetAll(c=>c.Name == categoryDto.Name).FirstOrDefault();

            //bool result = await _repository.AnyAsync(c => c.Name == categoryDto.Name /*&& c.Id!=id*/);
            //if (result) throw new Exception("Category with the same name already exists");

            //Category category = _mapper.Map<Category>(categoryDto);
            //category.CreatedAt = DateTime.Now;
            //category.UpdateAt = DateTime.Now;  

            //Category category = new Category
            //{
            //    Name = categoryDto.Name,
            //    CreatedAt= DateTime.Now
            //};
            //_repository.Add(category);
            //await _repository.SaveChangesAsync();
            bool result = await _repository.AnyAsync(c => c.Name == categoryDto.Name);
            if (result)
            {
                throw new Exception($"Category name:{categoryDto.Name} already exists");
            }
            Category category = _mapper.Map<Category>(categoryDto);
            _repository.Add(category);
            await _repository.SaveChangesAsync();
        }
        public async Task UpdateAsync(long id, PutCategoryDto categoryDto)
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
        public async Task SoftDeleteAsync(long id)
        {
            Category? existed = await _repository.GetByIdAsynch(id);
            if (existed is null) throw new Exception("Category not found");
            existed.IsDeleted = true;
            _repository.Update(existed);
            await _repository.SaveChangesAsync();
        }
        public async Task DeleteAsync(long id)
        {
            Category? existed = await _repository.GetByIdAsynch(id);
            if (existed is null) throw new Exception("Category not found");
            _repository.Delete(existed);
            await _repository.SaveChangesAsync();
            //Category? existing = await _repository.GetByIdAsynch(id);
            //if (existing is null)
            //{
            //    throw new KeyNotFoundException("Category not found");
            //}
            //_repository.Delete(existing);
            //await _repository.SaveChangesAsync();
        }

        Task<GetCategoryItemDto> ICategoryService.GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }

}

