using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

using DomainCore.Core.Interfaces.Identity;
using DomainCore.Core.EntitiesDTO.Identity;

namespace ApiCore.Controllers.Identity
{
    [Produces("application/json")]
    [Route("v1/api/[controller]")]
    public class AuthController : Controller
    {
        #region Properties

        private readonly IIdentityUserRep _identityUserRep;
        private readonly ILogger<AuthController> _logger;
        private readonly IConfiguration _configuration;

        #endregion

        #region Construct

        public AuthController(
            IIdentityUserRep identityUserRep,
            ILogger<AuthController> logger,
            IConfiguration configuration)
        {
            _identityUserRep = identityUserRep;
            _logger = logger;
            _configuration = configuration;
        }

        #endregion

        #region Login and Token

        /// <summary>
        /// PUBLICO. Endpoint para acceder y por ende solicitar un JWT. (JWT para web, vence en horas)
        /// </summary>
        /// <param name="createWebToken"></param>
        /// <returns></returns>
        /// <response code="200">El logeo fue un exito y se trae un token.</response>
        /// <response code="400">Esas credenciales no son validas.</response> 
        [Route("auth_user_web")] // login from website
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> LoginAndToken([FromBody] Login createWebToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var auth = await _identityUserRep.AuthUserWebAsync(createWebToken);
            if (auth == null)
                return NotFound("Some error ocurred while try create the token");

            return Ok(new
            {
                token = auth.Token
            });
        }

        /// <summary>
        /// PUBLICO. Endpoint para acceder y por ende solicitar un JWT. Endpoint para acceder y por ende solicitar un JWT. (JWT para web, vence en horas)
        /// </summary>
        /// <param name="createFixedToken"></param>
        /// <returns></returns>
        /// <response code="200">El logeo fue exitoso y trajo un token.</response>
        /// <response code="400">Esas credenciales no son validas.</response>
        [Route("auth_user_fixed")] // login from desktop or app mobile
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> LoginAndTokenFixed([FromBody] Login createFixedToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var auth = await _identityUserRep.AuthUserFixedAsync(createFixedToken);
            if (auth == null)
                return NotFound("Some error ocurred while try create the token");

            return Ok(new
            {
                token = auth.Token
            });
        }

        #endregion
    }
}
