using System.ComponentModel.DataAnnotations;

namespace DomainCore.Core.ModelsDTO.Identity.UserAppIdentity
{
    public class UserAppIdentityDTO
    {
        #region Properties

        public string Id { get; set; }
        [Required]
        public string FullName { get; set; }

        //  just need email because password was hashed
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        #endregion
    }
}
