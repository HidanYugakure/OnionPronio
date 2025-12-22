using System;

namespace OnionPronia.Application.DTOS
{
    public record GetCategoryItemDto(
        int Id,
        string Name,
        int ProductCount
        );

}
