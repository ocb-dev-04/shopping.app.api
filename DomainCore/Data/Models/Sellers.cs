using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DomainCore.Data.Identity;

namespace DomainCore.Data.Models
{
    public class Sellers
    {
        #region Properties

        [Key]
        public int Id { get; set; }
        [ForeignKey("Profile")]
        public int ProfileId { get; set; }// with profile info will have name, location, and more
        public ICollection<Products> Products { get; set; }

        #region ForeingKey's

        public ProfileInfo Profile { get; set; }

        #endregion

        #endregion
    }
}
