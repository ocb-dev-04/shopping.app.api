using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

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
