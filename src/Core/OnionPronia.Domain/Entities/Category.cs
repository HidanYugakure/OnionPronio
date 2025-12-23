using OnionPronia.Domain.Entities.Common;
using System;


namespace OnionPronia.Domain.Entities
{
    public class Category:BaseNameableEntities
    {       
       public ICollection<Product> Products { get; set; }
    }
}
