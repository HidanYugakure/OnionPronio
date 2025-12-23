using System;

namespace OnionPronia.Application.DTOS
{
    public record GetProductInCategoryDto
         (
             long Id, string Name, decimal Price
         );
}
