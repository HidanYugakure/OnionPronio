using System;

namespace OnionPronia.Application.DTOS.Categories
{
    public record GetCategoryItemDto(
        long Id,
        string Name,
        int ProductCount
        );

}
