using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionPronia.Application.DTOs;
using OnionPronia.Application.Interfaces.Services;

namespace OnionProniaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _service;
        public TagsController(ITagService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int page, int take)
        {

            return Ok(await _service.GetAllAsync(page, take));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] PostTagDto tagDto)
        {
            await _service.CreateAsync(tagDto);
            return Created();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long? id, PutTagDto tagDto)
        {
            if (id < 1)
            { return BadRequest(); }
            await _service.UpdateAsync(id.Value, tagDto);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long? id)
        {
            if (id is null || id < 1) return BadRequest();

            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(long? id)
        {
            if (id is null || id < 1) return BadRequest();
            await _service.DeleteAsync(id.Value);

            return NoContent();
        }
    }
}
