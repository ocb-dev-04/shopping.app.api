using System.Threading.Tasks;

using DomainCore.Core.ModelsDTO.Products;

namespace DomainCore.Core.Interfaces
{
    public interface IProductsRep
    {
        #region Get's Methods

        Task<ProductsDTO> GetProductsById(int id);
        Task<ProductsDTO> GetProductsByName(string name);

        #endregion

        #region CRUD Methods

        Task<ProductsDTO> CreateProductsAsync(CreateProductsDTO create);
        Task<ProductsDTO> UpdateProductsAsync(int id, ProductsDTO update);
        Task<bool> DeleteteProductsAsync(int id);

        #endregion
    }
}
