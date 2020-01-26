using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using DomainCore.Core.Interfaces.App;
using DomainCore.Core.EntitiesDTO.App.Sellers;

namespace ApiCore.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("v1/api/[controller]")]
    [ApiController]
    public class SellersController : ControllerBase
    {
        #region Properties

        private readonly ISellersRep _sellersRep;
        private readonly ILogger<SellersController> _logger;

        #endregion

        #region Construct

        public SellersController(
            ISellersRep userInfoRep,
            ILogger<SellersController> logger)
        {
            _sellersRep = userInfoRep;
            _logger = logger;
        }

        #endregion

        #region Get's methods

        /// <summary>
        /// AUTORIZADO. Accede a todos los vendedores disponibles.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Accede a todos los vendedores registrados.</response>
        /// <response code="404">No encontrado.</response>
        /// <response code="401">No autorizado.</response> 
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<IEnumerable<SellersDTO>>> GetAll()
        {
            var response = await _sellersRep.GetAllAsync();
            if (response == null)
                return NotFound("Product not exist");

            return Ok(response);
        }

        /// <summary>
        /// AUTORIZADO. Buscar vendedor por su ID
        /// </summary>
        /// <param name="sellerId"></param>
        /// <returns></returns>
        /// <response code="200">Accede a un vendedor por ID</response>
        /// <response code="404">No encontrado.</response>
        /// <response code="401">No autorizado.</response> 
        [HttpGet("seller_id={sellerId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<SellersDTO>> GetById([FromRoute] int sellerId)
        {
            var response = await _sellersRep.GetByIdAsync(sellerId);
            if (response == null)
                return NotFound("Product not exist");

            return Ok(response);
        }

        #endregion

        #region CRUD

        /// <summary>
        /// AUTORIZADO. Crear vendedor. El userId se toma del JWT.
        /// </summary>
        /// <param name="create"></param>
        /// <returns></returns>
        /// <response code="200">Crea un vendedor en base a un usuario registrado.</response>
        /// <response code="400">Datos no son validos.</response>
        /// <response code="401">No autorizado.</response> 
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<SellersDTO>> CreateSellers([FromBody] CreateSellersDTO create)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _sellersRep.CreateAsync(create);
            if (response == null)
                return BadRequest("Some error ocurred");

            return Ok(response);
        }

        /// <summary>
        /// AUTORIZADO. Actualizar informacion de un vendedor.
        /// </summary>
        /// <param name="sellerId"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        /// <response code="200">Actualiza un vendedor en base a un usuario registrado.</response>
        /// <response code="400">Datos no son validos.</response>
        /// <response code="404">Vendedor no encontrado.</response>
        /// <response code="401">No autorizado.</response> 
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [Route("seller_id={sellerId}")]
        public async Task<IActionResult> UpdateSellers([FromRoute] int sellerId, [FromBody] UpdateSellersDTO update)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (sellerId != update.Id)
                return BadRequest("ProductId not the same");

            var response = await _sellersRep.UpdateAsync(update);
            if (!response)
                return NotFound("Some error ocurred");

            return Ok();
        }

        /// <summary>
        /// AUTORIZADO. Eliminar informacion como vendedor.
        /// </summary>
        /// <param name="sellerId"></param>
        /// <returns></returns>
        /// <response code="200">Elimina(Desabilita) un vendedor en base a un usuario registrado.</response>
        /// <response code="404">Vendedor no encontrado.</response>
        /// <response code="401">No autorizado.</response> 
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [Route("seller_id={sellerId}")]
        public async Task<IActionResult> DeleteSellers([FromRoute] int sellerId)
        {
            var response = await _sellersRep.DeleteAsync(sellerId);
            if (!response)
                return NotFound();

            return Ok();
        }

        #endregion
    }
}