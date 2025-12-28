using System;

namespace OnionPronia.Application.DTOS.Products
{
    public record GetProductInCategoryDto
         (
             long Id, string Name, decimal Price
         );
}
