using InventoryService.API.Dtos;
using InventoryService.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoriesContorller : ControllerBase
    {
        private readonly ProductRepository productRepository;

        public InventoriesContorller(ProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await productRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("{uniqueInfo}")]
        public async Task<IActionResult> GetByUniqueInfo(Guid uniqueInfo)
        {
            var result = await productRepository.GetByUniqueInfo(uniqueInfo);

            return Ok(result);

        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDto dto)
        {
            var result = await this.productRepository.Create(new Data.Entities.Product
            {
                UniqueInfo = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                ImageUrl = dto.ImageUrl,
            });

            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto dto)
        {
            await this.productRepository.Update(new Data.Entities.Product
            {
                UniqueInfo = dto.UniqueInfo,
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                ImageUrl = dto.ImageUrl,
            });
            return NoContent();
        }

        [HttpDelete("{uniqueInfo}")]
        public async Task<IActionResult> Remove(Guid uniqueInfo)
        {
            await this.productRepository.Remove(uniqueInfo);
            return NoContent();
        }

    }
}
