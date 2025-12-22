using System;

namespace OnionPronia.Application.DTOS
{
    public record GetProductInCategoryDto
         (
             int Id, string Name, decimal Price
         );
}
