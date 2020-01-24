using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using DomainCore.Data.Entities.Identity;

namespace ApiCore.Controllers.Identity
{
    [Route("api/[controller]")]
    public class AccountSettingsController : Controller
    {
        //#region Properties

        //private readonly UserManager<AppIdentityUser> _userManager;
        //private readonly IEmailRep _emailRep;
        //private readonly IViewRenderRep _viewRenderRep;
        //private readonly ILogger<AccountSettingsController> _logger;
        
        //#endregion

        //#region Construc

        //public AccountSettingsController(
        //    UserManager<AppIdentityUser> userManager,
        //    IEmailRep emailRep,
        //    IViewRenderRep viewRenderRep,
        //    ILogger<AccountSettingsController> logger)
        //{
        //    _userManager = userManager;
        //    _emailRep = emailRep;
        //    _viewRenderRep = viewRenderRep;
        //    _logger = logger;
        //}

        //#endregion

        //#region Methods

        //// POST: /Account/ChangeEmail
        //[HttpPost("change_email")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //public async Task<ActionResult> ChangeEmail([FromBody] ChangeEmail model)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var userId = User.Identity.Name;
        //    _logger.LogWarning($"UserId is --------> {userId}");

        //    var user = await _userManager.FindByIdAsync(userId);
        //    if (user == null)
        //        return BadRequest("User not exist");

        //    _logger.LogWarning($"Change email for user id {userId}");
        //    var code = await _userManager.GenerateChangeEmailTokenAsync(user, model.NewEmail);
        //    _logger.LogWarning($"change email token created");

        //    var callbackUrl = HttpContext.GenerateAbsoluteUrl("accountsettings/confirm_email", user.Id, model.NewEmail, code);
        //    _logger.LogWarning("Callbackurl is created");

        //    await _emailRep.SendAsync(
        //        subject: "App Name - Confirmacion de cambio de Email",
        //        body: //await _viewRenderRep.RenderTemplateAsync(
        //            //"Templates/ChangeEmail",
        //            "Mensaje de prueba",
        //            //new ChangeEmailTemplate(callbackUrl)),
        //        to: model.NewEmail
        //    );

        //    _logger.LogWarning("Email sended");
        //    return NoContent();
        //}

        //// GET: /Account/ConfirmEmail
        //[HttpPost("confirm_email")]
        //[AllowAnonymous]
        //public async Task<IActionResult> ConfirmEmail(ChangeEmailConfirm model)
        //{
        //    var user = await _userManager.FindByIdAsync(model.UserId);
        //    if (user == null)
        //        return BadRequest();

        //    _logger.LogInformation($"Confirm email for user id {user.Id}");

        //    var result = await _userManager.ChangeEmailAsync(user, model.NewEmail, model.Code);
        //    if (!result.Succeeded)
        //        return BadRequest();

        //    // Update Username
        //    user.UserName = model.NewEmail;
        //    await _userManager.UpdateAsync(user);

        //    return NoContent();
        //}

        //// POST: /Account/ChangePassword
        //[HttpPost("change_pass")]
        //public async Task<ActionResult> ChangePassword(ChangePassword model)
        //{
        //    var userId = User.Identity.Name;
        //    var user = await _userManager.FindByIdAsync(userId);
        //    _logger.LogInformation($"Change password for user id {user.Id}");
        //    var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
        //    if (!result.Succeeded)
        //    {
        //        _logger.LogInformation("Some erorr ocurred");
        //        return BadRequest();
        //    }
        //    _logger.LogInformation($"Change password successfully for user id {user.Id}");
        //    return NoContent();
        //}

        //// POST: /Account/ForgotPassword
        //[HttpPost("forgot_pass")]
        //[AllowAnonymous]
        //public async Task<ActionResult> ForgotPassword([FromBody] ForgotPassword model)
        //{
        //    _logger.LogInformation("Find user account {@Account}", model);
        //    var user = await _userManager.FindByNameAsync(model.Email);
        //    if (user == null)
        //    {
        //        _logger.LogInformation("User account don't exist {@account}", model);
        //        return BadRequest("User account doesn't exist");
        //    }

        //    // Send an email with this link
        //    var code = await _userManager.GeneratePasswordResetTokenAsync(user);
        //    var callbackUrl = HttpContext.GenerateAbsoluteUrl("accountsettings/reset_pass", user.Id, code);
        //    _logger.LogInformation("Sending forgot password email {@Url}", callbackUrl);
        //    await _emailRep.SendAsync(
        //        subject: "App Name - Verificacion de cambio de contraseña",
        //        body: await _viewRenderRep.RenderTemplateAsync(
        //            "Templates/ForgotPassword",
        //            new ForgotPasswordTemplate(callbackUrl)),
        //        to: model.Email
        //    );
        //    _logger.LogInformation("Sended forgot password email {@Url}", callbackUrl);
        //    return NoContent();
        //}

        //// POST: /Account/ResetPassword
        //[HttpPost("reset_pass")]
        //[AllowAnonymous]
        //public async Task<ActionResult> ResetPassword([FromBody] ResetPassword model)
        //{
        //    _logger.LogInformation($"Find user account {model}");
        //    var user = await _userManager.FindByIdAsync(model.UserId);
        //    if (user == null)
        //    {
        //        _logger.LogInformation($"User account dont exist {model}");
        //        return BadRequest();
        //    }
        //    _logger.LogInformation($"Reset password for user account {model}");
        //    var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
        //    if (!result.Succeeded)
        //    {
        //        _logger.LogInformation($"Cant reset password for user account {model}");
        //        return BadRequest();
        //    }
        //    return NoContent();
        //}

        //#endregion
    }
}
