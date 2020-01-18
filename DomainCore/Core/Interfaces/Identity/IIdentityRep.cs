using System.Threading.Tasks;

using DomainCore.Core.ModelsDTO.Identity.JWT;
using DomainCore.Core.ModelsDTO.Identity.Login;
using DomainCore.Core.ModelsDTO.Identity.UserAppIdentity;

namespace DomainCore.Core.Interfaces.Identity
{
    public interface IIdentityRep
    {
        #region GetById

        Task<UserAppIdentityDTO> GetById(string userId);

        #endregion

        #region Create/Update/Disable

        Task<UserAppIdentityDTO> CreateUserAsync(CreateUserAppIdentityDTO create);

        Task<bool> DeleteUserAsync(string userId, string authUserId);

        #endregion

        #region Auth

        Task<JwtTokenDTO> AuthUserWebAsync(LoginDTO createToken);
        Task<JwtTokenDTO> AuthUserFixedAsync(LoginDTO createToken);
        Task LogoutAsync();

        #endregion
    }
}
