using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainCore.Core.ModelsDTO.Products
{
    public class CreateProductsDTO
    {
        #region Properties

        [Required]
        public List<string> BigImgUrl { get; set; }
        [Required]
        public string ShortImgUrl { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Product name need 5 characters or more")]
        [MaxLength(50, ErrorMessage = "Product name is so long")]
        public string Name { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Description need 5 characters or more")]
        [MaxLength(400, ErrorMessage = "Description is so long")]
        public string Description { get; set; }
        [Required]
        public int SellerId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public bool FreeSend { get; set; }

        #endregion
    }
}
