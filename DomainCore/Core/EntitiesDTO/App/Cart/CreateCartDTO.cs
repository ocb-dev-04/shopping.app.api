using System;
using System.ComponentModel.DataAnnotations;

namespace DomainCore.Core.EntitiesDTO.App.Cart
{
    public class CreateCartDTO
    {
        #region Properties

        public string UserId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        public DateTime CreateDate { get; set; }

        #endregion

        #region Construct

        public CreateCartDTO()
            => CreateDate = DateTime.Now;

        #endregion
    }
}
