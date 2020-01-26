using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using DomainCore.Core.Interfaces.App;
using DomainCore.Core.EntitiesDTO.App.ProfileInfo;

namespace ApiCore.Controllers.Identity
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("v1/api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        #region Properties

        private readonly IProfileInfosRep _profileInfosRep;
        private readonly ILogger<ProfilesController> _logger;

        #endregion

        #region Construct

        public ProfilesController(
            IProfileInfosRep profileInfosRep,
            ILogger<ProfilesController> logger)
        {
            _profileInfosRep = profileInfosRep;
            _logger = logger;
        }

        #endregion

        #region Get's Methods

        /// <summary>
        /// AUTORIZADO. Accede a la informacion de usuario (mediante JWT)
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Accede a la informacion basica de un usuario.</response>
        /// <response code="404">No encontrado.</response>
        /// <response code="401">No autorizado.</response> 
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<ProfileInfoDTO>> GetById()
        {
            var userId = User.Identity.Name;
            var response = await _profileInfosRep.GetByIdAsync(userId);
            if (response == null)
                return NotFound("User not exist");

            return Ok(response);
        }

        #endregion

        #region CRUD

        /// <summary>
        /// AUTORIZADO. Crea la informacion de un usuario (en base a JWT)
        /// </summary>
        /// <param name="create"></param>
        /// <returns></returns>
        /// <response code="200">Crear la informacion basica de un usuario.</response>
        /// <response code="404">No encontrado.</response>
        /// <response code="401">No autorizado.</response> 
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        public async Task<ActionResult> CreateUser([FromBody] CreateProfileInfoDTO create)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            create.UserId = User.Identity.Name;
            var result = await _profileInfosRep.CreateAsync(create);
            if (result == null)
                return BadRequest("Some error ocurred while try create your account");

            return Ok(result);
        }

        /// <summary>
        /// AUTORIZADO. Actualiza la informacion de un usuario (en base a JWT)
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        /// <response code="200">Actualiza la informacion basica de un usuario.</response>
        /// <response code="404">No encontrado.</response>
        /// <response code="401">No autorizado.</response> 
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        public async Task<ActionResult> UpdateUser([FromBody] UpdateProfileInfoDTO update)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!User.Identity.Name.Equals(update.UserId))
                return BadRequest("You can't update another account");

            var result = await _profileInfosRep.UpdateAsync(update);
            if (!result)
                return BadRequest("Some error ocurred while try update your account");

            return Ok();
        }

        /// <summary>
        /// AUTORIZADO. Borra la informacion de un usuario (en base a JWT)
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Borra la informacion basica de un usuario.</response>
        /// <response code="404">No encontrado.</response>
        /// <response code="401">No autorizado.</response> 
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        public async Task<ActionResult> DeleteUser()
        {
            var authUserId = User.Identity.Name;// take info from jwt
            _logger.LogInformation($"Try to delete profile info with userId => {authUserId}");
            var response = await _profileInfosRep.DeleteAsync(authUserId);
            if (!response)
                return NotFound("Some error ocurred while delete your account");

            return Ok("Account delete succesful");
        }

        #endregion
    }
}