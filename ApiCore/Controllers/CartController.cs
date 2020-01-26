using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using DomainCore.Core.EntitiesDTO.App.Cart;
using DomainCore.Core.Interfaces.App;

namespace ApiCore.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("v1/api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        #region Properties

        private readonly ICartRep _cartRep;

        #endregion

        #region Construct

        public CartController(ICartRep cartRep)
            => _cartRep = cartRep;

        #endregion

        #region Get's methods

        /// <summary>
        /// AUTORIZADO. Acede a todos los productos que el usuario "X" ha agregado al carrito.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Accede a todos los productos que un usuario tiene en su carrito.</response>
        /// <response code="404">No encontrado.</response>
        /// <response code="401">No autorizado.</response> 
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<IEnumerable<CartDTO>>> GetAll()
        {
            var userId = User.Identity.Name;
            var response = await _cartRep.GetByUserIdAsync(userId);
            if (response == null)
                return NotFound("Cart not exist");

            return Ok(response);
        }

        #endregion

        #region CRUD

        /// <summary>
        /// AUTORIZADO. Agrega los productos del usuario "X" al carrito.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Agrega productos al carrito de el usuario logeado.</response>
        /// <response code="404">No encontrado.</response>
        /// <response code="401">No autorizado.</response> 
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<CartDTO>> AddProductsToCart([FromBody] CreateCartDTO create)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _cartRep.CreateAsync(create);
            if (response == null)
                return BadRequest("Some error ocurred");

            return Ok(response);
        }

        /// <summary>
        /// AUTORIZADO. Actualiza un productos del usuario "X" en el carrito.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Actualiza un productos que un usuario tiene en su carrito.</response>
        /// <response code="404">No encontrado.</response>
        /// <response code="401">No autorizado.</response> 
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [Route("product_id={productId}")]
        public async Task<IActionResult> UpdateProductsInCart([FromRoute] int productId, [FromBody] UpdateCartDTO update)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (productId != update.Id)
                return BadRequest("ProductId not the same");

            var response = await _cartRep.UpdateAsync(update);
            if (!response)
                return NotFound("Some error ocurred");

            return Ok();
        }

        /// <summary>
        /// AUTORIZADO. Elimina un solo productos del usuario "X" del carrito.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Elimina un productos que un usuario tiene en su carrito.</response>
        /// <response code="404">No encontrado.</response>
        /// <response code="401">No autorizado.</response> 
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [Route("product_id={productId}")]
        public async Task<IActionResult> DeleteProductsInCart([FromRoute] int productId)
        {
            var userId = User.Identity.Name;
            var response = await _cartRep.DeleteAsync(productId, userId);
            if (!response)
                return NotFound();

            return Ok();
        }

        /// <summary>
        /// AUTORIZADO. Vacia el carrito.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Limpia el carrito del usuario.</response>
        /// <response code="404">No encontrado.</response>
        /// <response code="401">No autorizado.</response> 
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [Route("cart_id={cartId}")]
        public async Task<IActionResult> DeleteAllProductsInCart([FromRoute] int cartId)
        {
            var userId = User.Identity.Name;
            var response = await _cartRep.DeleteAllAsync(cartId, userId);
            if (!response)
                return NotFound();

            return Ok();
        }

        #endregion

        // end controller
    }
}