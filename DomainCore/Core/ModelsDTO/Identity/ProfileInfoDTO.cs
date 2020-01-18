using System.ComponentModel.DataAnnotations;

namespace DomainCore.Core.ModelsDTO.Identity
{
    public class ProfileInfoDTO : SamePropsDTO
    {
        #region Properties

        [Required]
        public string UserId { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Name have 8 char almost")]
        [MaxLength(15, ErrorMessage = "Name is so long")]
        public string Name { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Lastname have 8 char almost")]
        [MaxLength(25, ErrorMessage = "Lastname is so long")]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [MinLength(7, ErrorMessage = "Personal document is invalid")]
        [MaxLength(12, ErrorMessage = "Personal document is invalid")]
        public string PersonalDocument { get; set; }
        [Required]
        [MaxLength(300, ErrorMessage = "Location string is so long")]
        public string Location { get; set; }
        [Required]
        public string Country { get; set; }

        #endregion
    }
}
