using System;
using System.ComponentModel.DataAnnotations;

namespace DomainCore.Core.ModelsDTO.Identity
{
    public class ProfileInfoDTO
    {
        #region Properties

        [Required]
        public int Id { get; set; }
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
        // fecha no es requerida ya que es asignada en el constructor basandose en el horario del servidor
        public DateTime CreateDate { get; set; }

        #endregion

        #region Construct

        public ProfileInfoDTO()
            => CreateDate = DateTime.Now;

        #endregion
    }
}
