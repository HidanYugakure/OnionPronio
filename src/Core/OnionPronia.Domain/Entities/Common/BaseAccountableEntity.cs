using System;


namespace OnionPronia.Domain.Entities.Common
{
    public abstract class BaseAccountableEntity:BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string CreatedBy { get; set; } = "admin";
    }
}
