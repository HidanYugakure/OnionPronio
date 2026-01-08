using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnionPronia.Application.DTOs;
using OnionPronia.Application.Interface.Repositories;
using OnionPronia.Application.Interfaces.Services;
using OnionPronia.Domain.Entities;

namespace OnionPronia.Persistence.Implementations.Services
{
    internal class ColorService : IColorService
    {
        private readonly IColorRepository _repository;
        private readonly IMapper _mapper;

        public ColorService(IColorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task CreateAsync(PostColorDto colorDto)
        {
            bool result = await _repository.AnyAsync(c => c.Name == colorDto.Name);
            if (result) { throw new Exception($"Color name: {colorDto.Name} already exists"); }
            Color color = _mapper.Map<Color>(colorDto);
            color.CreatedAt = DateTime.Now;
            _repository.Add(color);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            Color? existed = await _repository.GetByIdAsynch(id);
            if (existed is null) throw new Exception("Color not found");
            _repository.Delete(existed);
            await _repository.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<GetColorItemDto>> GetAllAsync(int page, int take)
        {
            var colors = await _repository.GetAll(
                sort: c => c.Id,
                isDesc: true,
                page: page,
                take: take,
                includes: nameof(Color.ProductColors)
                ).ToListAsync();
            return _mapper.Map<IReadOnlyList<GetColorItemDto>>(colors);
        }

        public async Task<GetColorDto> GetByIdAsync(long? id)
        {
            if (id is null) throw new Exception("Id is required");
            Color? color = await _repository.GetByIdAsynch(id.Value);
            if (color is null) throw new Exception("Color not found");
            return _mapper.Map<GetColorDto>(color);
        }

        public async Task UpdateAsync(long id, PutColorDto colorDto)
        {
            bool result = await _repository.AnyAsync(c => c.Name == colorDto.Name && c.Id != id);
            if (result)
            {
                throw new Exception($"Color name:{colorDto.Name} already exists");
            }
            Color? existed = await _repository.GetByIdAsynch(id);
            if (existed is null) throw new Exception("Color not found");
            existed = _mapper.Map(colorDto, existed);
            existed.UpdateAt = DateTime.Now;
            _repository.Update(existed);
            await _repository.SaveChangesAsync();
        }
    }
}
