using OnionPronia.Application.DTOS.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<IReadOnlyList<GetProductItemDto>> GetAllAsynch(int page, int take);
    }
}
