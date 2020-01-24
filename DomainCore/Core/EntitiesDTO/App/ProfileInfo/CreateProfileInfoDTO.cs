using System.ComponentModel.DataAnnotations;

namespace DomainCore.Core.EntitiesDTO.App.ProfileInfo
{
    public class CreateProfileInfoDTO
    {
        #region Properties

        // user id finded by jwt identity user
        public string UserId { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Name is so short")]
        public string Name { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Lastname is so short")]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "Personal document invalid")]
        public string PersonalDocument { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Country { get; set; }

        #endregion
    }
}
