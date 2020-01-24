using AutoMapper;

using DomainCore.Core.EntitiesDTO.App.ProfileInfo;
using DomainCore.Data.Entities.Identity;

namespace DomainCore.Core.MappersDTO
{
    public class ProfileInfoMapper : Profile
    {
        #region Construct

        public ProfileInfoMapper()
        {
            CreateMap<CreateProfileInfoDTO, ProfileInfo>();
            CreateMap<UpdateProfileInfoDTO, ProfileInfo>();
            CreateMap<ProfileInfo, ProfileInfoDTO>();
        }

        #endregion
    }
}
