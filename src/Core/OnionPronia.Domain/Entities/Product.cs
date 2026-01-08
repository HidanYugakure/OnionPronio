using OnionPronia.Domain.Entities.Common;


namespace OnionPronia.Domain.Entities
{
    public class Product: BaseNameableEntities
    {
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        //relations
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<ProductTag> ProductTags { get; set; }
        public ICollection<ProductColor> ProductColors { get; set; }
    }
}
