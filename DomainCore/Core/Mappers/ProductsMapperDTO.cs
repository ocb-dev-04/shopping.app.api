using AutoMapper;
using DomainCore.Core.ModelsDTO.Products;
using DomainCore.Data.Models;

namespace DomainCore.Core.Mappers
{
    public class ProductsMapperDTO : Profile
    {
        #region Constructs

        public ProductsMapperDTO()
        {
            // dto to entity
            CreateMap<ProductsDTO, Products>();
            // entity to dto
            CreateMap<Products, ProductsDTO>();
            // create to entity
            CreateMap<CreateProductsDTO, Products>();
        }

        #endregion
    }
}
