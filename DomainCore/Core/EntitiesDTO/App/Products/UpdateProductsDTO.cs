using System.ComponentModel.DataAnnotations;

namespace DomainCore.Core.EntitiesDTO.App.Products
{
    public class UpdateProductsDTO
    {
        #region Properties

        [Required]
        public int Id { get; set; }
        [Required]
        public int SellerId { get; set; }
        [Required]
        public string BigImgUrl { get; set; }
        [Required]
        public string ShortImgUrl { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public bool FreeSend { get; set; }

        #endregion
    }
}
