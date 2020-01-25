using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using DomainCore.Core.Interfaces.App;
using DomainCore.Core.EntitiesDTO.App.Sellers;

namespace ApiCore.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

        #region Methods

        #region Get's methods

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<SellersDTO>>> GetAll()
        {
            var response = await _sellersRep.GetAllAsync();
            if (response == null)
                return NotFound("Product not exist");

            return Ok(response);
        }

        [HttpGet("seller-id={sellerId}")]
        public async Task<ActionResult<SellersDTO>> GetById([FromRoute] int sellerId)
        {
            var response = await _sellersRep.GetByIdAsync(sellerId);
            if (response == null)
                return NotFound("Product not exist");

            return Ok(response);
        }

        #endregion

        #region CRUD

        [HttpPost]
        public async Task<ActionResult<SellersDTO>> CreateSellers([FromBody] CreateSellersDTO create)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _sellersRep.CreateAsync(create);
            if (response == null)
                return BadRequest("Some error ocurred");

            return Ok(response);
        }

        [HttpPut]
        [Route("seller-id={sellerId}")]
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

        [HttpDelete]
        [Route("seller-id={sellerId}")]
        public async Task<IActionResult> DeleteSellers([FromRoute] int sellerId)
        {
            var response = await _sellersRep.DeleteAsync(sellerId);
            if (!response)
                return NotFound();

            return Ok();
        }

        #endregion

        #endregion
    }
}