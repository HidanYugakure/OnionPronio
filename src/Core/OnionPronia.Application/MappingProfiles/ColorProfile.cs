using AutoMapper;
using OnionPronia.Application.DTOs;
using OnionPronia.Application.DTOS.Products;
using OnionPronia.Application.DTOS.Tags;
using OnionPronia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Application.MappingProfiles
{
    internal class ColorProfile: Profile
    {
        public ColorProfile()
        {

            CreateMap<Color, GetColorDto>();
            CreateMap<Color, GetColorItemDto>()
                 .ForCtorParam(nameof(GetColorItemDto.ProductCount),
                    opt => opt.MapFrom(c => c.ProductColors.Count)); ;
            CreateMap<PostColorDto, Color>();
            CreateMap<PutColorDto, Color>();
        }
    }
}
