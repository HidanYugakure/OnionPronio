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
    internal class ProductProfile: Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, GetProductInCategoryDto>();
            CreateMap<Product, GetProductItemDto>()
                .ForCtorParam(
                nameof(GetProductItemDto.CategoryName),
                opt => opt.MapFrom(p => p.Category.Name)
                );
            CreateMap<Product, GetProductDto>()
                .ForCtorParam(nameof(GetProductDto.CategoryDto),
                opt => opt.MapFrom(p => p.Category))
                .ForCtorParam(nameof(GetProductDto.TagDtos),
                opt => opt.MapFrom(p => p.ProductTags
                .Select(pt => new GetTagInProductDto(pt.Tag.Id, pt.Tag.Name))
                .ToList()))
                .ForCtorParam(nameof(GetProductDto.ColorDtos),
                opt => opt.MapFrom(p => p.ProductColors
               .Select(pt => new GetColorInProductDto(pt.Color.Id, pt.Color.Name))
               .ToList()));

        }
    }
}
