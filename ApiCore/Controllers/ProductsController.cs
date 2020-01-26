using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using DomainCore.Core.EntitiesDTO.App.Products;
using DomainCore.Core.Interfaces.App;

namespace ApiCore.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
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

        #region Get's methods

        /// <summary>
        /// AUTORIZADO. Accede a todos los productos.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Accede a TODOS los productos de los vendedores.</response>
        /// <response code="404">No encontrado.</response>
        /// <response code="401">No autorizado.</response> 
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<IEnumerable<ProductsDTO>>> GetAll()
        {
            var response = await _productsRep.GetAllAsync();
            if (response == null)
                return NotFound("Product not exist");

            return Ok(response);
        }

        /// <summary>
        /// AUTORIZADO. Accede a todos los productos que tengan en comun el nombre.
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        /// <response code="200">Accede a TODOS los productos de los vendedores que tengan en comun el nombre.</response>
        /// <response code="404">No encontrado.</response>
        /// <response code="401">No autorizado.</response> 
        [HttpGet("product_name={productName}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<ProductsDTO>> GetByName([FromRoute] string productName)
        {
            if (string.IsNullOrEmpty(productName))
                return BadRequest("Product name can't be empty");

            var response = await _productsRep.GetByNameAsync(productName);
            if (response == null)
                return NotFound("Product not exist");

            return Ok(response);
        }

        /// <summary>
        /// AUTORIZADO. Accede al producto que pertenece el ID enviado en la ruta.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        /// <response code="200">Accede al producto con el ID especificado.</response>
        /// <response code="404">No encontrado.</response>
        /// <response code="401">No autorizado.</response> 
        [HttpGet("product_id={productId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<ProductsDTO>> GetById([FromRoute] int productId)
        {
            var response = await _productsRep.GetByIdAsync(productId);
            if (response == null)
                return NotFound("Product not exist");

            return Ok(response);
        }

        #endregion

        #region CRUD

        /// <summary>
        /// AUTORIZADO. Crea un producto, para su venta.
        /// </summary>
        /// <param name="create"></param>
        /// <returns></returns>
        /// <response code="200">Crea un producto.</response>
        /// <response code="400">Los datos no son validos.</response>
        /// <response code="401">No autorizado.</response> 
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<ProductsDTO>> CreateProducts([FromBody] CreateProductsDTO create)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _productsRep.CreateAsync(create);
            if (response == null)
                return BadRequest("Some error ocurred");

            return Ok(response);
        }

        /// <summary>
        /// AUTORIZADO. Actualiza un producto.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        /// <response code="200">Actualiza un producto.</response>
        /// <response code="400">Los datos no son validos.</response>
        /// <response code="401">No autorizado.</response> 
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Route("product_id={productId}")]
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

        /// <summary>
        /// AUTORIZADO. Borrar un producto en base a su ID.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        /// <response code="200">Elimina un producto.</response>
        /// <response code="400">Los datos no son validos.</response>
        /// <response code="401">No autorizado.</response> 
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Route("product_id={productId}")]
        public async Task<IActionResult> DeleteProducts([FromRoute] int productId)
        {
            var response = await _productsRep.DeleteAsync(productId);
            if (!response)
                return NotFound();

            return Ok();
        }

        #endregion

        // end controller
    }
}