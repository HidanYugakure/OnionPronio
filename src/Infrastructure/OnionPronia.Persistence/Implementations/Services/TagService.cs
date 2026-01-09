using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnionPronia.Application.DTOs;
using OnionPronia.Application.DTOs.AppUsers;
using OnionPronia.Application.Interface.Repositories;
using OnionPronia.Application.Interfaces.Services;
using OnionPronia.Domain.Entities;

namespace OnionPronia.Persistence.Implementations.Services
{
    internal class TagService : ITagService
    {
        private readonly ITagRepository _repository;
        private readonly IMapper _mapper;

        public TagService(ITagRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(PostTagDto tagDto)
        {
            bool result = await _repository.AnyAsync(t => t.Name == tagDto.Name);
            if (result)
            {
                throw new Exception($"Tag name:{tagDto.Name} EXISTS");
                Tag tag = _mapper.Map<Tag>(tagDto);
                tag.CreatedAt = DateTime.Now;
                _repository.Add(tag);
                await _repository.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(long id)
        {
            Tag? existed = await _repository.GetByIdAsynch(id);
            if (existed is null) throw new Exception("Tag not found");
            _repository.Delete(existed);
            await _repository.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<GetTagItemDto>> GetAllAsync(int page, int take)
        {
            var tags = await _repository.GetAll(
                sort: t => t.Id,
                isDesc: true,
                page: page,
                take: take,
                includes: nameof(Tag.ProductTags)
                ).ToListAsync();
            return _mapper.Map<IReadOnlyList<GetTagItemDto>>(tags);
        }

        public async Task<PutTagDto> GetByIdAsync(long? id)
        {
            if (id is null) throw new Exception("Id is required");
            Tag? tag = await _repository.GetByIdAsynch(id.Value);
            if (tag is null) throw new Exception("Tag not found");
            return _mapper.Map<PutTagDto>(tag);
        }
        public async Task UpdateAsync(long id, PutTagDto tagDto)
        {
            bool result = await _repository.AnyAsync(t => t.Name == tagDto.Name && t.Id != id);
            if (result)
            {
                throw new Exception($"Tag name:{tagDto.Name} already exists");
            }
            Tag? existed = await _repository.GetByIdAsynch(id);
            if (existed is null) throw new Exception("Tag not found");
            existed = _mapper.Map(tagDto, existed);
            existed.UpdateAt = DateTime.Now;
            _repository.Update(existed);
            await _repository.SaveChangesAsync();
        }

        //Task<LoginDto> ITagService.GetByIdAsync(long? id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
