using System;

namespace DomainCore.Core.EntitiesDTO.App.Cart
{
    public class CartDTO
    {
        #region Properties

        public string UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreateDate { get; set; }

        #endregion
    }
}
