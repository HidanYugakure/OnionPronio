using OnionPronia.Application.DTOS.Tags;
using OnionPronia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Application.DTOS.Products
{
    public record GetProductDto
    (
        long id,
        string Name,
        decimal Price,
        string SKU,
        string Description,
        GetProductInCategoryDto CategoryDto,
        ICollection<GetTagInProductDto> TagDtos
    );
}
