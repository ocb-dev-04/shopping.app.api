using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using DomainCore.Core.Interfaces.Identity;
using DomainCore.Core.ModelsDTO.Identity;

namespace ApiCore.Controllers.Identity
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        #region Properties

        private readonly IProfileInfoRep _profileInfoRep;
        private readonly ILogger _logger;

        #endregion

        #region Construct

        public ProfilesController(
            IProfileInfoRep profileInfoRep,
            ILogger<ProfilesController> logger)
        {
            _profileInfoRep = profileInfoRep;
            _logger = logger;
        }

        #endregion

        #region Methods

        #region Get's Methods

        [HttpGet("profileId={id}", Name = "GetProfileById")]
        public async Task<ActionResult<ProfileInfoDTO>> GetById([FromRoute] int profileId)
        {
            _logger.LogInformation($"Acces to profileInfo find profile with ID => {profileId}");
            if (profileId < 0)
                return BadRequest("ProfileId can't be less of 0");

            var response = await _profileInfoRep.GetProfileInfoById(profileId);
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        #endregion

        #region CRUD Methods

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        #endregion

        #endregion
    }
}
