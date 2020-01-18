using System.ComponentModel.DataAnnotations;

namespace DomainCore.Core.ModelsDTO.Identity.Login
{
    public class LoginDTO
    {
        #region Properties

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        #endregion
    }
}
