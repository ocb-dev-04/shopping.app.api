using System.ComponentModel.DataAnnotations;

namespace DomainCore.Core.ModelsDTO.Identity.UserAppIdentity
{
    public class CreateUserAppIdentityDTO
    {
        #region Properties

        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        
        #endregion
    }
}
