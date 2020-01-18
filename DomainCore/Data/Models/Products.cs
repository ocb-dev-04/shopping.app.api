using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainCore.Data.Models
{
    public class Products
    {
        #region Properties

        [Key]
        public int Id { get; set; }
        [ForeignKey("Seller")]
        public int SellerId { get; set; }
        [Required]
        public string[] BigImgUrl { get; set; }
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

        #region ForeignKey's

        public Sellers Seller { get; set; }

        #endregion

        #endregion
    }
}
