using System.ComponentModel.DataAnnotations;

namespace DomainCore.Core.EntitiesDTO.Identity
{
    public class CreateAppIdentityUserDTO
    {
        #region Properties
        
        [MinLength(5)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Las contraseñas no coinciden")]
        public string ConfirmPassword { get; set; }
        
        [Phone]
        public string Phone { get; set; }

        public string RoleName { get; set; }

        #endregion
    }
}
