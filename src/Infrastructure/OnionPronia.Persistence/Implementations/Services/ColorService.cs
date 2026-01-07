using AutoMapper;
using OnionPronia.Application.DTOs;
using OnionPronia.Application.Interface.Repositories;
using OnionPronia.Application.Interfaces.Services;

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

        public Task CreateAsync(PostColorDto colorDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<GetColorItemDto>> GetAllAsync(int page, int take)
        {
            throw new NotImplementedException();
        }

        public Task<GetColorDto> GetByIdAsync(long? id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(long id, PutColorDto colorDto)
        {
            throw new NotImplementedException();
        }
    }
}
