using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionPronia.Application.DTOS.Categories;
using OnionPronia.Application.Interface.Repositories;
using OnionPronia.Application.Interface.Services;

namespace OnionProniaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _repository;
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryRepository repository, ICategoryService services)
        {
            _repository = repository;
            _service = services;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page, int take)
        {
            //IReadOnlyList<GetCategoryItemDto> categoryDtos = await _repository.GetAll(
            //    sort:c => c.Name,
            //    isDesc: false,
            //    page: page,
            //    Take: take
            //    ).Select(c => new GetCategoryItemDto
            //     (
            //        c.Id,
            //          c.Name,
            //         c.Products.Count
            //     ))
            //     .ToListAsync();
            return Ok(_service.GetAllAsync(page, take));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int? id)
        {
            if (id is null || id < 1)
            {
                return BadRequest("Invalid category ID.");
            }

            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] PostCategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _service.CreateCategoryAsync(categoryDto);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int? id, [FromForm] PutCategoryDto categoryDto)
        {
            if (id is null || id < 1)
            {
                return BadRequest("Invalid category ID.");
            }

            await _service.UpdateAsync(id.Value, categoryDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id < 1)
            {
                return BadRequest("Invalid category ID.");
            }
            await _service.DeleteAsync(id.Value);
            return NoContent();
        }
    }
}
