using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionPronia.Application.Interfaces.Services;

namespace OnionProniaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductsController(IProductService service)
        {
            _service = service;
        }
        public async Task<IActionResult> GetAsync(int  page=0, int pageSize = 10)
        {
            return Ok(await _service.GetAllAsynch(page, pageSize));
        }
    }
}
