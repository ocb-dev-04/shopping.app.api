using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainCore.Core.EntitiesDTO.App.Cart
{
    public class UpdateCartDTO
    {
        #region Properties

        [Required]
        public int Id { get; set; }
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
