using DomainCore.Core.ModelsDTO.Identity;
using DomainCore.Data.Identity;
using AutoMapper;

namespace DomainCore.Core.Mappers.Identity
{
    public class ProfileInfoMapperDTO : Profile
    {
        #region Construct

        public ProfileInfoMapperDTO()
        {
            // dto to entity
            CreateMap<ProfileInfoDTO, ProfileInfo>();
            // entity to dto
            CreateMap<ProfileInfo, ProfileInfoDTO>();
            // create to entity
            CreateMap<CreateProfileInfoDTO, ProfileInfo>();
        }

        #endregion
    }
}
