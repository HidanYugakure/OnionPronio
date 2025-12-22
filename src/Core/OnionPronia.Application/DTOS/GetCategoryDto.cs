using System;


namespace OnionPronia.Application.DTOS
{
    public record GetCategoryDto
    (
        int Id,
        string name,
        IEnumerable<GetProductInCategoryDto> productDtos
    );
}
