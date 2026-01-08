using AutoMapper;
using OnionPronia.Application.DTOs;
using OnionPronia.Application.DTOs.AppUsers;
using OnionPronia.Application.DTOS.Tags;
using OnionPronia.Domain.Entities;

namespace OnionPronia.Application.MappingProfiles
{
    internal class TagProfile:Profile
    {
        public TagProfile() 
        {
            CreateMap<Tag, GetTagInProductDto>();
            CreateMap<Tag, LoginDto>();
            CreateMap<Tag, GetTagItemDto>()
            .ForCtorParam(nameof(GetTagItemDto.ProductCount),
            opt => opt.MapFrom(t => t.ProductTags.Count));
            CreateMap<PostTagDto, Tag>(); 
            CreateMap<PutTagDto, Tag>();
        }

    }
}
