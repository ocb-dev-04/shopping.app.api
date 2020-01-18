using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DomainCore.Data.Identity
{
    public class UserAppIdentity : IdentityUser
    {
        #region Properties

        [Required]
        public string Role { get; set; }

        #endregion
    }
}
