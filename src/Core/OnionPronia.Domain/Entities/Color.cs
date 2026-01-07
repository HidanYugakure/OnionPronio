
using OnionPronia.Domain.Entities.Common;

namespace OnionPronia.Domain.Entities
{
    public class Color : BaseNameableEntities
    {
        public ICollection<ProductColor> ProductColors { get; set; }
    }

    
}
