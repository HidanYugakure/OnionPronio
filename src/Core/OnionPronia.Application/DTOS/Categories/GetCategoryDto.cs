using OnionPronia.Application.DTOS.Products;
using System;


namespace OnionPronia.Application.DTOS.Categories
{
    public record GetCategoryDto
    (
        long Id,
        string Name,
        ICollection<GetProductInCategoryDto> ProductDtos
    );
}
