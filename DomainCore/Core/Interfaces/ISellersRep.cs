using System.Threading.Tasks;

using DomainCore.Core.ModelsDTO.Sellers;

namespace DomainCore.Core.Interfaces
{
    public interface ISellersRep
    {
        #region Get's Methods

        Task<SellersDTO> GetSellersById(int id);
        Task<SellersDTO> GetSellersByProfileId(int profile);

        #endregion

        #region CRUD Methods

        Task<SellersDTO> CreateSellersAsync(CreateSellersDTO create);
        Task<SellersDTO> UpdateSellersAsync(int id, SellersDTO update);
        Task<bool> DeleteteSellersAsync(int id);

        #endregion
    }
}
