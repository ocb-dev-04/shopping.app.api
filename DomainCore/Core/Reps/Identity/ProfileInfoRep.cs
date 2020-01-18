

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using DomainCore.Core.Interfaces.Identity;
using DomainCore.Core.ModelsDTO.Identity;
using DomainCore.Core.Reps.BaseRep;
using DomainCore.Data.DbAppContext;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace DomainCore.Core.Reps.Identity
{
    public class ProfileInfoRep : AllBaseRep, IProfileInfoRep
    {
        #region Construct

        public ProfileInfoRep(
            AppDbContext dbContext,
            IMapper mapper) : base(dbContext, mapper)
        { }

        #endregion

        #region Get's Methods

        public async Task<ProfileInfoDTO> GetRrofileInfoById(int id)
            => await _appDbContext
                            .ProfileInfo
                            .ProjectTo<ProfileInfoDTO>(_mapper.ConfigurationProvider)
                            .FirstOrDefaultAsync(p => p.Id == id);

        public async Task<ProfileInfoDTO> GetRrofileInfoByName(string name)
            => await _appDbContext
                            .ProfileInfo
                            .ProjectTo<ProfileInfoDTO>(_mapper.ConfigurationProvider)
                            .FirstOrDefaultAsync(p => p.Name == name);

        #endregion

        #region CRUD Methods

        public async Task<ProfileInfoDTO> CreateProfileInfoAsync(CreateProfileInfoDTO create)
        {
            throw new NotImplementedException();
        }

        public async Task<ProfileInfoDTO> UpdateProfileInfoAsync(int id, ProfileInfoDTO update)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteteProfileInfoAsync(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
