namespace DomainCore.Core.EntitiesDTO.App.Products
{
    public class ProductsDTO
    {
        #region Properties

        public int Id { get; set; }
        public int SellerId { get; set; }
        public string BigImgUrl { get; set; }
        public string ShortImgUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public bool FreeSend { get; set; }

        #endregion
    }
}
