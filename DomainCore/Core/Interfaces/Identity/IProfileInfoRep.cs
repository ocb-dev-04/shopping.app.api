using System.Threading.Tasks;
using DomainCore.Core.ModelsDTO.Identity;

namespace DomainCore.Core.Interfaces.Identity
{
    public interface IProfileInfoRep
    {
        #region Get's Methods

        Task<ProfileInfoDTO> GetProfileInfoById(int id);
        Task<ProfileInfoDTO> GetProfileInfoByName(string name);

        #endregion

        #region CRUD Methods

        Task<ProfileInfoDTO> CreateProfileInfoAsync(CreateProfileInfoDTO create);
        Task<ProfileInfoDTO> UpdateProfileInfoAsync(int id, ProfileInfoDTO update);
        Task<bool> DeleteteProfileInfoAsync(int id);

        #endregion
    }
}
