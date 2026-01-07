using OnionPronia.Domain.Entities.Common;


namespace OnionPronia.Domain.Entities
{
    public class Product: BaseNameableEntities
    {
        public static object ProductColors;

        public string SKU { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string Description { get; set; }

        //relations
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<ProductTag> ProductTags { get; set; }
    }
}
