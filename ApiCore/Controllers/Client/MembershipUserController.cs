using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ApiCore.Controllers.Client
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(Roles = "Client")]
    public class MembershipUserController : Controller
    {
        //#region Properties

        //private readonly IMembershipInfoRep _membershipInfoRep; 
        //private readonly IMembershipUserRep _membershipUserRep;

        //#endregion

        //#region Construct

        //public MembershipUserController(
        //    IMembershipInfoRep membershipInfoRep,
        //    IMembershipUserRep membershipUserRep)
        //{
        //    _membershipInfoRep = membershipInfoRep;
        //    _membershipUserRep = membershipUserRep;
        //}

        //#endregion

        //#region Membership's Info

        //[HttpGet("get_all")]
        //public async Task<ActionResult<IEnumerable<MembershipInfoDTO>>> GetAll()
        //{
        //    var response = await _membershipInfoRep.GetAllAsync();
        //    if (response == null)
        //        return NotFound("Error");

        //    return Ok(response);
        //}

        //[HttpGet("membership_name={memberName}")]
        //public async Task<ActionResult<MembershipInfoDTO>> GetByName([FromRoute] string memberName)
        //{
        //    if (memberName == "")
        //        return BadRequest("MembershipName can't be empty");

        //    var response = await _membershipInfoRep.GetByNameAsync(memberName);
        //    if (response == null)
        //        return NotFound("Error");

        //    return Ok(response);
        //}

        //#endregion

        //#region Membership User

        //[HttpGet("get_by_userId")]
        //public async Task<ActionResult<IEnumerable<MembershipInfoDTO>>> GetByUserId()
        //{
        //    var clientId = User.Identity.Name;
        //    var response = await _membershipUserRep.GetByClientIdAsync(clientId);
        //    if (response == null)
        //        return NotFound("User not exist");

        //    return Ok(response);
        //}

        //#endregion

        //#region CRUD

        //[HttpPost]
        //public async Task<ActionResult<MembershipUserDTO>> CreateMembershipMembershipUser([FromBody] CreateMembershipUserDTO create)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    create.ClientId = User.Identity.Name;
        //    var response = await _membershipUserRep.CreateAsync(create);
        //    if (response == null)
        //        return BadRequest("Some error ocurred");

        //    return Ok(response);
        //}

        //[HttpPut]
        //public async Task<IActionResult> UpdateMembershipMembershipUserInfo([FromBody] UpdateMembershipUserDTO update)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    update.ClientId = User.Identity.Name;
        //    var response = await _membershipUserRep.UpdateAsync(update);
        //    if (!response)
        //        return NotFound("Some error ocurred");

        //    // response a true to client-side manage the UI
        //    return Ok();
        //}

        //[HttpDelete]
        //public async Task<IActionResult> DeleteMembershipMembershipUserInfo()
        //{
        //    var userId = User.Identity.Name;
        //    var response = await _membershipUserRep.DeleteAsync(userId);
        //    if (!response)
        //        return NotFound();

        //    return Ok();
        //}

        //#endregion
    }
}
