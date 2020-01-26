using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using DomainCore.Core.Interfaces.Identity;
using DomainCore.Core.EntitiesDTO.Identity;

namespace ApiCore.Controllers.Identity
{
    [Produces("application/json")]
    [Route("v1/api/[controller]")]
    public class AccountsController : Controller
    {
        #region Properties

        private readonly IIdentityUserRep _identityUserRep;

        #endregion

        #region Construct

        public AccountsController(IIdentityUserRep identityUserRep)
            => _identityUserRep = identityUserRep;

        #endregion

        #region Get's Methods

        /// <summary>
        /// AUTORIZADO. Accede a la informacion basica del usuario logeado en ese momento. En base a su JWT.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Retorna un JWT.</response>
        /// <response code="400">Esas credenciales no son validas.</response>
        /// <response code="401">No autorizado.</response>  
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<AppIdentityUserDTO>> GetById()
        {
            var userId = User.Identity.Name;
            var response = await _identityUserRep.GetById(userId);
            if (response == null)
                return NotFound("User  not exist");

            return Ok(response);
        }

        #endregion

        #region Register

        /// <summary>
        /// PUBLICO. Registro de usuarios nuevos.
        /// </summary>
        /// <param name="create"></param>
        /// <returns></returns>
        /// <response code="200">Retorna un usuario ya creado.</response>
        /// <response code="400">Los datos ingresados no son validos.</response>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateUser([FromBody] CreateAppIdentityUserDTO create)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var confirm = await _identityUserRep.ConfirmEmailAsync(create.Email);
            if (!confirm)
                return BadRequest("Email is used");

            var result = await _identityUserRep.CreateUserAsync(create);
            if (result == null)
                return BadRequest("Some error ocurred while try create your account");

            return Ok(result);
        }

        #endregion

        #region Delete Methods

        /// <summary>
        /// AUTORIZADO. Borrar(deshabilitar) un usuario previamente registrado.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Borro o deshabilito el usuario exitosamente.</response>
        /// <response code="404">No encontrado.</response>
        /// <response code="401">No autorizado.</response> 
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        public async Task<ActionResult> DeleteUser()
        {

            var authUserId = User.Identity.Name;
            var response = await _identityUserRep.DeleteUserAsync(authUserId);
            if (!response)
                return NotFound("Some error ocurred while delete your account");

            return Ok("Account delete succesful");
        }

        #endregion
    
        // end controller
    }
}
