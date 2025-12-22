using OnionPronia.Domain.Entities.Common;
using System;


namespace OnionPronia.Domain.Entities
{
    public class Tag:BaseNameableEntities
    {
        ICollection<ProductTag> ProductTags { get; set; }
    }
}
