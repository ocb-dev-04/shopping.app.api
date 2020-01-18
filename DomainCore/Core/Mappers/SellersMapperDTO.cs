using DomainCore.Core.ModelsDTO.Sellers;
using DomainCore.Data.Models;
using AutoMapper;

namespace DomainCore.Core.Mappers
{
    public class SellersMapperDTO : Profile
    {
        #region Construct

        public SellersMapperDTO()
        {
            // dto to entity
            CreateMap<SellersDTO, Sellers>();
            // entity to dto
            CreateMap<Sellers, SellersDTO>();
            // create to entity
            CreateMap<CreateSellersDTO, Sellers>();
        }

        #endregion
    }
}
