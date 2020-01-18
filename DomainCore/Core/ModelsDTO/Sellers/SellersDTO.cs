using System.Collections.Generic;
using DomainCore.Core.ModelsDTO.Products;

namespace DomainCore.Core.ModelsDTO.Sellers
{
    public class SellersDTO
    {
        #region Properties

        public int ProfileId { get; set; }// with profile info will have name, location, and more
        public ICollection<ProductsDTO> Products { get; set; }

        #endregion
    }
}
