using System;
using System.ComponentModel.DataAnnotations;

namespace DomainCore.Core.ModelsDTO.Identity
{
    public class CreateProfileInfoDTO
    {
        #region Properties

        [Required]
        public string UserId { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Name have 8 char almost")]
        public string Name { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Lastname have 8 char almost")]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [MinLength(7, ErrorMessage = "Personal document is invalid")]
        [MaxLength(12, ErrorMessage = "Personal document is invalid")]
        public string PersonalDocument { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "Location is so short")]
        public string Location { get; set; }
        [Required]
        public string Country { get; set; }
        // fecha no es requerida ya que es asignada en el constructor basandose en el horario del servidor
        public DateTime CreateServerTime { get; set; }

        #endregion

        #region Construct

        public CreateProfileInfoDTO()
            => CreateServerTime = DateTime.Now;

        #endregion
    }
}
