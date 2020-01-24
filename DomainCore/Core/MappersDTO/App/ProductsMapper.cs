using AutoMapper;
using DomainCore.Core.EntitiesDTO.App.Products;

namespace DomainCore.Core.MappersDTO.App
{
    public class ProductsMapper : Profile
    {
        #region Contruct

        public ProductsMapper()
        {
            CreateMap<CreateProductsDTO, ProductsMapper>();
            CreateMap<UpdateProductsDTO, ProductsMapper>();

            CreateMap<ProductsMapper, ProductsDTO>();
        }

        #endregion
    }
}
