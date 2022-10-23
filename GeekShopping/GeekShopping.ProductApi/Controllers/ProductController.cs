using GeekShopping.ProductApi.Data.ValueObjects;
using GeekShopping.ProductApi.Repository;
using GeekShopping.ProductApi.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductApi.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            var products = await _repository.FindAll();

            return Ok(products);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            var product = await _repository.FindById(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ProductVO>> Create(ProductVO productVO)
        {
            if (productVO == null)
                return BadRequest();

            var product = await _repository.Create(productVO);
            return Ok(product);
        }
        
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<ProductVO>> Put(ProductVO productVO)
        {
            if (productVO == null)
                return BadRequest();

            var product = await _repository.Update(productVO);
            return Ok(product);
        }

        [HttpDelete("Id")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Delete(long Id)
        {
            var status = await _repository.Delete(Id);

            if (!status)
                return BadRequest();

            return Ok(status);
        }
    }
}
