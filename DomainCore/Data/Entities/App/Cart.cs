using System;
using System.ComponentModel.DataAnnotations;

namespace DomainCore.Data.Entities.App
{
    public class Cart
    {
        #region Properties

        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }

        #endregion
    }
}
