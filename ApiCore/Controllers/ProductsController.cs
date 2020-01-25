using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using DomainCore.Core.EntitiesDTO.App.Products;
using DomainCore.Core.Interfaces.App;

namespace ApiCore.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("v1/api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        #region Properties

        private readonly IProductsRep _productsRep;
        private readonly ILogger<ProductsController> _logger;

        #endregion

        #region Construct

        public ProductsController(
            IProductsRep userInfoRep,
            ILogger<ProductsController> logger)
        {
            _productsRep = userInfoRep;
            _logger = logger;
        }

        #endregion

        #region Methods

        #region Get's methods

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<ProductsDTO>>> GetAll()
        {
            var response = await _productsRep.GetAllAsync();
            if (response == null)
                return NotFound("Product not exist");

            return Ok(response);
        }

        [HttpGet("product-name={productName}")]
        public async Task<ActionResult<ProductsDTO>> GetByName([FromRoute] string productName)
        {
            if (string.IsNullOrEmpty(productName))
                return BadRequest("Product name can't be empty");

            var response = await _productsRep.GetByNameAsync(productName);
            if (response == null)
                return NotFound("Product not exist");

            return Ok(response);
        }

        [HttpGet("product-id={productId}")]
        public async Task<ActionResult<ProductsDTO>> GetById([FromRoute] int productId)
        {
            var response = await _productsRep.GetByIdAsync(productId);
            if (response == null)
                return NotFound("Product not exist");

            return Ok(response);
        }

        #endregion

        #region CRUD

        [HttpPost]
        public async Task<ActionResult<ProductsDTO>> CreateProducts([FromBody] CreateProductsDTO create)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _productsRep.CreateAsync(create);
            if (response == null)
                return BadRequest("Some error ocurred");

            return Ok(response);
        }

        [HttpPut]
        [Route("product-id={productId}")]
        public async Task<IActionResult> UpdateProducts([FromRoute] int productId, [FromBody] UpdateProductsDTO update)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (productId != update.Id)
                return BadRequest("ProductId not the same");

            var response = await _productsRep.UpdateAsync(update);
            if (!response)
                return NotFound("Some error ocurred");

            return Ok();
        }

        [HttpDelete]
        [Route("product-id={productId}")]
        public async Task<IActionResult> DeleteProducts([FromRoute] int productId)
        {
            var response = await _productsRep.DeleteAsync(productId);
            if (!response)
                return NotFound();

            return Ok();
        }

        #endregion

        #endregion
    }
}