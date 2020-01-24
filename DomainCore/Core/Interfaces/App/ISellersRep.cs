using System.Threading.Tasks;
using System.Collections.Generic;
using DomainCore.Core.EntitiesDTO.App.Sellers;

namespace DomainCore.Core.Interfaces.App
{
    public interface ISellersRep
    {
        #region Get's methods

        Task<List<SellersDTO>> GetAllAsync();
        Task<SellersDTO> GetByIdAsync(int id);

        #endregion

        #region CRUD methods

        Task<SellersDTO> CreateAsync(CreateSellersDTO create);
        Task<bool> UpdateAsync(UpdateSellersDTO update);
        Task<bool> DeleteAsync(int id);

        #endregion
    }
}
