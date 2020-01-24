namespace DomainCore.Core.EntitiesDTO.App.Sellers
{
    public class SellersDTO
    {
        #region Properties

        public int Id { get; set; }
        public int ProfileId { get; set; }// with profile info will have name, location, and more
        public string SellerShopName { get; set; }

        #endregion
    }
}
