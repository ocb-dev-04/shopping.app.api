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

        [HttpGet]
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

        [Route("create-profile")]
        [HttpPost]
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

        [Route("update-profile")]
        [HttpPut]
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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete]
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