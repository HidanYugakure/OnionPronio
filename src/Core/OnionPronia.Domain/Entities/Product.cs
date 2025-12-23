using OnionPronia.Domain.Entities.Common;
using System;

namespace OnionPronia.Domain.Entities
{
    public class Product: BaseNameableEntities
    {
       
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }
        public string Description { get; set; }

        //relations
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        ICollection<ProductTag> ProductTags { get; set; }
    }
}
