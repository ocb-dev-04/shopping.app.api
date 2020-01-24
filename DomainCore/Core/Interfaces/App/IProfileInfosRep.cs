using System.Threading.Tasks;
using System.Collections.Generic;

using DomainCore.Core.EntitiesDTO.App.ProfileInfo;

namespace DomainCore.Core.Interfaces.App
{
    public interface IProfileInfosRep
    {
        #region Get's methods

        Task<List<ProfileInfoDTO>> GetAllAsync();
        Task<ProfileInfoDTO> GetByIdAsync(string id);

        #endregion

        #region CRUD methods

        Task<ProfileInfoDTO> CreateAsync(CreateProfileInfoDTO create);
        Task<bool> UpdateAsync(UpdateProfileInfoDTO update);
        Task<bool> DeleteAsync(string id);

        #endregion
    }
}
