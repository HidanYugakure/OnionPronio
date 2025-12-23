using System;

namespace OnionPronia.Application.DTOS
{
    public record GetCategoryItemDto(
        long Id,
        string Name,
        int ProductCount
        );

}
