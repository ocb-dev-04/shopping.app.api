using AutoMapper;

using DomainCore.Core.EntitiesDTO.App.Cart;
using DomainCore.Data.Entities.App;

namespace DomainCore.Core.MappersDTO.App
{
    public class CartMapper : Profile
    {
        #region Construct

        public CartMapper()
        {
            CreateMap<CreateCartDTO, Cart>();
            CreateMap<UpdateCartDTO, Cart>();
            CreateMap<Cart, CartDTO>();
        }

        #endregion
    }
}
