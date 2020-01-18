using System.ComponentModel.DataAnnotations;

namespace DomainCore.Data.Identity
{
    public class ProfileInfo : SameProps
    {
        #region Properties

        [Required]
        public string UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string PersonalDocument { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Country { get; set; }

        #endregion
    }
}
