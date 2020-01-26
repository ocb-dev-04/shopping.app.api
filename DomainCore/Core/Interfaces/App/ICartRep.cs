using System.Collections.Generic;
using System.Threading.Tasks;

using DomainCore.Core.EntitiesDTO.App.Cart;

namespace DomainCore.Core.Interfaces.App
{
    public interface ICartRep
    {
        #region Get's methods

        Task<List<CartDTO>> GetByUserIdAsync(string userId);

        #endregion

        #region CRUD

        Task<CartDTO> CreateAsync(CreateCartDTO create);

        Task<bool> UpdateAsync(UpdateCartDTO update);

        Task<bool> DeleteAsync(int productId, string userId);

        Task<bool> DeleteAllAsync(int cartId, string userId);
       
        #endregion
    }
}
