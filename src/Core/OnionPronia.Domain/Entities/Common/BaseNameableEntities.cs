using System;


namespace OnionPronia.Domain.Entities.Common
{
    public abstract class BaseNameableEntities: BaseAccountableEntity
    {
       public string Name { get; set; }
    }
}
