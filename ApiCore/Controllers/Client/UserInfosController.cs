using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ApiCore.Controllers.Client
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserInfosController : Controller
    {
        //#region Properties

        //private readonly IUserInfoRep _userInfoRep;
        //private readonly ILogger _logger;

        //#endregion

        //#region Construct

        //public UserInfosController(
        //    IUserInfoRep userInfoRep,
        //    ILogger<UserInfosController> logger)
        //{
        //    _userInfoRep = userInfoRep;
        //    _logger = logger;
        //}

        //#endregion

        //#region Get's methods

        //[HttpGet]
        //public async Task<ActionResult<UserInfoDTO>> GetById()
        //{
        //    var userId = User.Identity.Name;
        //    var response = await _userInfoRep.GetByUserIdAsync(userId);
        //    if (response == null)
        //        return NotFound("User not exist");

        //    return Ok(response);
        //}

        //#endregion

        //#region CRUD

        //[HttpPost]
        //public async Task<ActionResult<UserInfoDTO>> CreateUserInfo([FromBody] CreateUserInfoDTO create)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    create.UserId = User.Identity.Name;
        //    var response = await _userInfoRep.CreateAsync(create);
        //    if (response == null)
        //        return BadRequest("Some error ocurred");

        //    return Ok(response);
        //}

        //[HttpPut]
        //public async Task<IActionResult> UpdateUserInfo([FromBody] UpdateUserInfoDTO update)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    update.UserId = User.Identity.Name;
        //    var response = await _userInfoRep.UpdateAsync(update);
        //    if (!response)
        //        return NotFound("Some error ocurred");

        //    // response a true to client-side manage the UI
        //    return Ok();
        //}

        //[HttpDelete]
        //public async Task<IActionResult> DeleteUserInfo()
        //{
        //    var userId = User.Identity.Name;
        //    var response = await _userInfoRep.DeleteAsync(userId);
        //    if (!response)
        //        return NotFound();

        //    return Ok();
        //}

        //#endregion
    }
}
