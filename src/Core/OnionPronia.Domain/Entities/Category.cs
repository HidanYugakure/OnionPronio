using OnionPronia.Domain.Entities.Common;
using System;


namespace OnionPronia.Domain.Entities
{
    public class Category:BaseNameableEntities
    {       
        ICollection<Product> Products { get; set; }
    }
}
