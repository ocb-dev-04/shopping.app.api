using System.ComponentModel.DataAnnotations;

namespace DomainCore.Core.EntitiesDTO.App.Sellers
{
    public class UpdateSellersDTO
    {
        #region Properties

        [Required]
        public int Id { get; set; }
        [Required]
        public int ProfileId { get; set; }// with profile info will have name, location, and more
        [Required]
        public string SellerShopName { get; set; }

        #endregion
    }
}
