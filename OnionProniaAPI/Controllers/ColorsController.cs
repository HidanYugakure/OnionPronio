using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionPronia.Application.DTOs;
using OnionPronia.Application.Interfaces.Services;

namespace OnionProniaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {

        private readonly IColorService _service ;

        public ColorsController(IColorService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> Get(int page, int take)
        {

            return Ok(await _service.GetAllAsync(page, take));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long? id)
        {
            if (id is null || id < 1) return BadRequest();

            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] PostColorDto colorDto)
        {

            await _service.CreateAsync(colorDto);
            return Created();
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(long? id)
        {
            if (id is null || id < 1) return BadRequest();
            await _service.DeleteAsync(id.Value);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long? id, [FromForm] PutColorDto colorDto)
        {
            if (id < 1) return BadRequest();
            await _service.UpdateAsync(id.Value, colorDto);
            return NoContent();
        }

    }
}
