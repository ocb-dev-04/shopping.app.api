using AutoMapper;
using DomainCore.Core.EntitiesDTO.App.Sellers;

namespace DomainCore.Core.MappersDTO
{
    class SellersMapper : Profile
    {
        #region Contruct

        public SellersMapper()
        {
            CreateMap<CreateSellersDTO, SellersMapper>();
            CreateMap<UpdateSellersDTO, SellersMapper>();

            CreateMap<SellersMapper, SellersDTO>();
        }

        #endregion
    }
}
