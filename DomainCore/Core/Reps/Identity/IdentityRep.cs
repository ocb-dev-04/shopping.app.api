using System;
using System.Text;
using System.Security.Claims;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

using DomainCore.Data.Identity;
using DomainCore.Core.Interfaces.Identity;
using DomainCore.Core.ModelsDTO.Identity.JWT;
using DomainCore.Core.ModelsDTO.Identity.Login;
using DomainCore.Core.ModelsDTO.Identity.UserAppIdentity;
using Microsoft.AspNetCore.Identity;

namespace DomainCore.Core.Reps.Identity
{
    public class IdentityRep : IIdentityRep
    {
        #region Properties

        private readonly UserManager<UserAppIdentity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<UserAppIdentity> _signInManager;
        private readonly IConfiguration _configuration;

        #endregion

        #region Construct

        public IdentityRep(
            UserManager<UserAppIdentity> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<UserAppIdentity> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        #endregion

        #region Get's Methods

        public async Task<UserAppIdentityDTO> GetById(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            #region Convert to DTO

            var userInfo = new UserAppIdentityDTO
            {
                Id = user.Id,
                FullName = user.UserName,
                Email = user.Email,
            };

            #endregion

            return userInfo;
        }

        #endregion

        #region CRUD Methods

        public async Task<UserAppIdentityDTO> CreateUserAsync(CreateUserAppIdentityDTO create)
        {
            #region Convert to Identity class

            var user = new UserAppIdentity
            {
                Email = create.Email,
                UserName = create.Email,
            };

            #endregion

            var result = await _userManager.CreateAsync(user, create.Password);
            if (!result.Succeeded)
                throw new ArgumentNullException(nameof(result));

            //  find the user to add role and return the id
            var userCreated = await _userManager.FindByEmailAsync(create.Email);

            #region Convert to DTO

            var userInfo = new UserAppIdentityDTO
            {
                Id = userCreated.Id,
                FullName = userCreated.UserName,
                Email = create.Email
            };

            #endregion

            return userInfo;
        }

        public async Task<bool> DeleteUserAsync(string userId, string authUserId)
        {
            //  confirm if userId that wanna delete is the same of authUserId
            if (!userId.Equals(authUserId))
                return false;

            //  find the user with this Id
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return false;

            //  remove this client on stripe and subsccription for this client for now just is  true
            var removeFromPay = true; //await _paymentRep.RemoveClientAsync(userId);

            //  delete the user totally
            var deleteUser = await _userManager.DeleteAsync(user);

            //  confirm all is ok, if not....return false
            if (!removeFromPay || deleteUser == null)
                return false;

            return true;
        }

        #endregion

        #region Auth Methods

        //  for web auth (web app)
        public async Task<JwtTokenDTO> AuthUserWebAsync(LoginDTO createToken)
        {
            var user = await _userManager.FindByEmailAsync(createToken.Email);
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var result = await _signInManager.PasswordSignInAsync(user, createToken.Password, isPersistent: false, lockoutOnFailure: false);
            if (!result.Succeeded)
                throw new ArgumentNullException(nameof(result));

            #region CreateToken

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["Jwt:Site"],
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.Id),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(Convert.ToInt32(_configuration["Jwt:ExpiryTimeWeb"])),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            #endregion

            var tokenCreated = new JwtTokenDTO
            {
                Token = tokenHandler.WriteToken(token)
            };

            return tokenCreated;
        }

        //  for fixed auth (mobile app)
        public async Task<JwtTokenDTO> AuthUserFixedAsync(LoginDTO createToken)
        {
            var user = await _userManager.FindByEmailAsync(createToken.Email);
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var result = await _signInManager.PasswordSignInAsync(user, createToken.Password, isPersistent: false, lockoutOnFailure: false);
            if (!result.Succeeded)
                throw new ArgumentNullException(nameof(result));

            #region CreateToken

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["Jwt:Site"],
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.Id),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Name, user.Id.ToString())

                }),
                Expires = DateTime.UtcNow.AddYears(Convert.ToInt32(_configuration["Jwt:ExpiryTimeFixed"])),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            #endregion

            var tokenCreated = new JwtTokenDTO
            {
                Token = tokenHandler.WriteToken(token)
            };

            return tokenCreated;
        }

        //  for logout
        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        #endregion
    }
}
