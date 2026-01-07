using AutoMapper;
using OnionPronia.Application.DTOs;
using OnionPronia.Application.Interface.Repositories;
using OnionPronia.Application.Interfaces.Services;
using OnionPronia.Persistence.Implementations.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Task CreateAsync(PostTagDto tagDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<GetTagItemDto>> GetAllAsync(int page, int take)
        {
            throw new NotImplementedException();
        }

        public Task<GetTagDto> GetByIdAsync(long? id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(long id, PutTagDto tagDto)
        {
            throw new NotImplementedException();
        }
    }
    }
