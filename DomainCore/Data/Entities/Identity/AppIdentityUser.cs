using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DomainCore.Data.Entities.Identity
{
    public class AppIdentityUser : IdentityUser
    {
        #region Properties

        public string FullName { get; set; }
        [Required]
        public string Role { get; set; }

        #endregion
    }
}
