using System.Threading.Tasks;
using System.Collections.Generic;

using DomainCore.Core.EntitiesDTO.App.Products;

namespace DomainCore.Core.Interfaces.App
{
    public interface IProductsRep
    {
        #region Get's methods

        Task<List<ProductsDTO>> GetAllAsync();
        Task<List<ProductsDTO>> GetByNameAsync(string name);
        Task<ProductsDTO> GetByIdAsync(int id);

        #endregion

        #region CRUD methods

        Task<ProductsDTO> CreateAsync(CreateProductsDTO create);
        Task<bool> UpdateAsync(UpdateProductsDTO update);
        Task<bool> DeleteAsync(int id);

        #endregion
    }
}
