using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DomainCore.Data.Identity;

namespace DomainCore.Data.Models
{
    public class Sellers
    {
        #region Properties

        public int Id { get; set; }
        [ForeignKey("Profile")]
        public int ProfileId { get; set; }// with profile info will have name, location, and more
        public List<Products> Products { get; set; }

        #region Properties

        public ProfileInfo Profile { get; set; }

        #endregion

        #endregion
    }
}
