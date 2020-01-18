using System;
using System.ComponentModel.DataAnnotations;

namespace DomainCore.Data.Identity
{
    public class ProfileInfo
    {
        #region Properties

        [Key]
        public int Id { get; set; }
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
        // fecha no es requerida ya que es asignada en el constructor basandose en el horario del servidor
        public DateTime CreateDate { get; set; }

        #endregion

        #region Cosntruct

        public ProfileInfo()
            => CreateDate = DateTime.Now; // asign date on server time based

        #endregion
    }
}
