using System.ComponentModel.DataAnnotations.Schema;
using DomainCore.Data.Entities.Identity;

namespace DomainCore.Data.Entities.App
{
    public class Sellers
    {
        #region Properties

        [ForeignKey("Profile")]
        public int ProfileId { get; set; }// with profile info will have name, location, and more
        public string SellerShopName { get; set; }

        #region ForeingKey's

        [NotMapped]
        public ProfileInfo Profile { get; set; }

        #endregion

        #endregion
    }
}
