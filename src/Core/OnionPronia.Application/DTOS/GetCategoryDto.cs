using System;


namespace OnionPronia.Application.DTOS
{
    public record GetCategoryDto
    (
        long Id,
        string Name,
        IEnumerable<GetProductInCategoryDto> productDtos
    );
}
